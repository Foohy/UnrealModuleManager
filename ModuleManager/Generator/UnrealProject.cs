using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.Win32;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ModuleManager.Generator
{
    class UnrealProject
    {
        //Templating tokens
        public const string ModuleNameToken = "MODULE_NAME";
        public const string ModuleNameCapsToken = "MODULE_NAME_UPPER";
        public const string PublicDependenciesToken = "ADDITIONAL_PUBLIC_DEPENDENCIES";
        public const string PrivateDependenciesToken = "ADDITIONAL_PRIVATE_DEPENDENCIES";
        
        /// <summary>
        /// The templates folder relative to the application working directory
        /// </summary>
        public const string TemplateDir = "Templates\\";

        /// <summary>
        /// Registry key location for the unreal install directory
        /// </summary>
        public const string UnrealInstallReg = "HKEY_LOCAL_MACHINE\\SOFTWARE\\EpicGames\\Unreal Engine";
  
        //Useful paths
        /// <summary>
        /// The absolute path to the loaded .uproject file the generator is based upon
        /// </summary>
        public string ProjectFile { get; private set; }

        //Parsed project information
        /// <summary>
        /// The short name of the unreal project
        /// </summary>
        public string ProjectName { get; private set; }

        /// <summary>
        /// The string version-number of the unreal engine version the project is built for
        /// </summary>
        public string EngineVersion { get; private set; }

        /// <summary>
        /// The category string of the unreal project
        /// </summary>
        public string Category { get; private set; }

        /// <summary>
        /// The description of the unreal project
        /// </summary>
        public string Description { get; private set; }

        private string SourcePath;
        private string EngineSourcePath;


        //Existing Dependencies
        public ModuleDefinition[] ProjectModules {get; private set; }
        public ModuleDefinition[] EngineModules { get; private set; }

        public UnrealProject(string sProjectFile)
        {
            if (!File.Exists(sProjectFile))
                throw new FileNotFoundException();

            ProjectFile = sProjectFile;

            //Parse project information
            SourcePath = Path.Combine(Path.GetDirectoryName(sProjectFile), "Source");
            ProjectName = Path.GetFileNameWithoutExtension(sProjectFile);        

            //Grab the available dependencies
            ProjectModules = getModules(SourcePath, true);

            //Parse the .uproject json
            if (!parseUnrealProject(sProjectFile))
                throw new System.IO.InvalidDataException("Failed to parse .uproject file!");

            //Grab engine dependencies, now that we know what engine version we're using
            EngineSourcePath = getProjectEngineSourcePath();
            if (Directory.Exists(EngineSourcePath))
                EngineModules = loadEngineModules(EngineSourcePath);
        }

        /// <summary>
        ///  Generate a new module for your current project
        /// </summary>
        /// <param name="ModuleName">The name of the Unreal module to create</param>
        /// <param name="PublicDependencies"></param>
        /// <param name="PrivateDependencies"></param>
        /// <param name="settings"></param>
        public void GenerateNewModule(string ModuleName, string[] PublicDependencies, string[] PrivateDependencies, UProjectModule settings)
        {
            //Generate a brand new module
            string ModulePath = Path.Combine(SourcePath, ModuleName);
            string TemplatePath = Path.Combine(Directory.GetCurrentDirectory(), TemplateDir);

            Console.WriteLine("[GENERATE] Gathering file templates");

            //Go through all the files in the /Templates/ folder, templatizing and generating them in the right place
            string[] Files = null;
            try
            {
                Files = Directory.GetFiles(TemplatePath, "*", SearchOption.AllDirectories);
            }
            catch (DirectoryNotFoundException ex) { }

            if (Files == null || Files.Length == 0)
                throw new FileNotFoundException("Templates folder was missing or empty!");

            foreach (string Filename in Files)
            {
                //Replace the naming scheme
                string newFileName = Path.GetFileName(Filename).Replace(ModuleNameToken, ModuleName);

                //Get the path relative to the templates folder
                string relativePath = StringUtils.GetRelativePath(Path.GetDirectoryName(Filename), TemplatePath);
                string outputFilepath = Path.Combine(ModulePath, relativePath, newFileName);

                Console.WriteLine("[GENERATE] {0}", outputFilepath);

                //Generate the path
                string builtFile = generateFromTokens(Filename, ModuleName, PublicDependencies, PrivateDependencies);
                Directory.CreateDirectory(Path.GetDirectoryName(outputFilepath));
                File.WriteAllText(outputFilepath, builtFile);
            }

            //Now, attempt to overwrite the *.uproject file with our new module entry
            //prepare your butts
            if (settings != null)
            {
                addOrEditUprojectModule(ProjectFile, ModuleName, settings);
            }

            Console.WriteLine("[GENERATE] Finished!");
        }

        /// <summary>
        /// Generate a new module for your current project
        /// </summary>
        /// <param name="ModuleName">The name of the Unreal module to create</param>
        /// <param name="PublicDependencies"></param>
        /// <param name="PrivateDependencies"></param>
        public void GenerateNewModule(string ModuleName, string[] PublicDependencies, string[] PrivateDependencies)
        {
            GenerateNewModule(ModuleName, PublicDependencies, PrivateDependencies, null);
        }

        /// <summary>
        /// Query if the specified module name already exists in the project source path
        /// </summary>
        /// <param name="ModuleName">The name of the Unreal module to create</param>
        /// <returns>True if the path already exists, false if it does not exist</returns>
        public bool QueryNewModuleExists(string ModuleName)
        {
            return Directory.Exists(Path.Combine(SourcePath, ModuleName));
        }

        /// <summary>
        /// Get the collection of modules built into the engine
        /// </summary>
        /// <returns></returns>
        public ModuleDefinition[] GetEngineModules()
        {
            return EngineModules;
        }

        /// <summary>
        /// Get the collection of modules associated with the project
        /// </summary>
        /// <returns></returns>
        public ModuleDefinition[] GetProjectModules()
        {
            return ProjectModules;
        }

        /// <summary>
        /// Find a module of a given name
        /// </summary>
        /// <param name="ModuleName">The name of the module to find</param>
        /// <returns>The module definition with a matching name, or null if not found</returns>
        public ModuleDefinition FindProjectModule(string ModuleName)
        {
            foreach( ModuleDefinition module in ProjectModules)
            {
                if (module.ModuleName.Equals(ModuleName, StringComparison.InvariantCultureIgnoreCase))
                    return module;
            }

            return null;
        }

        private string getProjectEngineSourcePath()
        {
            string installDir = (string)Registry.GetValue(UnrealInstallReg, "INSTALLDIR", "");
            if (!Directory.Exists(installDir)) return "";

            return Path.Combine(installDir, EngineVersion, "Engine\\Source\\");
        }

        private ModuleDefinition[] loadEngineModules(string engineSourcePath)
        {
            List<ModuleDefinition> moduleBuilder = new List<ModuleDefinition>();

            //The engine's source path is set up so each subfolder
            //Is the module type. So organize by that

            string[] directories = Directory.GetDirectories(engineSourcePath);

            foreach (string dir in directories)
            {
                //Attempt to figure out what enum the folder name matches
                string FolderName = Path.GetFileName(dir);
                ModuleType type;
                if (!Enum.TryParse<ModuleType>(FolderName, out type)) continue;

                ModuleDefinition[] definitions = getModules(dir, false);
                
                //Set the type for each module found
                foreach (ModuleDefinition def in definitions)
                    def.SetUProjectSettings(new UProjectModule(type));

                moduleBuilder.AddRange(definitions);
            }

            return moduleBuilder.ToArray();
            
        }

        private ModuleDefinition[] getModules( string ModulePath, bool isProject )
        {
            List<ModuleDefinition> ModuleBuilder = new List<ModuleDefinition>();
            string[] folders = Directory.GetDirectories(ModulePath);
            foreach (string folder in folders)
            {
                ModuleDefinition def = ModuleDefinition.TryParseModule(folder, isProject);

                if (def != null)
                {
                    ModuleBuilder.Add(def);
                }
            }

            return ModuleBuilder.ToArray();
        }

        private string generateFromTokens(string templateFile, string ModuleName, string[] PublicDependencies, string[] PrivateDependencies)
        {
            string templateStr = generateFromTokens(templateFile, ModuleName);

            //Format dependencies like
            // { "Dependency1", "Dependecy2", "Dependency3" } etc.
            //To fit in the syntax of a C# array initializer
            string sPubDependcies = "";
            if (PublicDependencies.Length > 0)
                sPubDependcies = "\"" + string.Join("\", \"", PublicDependencies) + "\"";

            string sPrivDependcies = "";
            if (PrivateDependencies.Length > 0)
                sPrivDependcies = "\"" + string.Join("\", \"", PrivateDependencies) + "\"";

            //Replace dependency tokens
            templateStr = templateStr.Replace(PublicDependenciesToken, sPubDependcies);
            templateStr = templateStr.Replace(PrivateDependenciesToken, sPrivDependcies);

            return templateStr;
        }

        private string generateFromTokens(string templateFile, string ModuleName)
        {
            string templateStr = File.ReadAllText(templateFile);

            //Replace name tokens
            templateStr = templateStr.Replace(ModuleNameCapsToken, ModuleName.ToUpper());
            templateStr = templateStr.Replace(ModuleNameToken, ModuleName);

            return templateStr;
        }

        private void addOrEditUprojectModule( string unrealProjectPath, string moduleName, UProjectModule settings )
        {
            string json;
            try
            {
                json = File.ReadAllText(unrealProjectPath);
            }
            catch (Exception ex)
            {
                return;
            }

            JObject uproject = JObject.Parse(json);

            //Get the array of modules and try to find to find a matching one to update
            JArray moduleArray = (JArray)uproject["Modules"];
            IEnumerator<JToken> e = moduleArray.GetEnumerator();
            foreach (JToken moduleJson in moduleArray.Children().ToList())
            {
                UProjectModule jsonConv = UProjectModule.LoadFromJObject(moduleJson);

                //If they're matching names, remove it from the array (we'll add it later)
                if (jsonConv.Name.Equals(settings.Name, StringComparison.InvariantCultureIgnoreCase))
                {
                    moduleJson.Remove();
                    break;
                }
            }

            //Add to the array
            moduleArray.Add(JToken.FromObject(settings));

            //Write it out to the file
            File.WriteAllText(unrealProjectPath, uproject.ToString());
        }

        private bool parseUnrealProject( string unrealProjectPath )
        {
            string json;
            try
            {
                json = File.ReadAllText(unrealProjectPath);
            }
            catch (Exception ex )
            {
                return false;
            }

            JObject uproject = JObject.Parse(json);

            try 
            {
                EngineVersion = uproject.Property("EngineAssociation").Value.ToString();
                Category = uproject.Property("Category").Value.ToString();
                Description = uproject.Property("Description").Value.ToString();

                //Go through and try to parse each defined module
                IList<JToken> modules = uproject["Modules"].Children().ToList();
                
                foreach( JToken moduleJson in modules )
                {
                    //First quickly try to parse the name
                    UProjectModule jsonConv = UProjectModule.LoadFromJObject(moduleJson);
                    ModuleDefinition module = FindProjectModule(jsonConv.Name);

                    module.SetUProjectSettings(jsonConv);
                }
            }
            catch( JsonException ex)
            {
                return false;
            }

            return true;
        }

    }
}
