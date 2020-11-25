﻿using System;
using System.IO;
using System.Threading.Tasks;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Generators;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Generators.NSwagStudio;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Options.General;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Options.NSwagStudio;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Generators.NSwagStudio;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Tests;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Windows;
using FluentAssertions;
using Moq;
using Xunit;

namespace ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.IntegrationTests.Generators
{
    [Xunit.Trait("Category", "SkipWhenLiveUnitTesting")]
    public class NSwagStudioCodeGeneratorFixture : TestWithResources, IAsyncLifetime
    {
        public string Code { get; private set; }

        public async Task InitializeAsync()
        {
            var generalOptions = new Mock<IGeneralOptions>();
            generalOptions.Setup(c => c.NSwagPath).Returns(PathProvider.GetNSwagPath());

            var options = new Mock<INSwagStudioOptions>();
            options.Setup(c => c.UseDocumentTitle).Returns(false);
            options.Setup(c => c.GenerateDtoTypes).Returns(true);

            var outputFilename = $"PetstoreClient{Guid.NewGuid():N}";
            var contents = await NSwagStudioFileHelper.CreateNSwagStudioFileAsync(
                new EnterOpenApiSpecDialogResult(
                    ReadAllText(SwaggerJson),
                    outputFilename,
                    "https://petstore.swagger.io/v2/swagger.json"),
                options.Object);

            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, contents);

            new NSwagStudioCodeGenerator(tempFile, generalOptions.Object, new ProcessLauncher())
                .GenerateCode(new Mock<IProgressReporter>().Object)
                .Should()
                .BeNull();

            Code = File.ReadAllText(
                Path.Combine(
                    Path.GetDirectoryName(tempFile) ?? throw new InvalidOperationException(),
                    $"{outputFilename}.cs"));
        }

        public Task DisposeAsync() => Task.CompletedTask;
    }
}