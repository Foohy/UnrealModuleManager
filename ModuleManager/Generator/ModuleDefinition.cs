using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace ModuleManager.Generator
{
    [JsonConverter(typeof(StringEnumConverter))]
    public enum ModuleLoadingPhase
    {
        Unknown,

        Default,
        PreDefault,
        PostConfigInit,
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum ModuleType
    {
        Unknown,

        Runtime,
        RuntimeNoCommandlet,
        Developer,
        Editor,
        EditorNoCommandlet,
        Program,

        ThirdParty //Only valid for engine modules
    }

    class ModuleDefinition
    {
        public string ModuleName { get; private set; }
        public string FullModulePath { get; private set; }
        public bool IsProjectModule { get; private set; }

        public ModuleType Type { get { return UProjectSettings.Type; } }
        public ModuleLoadingPhase LoadingPhase { get { return UProjectSettings.LoadingPhase; } }
        public string[] AdditionalDependencies { get { return UProjectSettings.AdditionalDependencies; } }

        private UProjectModule UProjectSettings = UProjectModule.InvalidModule;

        public ModuleDefinition( string sModuleName, string sFullModulePath, bool bIsProjectModule )
        {
            ModuleName = sModuleName;
            FullModulePath = sFullModulePath;
            IsProjectModule = bIsProjectModule;
        }

        public static ModuleDefinition TryParseModule(string ModulePath, bool isProjectModule)
        {
            if (!Directory.Exists(ModulePath)) return null;

            string ModuleName = Path.GetFileName(ModulePath);
            string BuildCS = Path.Combine(ModulePath, ModuleName + ".Build.cs");
            if (!File.Exists(BuildCS)) return null;

            return new ModuleDefinition(ModuleName, ModulePath, isProjectModule);
        }

        public void SetUProjectSettings( UProjectModule mod )
        {
            UProjectSettings = mod;
        }

    }

    class UProjectModule
    {
        public string Name;
        public ModuleType Type;
        public ModuleLoadingPhase LoadingPhase;
        public string[] AdditionalDependencies = new string[0];

        public static UProjectModule InvalidModule = new UProjectModule();

        public UProjectModule()
        {

        }

        public UProjectModule(ModuleType mtType)
        {
            Type = mtType;
        }


        public static UProjectModule LoadFromJObject(JToken ModuleToken)
        {
            return JsonConvert.DeserializeObject<UProjectModule>(ModuleToken.ToString());
        }
    }
}
