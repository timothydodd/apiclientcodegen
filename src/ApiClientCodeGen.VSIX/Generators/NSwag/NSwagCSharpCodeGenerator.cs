﻿using System;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Extensions;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using NJsonSchema.CodeGeneration.CSharp;
using NSwag;
using NSwag.CodeGeneration.CSharp;

namespace ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Generators.NSwag
{
    public class NSwagCSharpCodeGenerator : ICodeGenerator
    {
        private readonly string swaggerFile;
        private readonly string defaultNamespace;

        public NSwagCSharpCodeGenerator(string swaggerFile, string defaultNamespace)
        {
            this.swaggerFile = swaggerFile ?? throw new ArgumentNullException(nameof(swaggerFile));
            this.defaultNamespace = defaultNamespace ?? throw new ArgumentNullException(nameof(defaultNamespace));
        }

        public string GenerateCode(IVsGeneratorProgress pGenerateProgress)
        {
            try
            {
                pGenerateProgress?.Progress(10);

                var document = SwaggerDocument
                    .FromFileAsync(swaggerFile)
                    .GetAwaiter()
                    .GetResult();
                
                pGenerateProgress?.Progress(20);

                var settings = new SwaggerToCSharpClientGeneratorSettings
                {
                    ClassName = "ApiClient",
                    InjectHttpClient = true,
                    GenerateClientInterfaces = true,
                    GenerateDtoTypes = true,
                    UseBaseUrl = false,
                    CSharpGeneratorSettings =
                    {
                        Namespace = defaultNamespace,
                        ClassStyle = CSharpClassStyle.Inpc
                    },
                };
                
                pGenerateProgress?.Progress(50);

                var generator = new SwaggerToCSharpClientGenerator(document, settings);
                return generator.GenerateFile();
            }
            finally
            {
                pGenerateProgress?.Progress(90);
            }
        }
    }
}