using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Options.NSwag;

namespace ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Options.NSwagStudio
{
    public class DefaultNSwagStudioOptions : DefaultNSwagOptions, INSwagStudioOptions
    {
        public bool GenerateResponseClasses { get; }
        public bool GenerateJsonMethods { get; }
        public bool RequiredPropertiesMustBeDefined { get; }
        public bool GenerateDefaultValues { get; }
        public bool GenerateDataAnnotations { get; }
    }
}