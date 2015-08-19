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
    class ModuleGenerator
    {
        public const string ModuleNameToken = "MODULE_NAME";
        public const string ModuleNameCapsToken = "MODULE_NAME_UPPER";
        public const string PublicDependenciesToken = "ADDITIONAL_PUBLIC_DEPENDENCIES";
        public const string PrivateDependenciesToken = "ADDITIONAL_PRIVATE_DEPENDENCIES";
        
        //Templating
        public const string TemplateDir = "Templates\\";

        //Registry key locations
        public const string UnrealInstallReg = "HKEY_LOCAL_MACHINE/SOFTWARE/EpicGames/Unreal Engine/";
  
        //Useful paths
        private string ProjectFile;
        private string SourcePath;
        private string EngineSourcePath;

        //Parsed project information
        public string ProjectName { get; private set; }
        public string EngineVersion { get; private set; }
        public string Category { get; private set; }
        public string Description { get; private set; }

        //Existing Dependencies
        public ModuleDefinition[] ProjectModules {get; private set; }
        public ModuleDefinition[] EngineModules { get; private set; }

        public ModuleGenerator( string sProjectFile )
        {
            if (!File.Exists(sProjectFile))
                throw new FileNotFoundException();

            ProjectFile = sProjectFile;

            //Parse project information
            SourcePath = Path.Combine(Path.GetDirectoryName(sProjectFile), "Source");
            ProjectName = Path.GetFileNameWithoutExtension(sProjectFile);
           

            //Grab the available dependencies
            ProjectModules = GetModules(SourcePath, true);

            //Parse the .uproject json
            ParseUnrealProject(sProjectFile);

            //Grab engine dependencies, now that we know what engine version we're using
            EngineSourcePath = GetProjectEngineSourcePath();
            if (!string.IsNullOrEmpty(EngineSourcePath))
                EngineModules = GetModules(EngineSourcePath, false);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ModuleName">The name of the Unreal module to create</param>
        /// <param name="PublicDependencies"></param>
        /// <param name="PrivateDependencies"></param>
        public void GenerateNewModule(string ModuleName, string[] PublicDependencies, string[] PrivateDependencies)
        {
            //Generate a brand new module
            string ModulePath = Path.Combine(SourcePath, ModuleName);
            string TemplatePath = Path.Combine(Directory.GetCurrentDirectory(), TemplateDir);

            Console.WriteLine("[GENERATE] Gathering file templates");

            //Go through all the files in the /Templates/ folder, templatizing and generating them in the right place
            string[] Files = null;
            try
            {
                Files = Directory.GetFiles(TemplatePath,"*", SearchOption.AllDirectories);
            }
            catch (DirectoryNotFoundException ex) { }

            if (Files == null || Files.Length == 0)
                throw new FileNotFoundException("Templates folder was missing or empty!");

            foreach (string Filename in Files)
            {
                //Replace the naming scheme
                string newFileName = Path.GetFileName(Filename).Replace(ModuleNameToken, ModuleName);

                //Get the path relative to the templates folder
                string relativePath = PathUtils.GetRelativePath(Path.GetDirectoryName(Filename), TemplatePath);
                string outputFilepath = Path.Combine(ModulePath, relativePath, newFileName);

                Console.WriteLine("[GENERATE] {0}", outputFilepath);

                //Generate the path
                string builtFile = GenerateFromTokens(Filename, ModuleName, PublicDependencies, PrivateDependencies);
                Directory.CreateDirectory(Path.GetDirectoryName(outputFilepath));
                File.WriteAllText(outputFilepath, builtFile);
            }

            Console.WriteLine("[GENERATE] Finished!");
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

        private string GetProjectEngineSourcePath()
        {
            string installDir = (string)Registry.GetValue(UnrealInstallReg, "INSTALLDIR", "");
            if (!Directory.Exists(installDir)) return "";

            return Path.Combine(installDir, EngineVersion, "Engine\\Source\\");
        }

        private void LoadEngineModules(string engineSourcePath)
        {
            //The engine's source path is set up so each subfolder
            //Is the module type. So organize by that

            string[] directories = Directory.GetDirectories(engineSourcePath);
            
        }

        private ModuleDefinition[] GetModules( string ModulePath, bool isProject )
        {
            List<ModuleDefinition> ModuleBuilder = new List<ModuleDefinition>();
            string[] folders = Directory.GetDirectories(ModulePath);
            foreach (string folder in folders)
            {
                ModuleDefinition def = ModuleDefinition.TryParseModule(folder, true);

                if (def != null)
                {
                    ModuleBuilder.Add(def);
                }
            }

            return ModuleBuilder.ToArray();
        }

        private string GenerateFromTokens(string templateFile, string ModuleName, string[] PublicDependencies, string[] PrivateDependencies)
        {
            string templateStr = GenerateFromTokens(templateFile, ModuleName);

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

        private string GenerateFromTokens(string templateFile, string ModuleName)
        {
            string templateStr = File.ReadAllText(templateFile);

            //Replace name tokens
            templateStr = templateStr.Replace(ModuleNameCapsToken, ModuleName.ToUpper());
            templateStr = templateStr.Replace(ModuleNameToken, ModuleName);

            return templateStr;
        }

        private bool ParseUnrealProject( string unrealProjectPath )
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
