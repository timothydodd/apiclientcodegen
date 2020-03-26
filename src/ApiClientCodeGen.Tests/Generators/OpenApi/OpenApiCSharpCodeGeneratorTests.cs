﻿using AutoFixture;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Generators;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Generators.OpenApi;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core.Options.General;

using Moq;

namespace ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Tests.Generators.OpenApi
{
    
    // [DeploymentItem("Resources/Swagger.json")]
    public class OpenApiCSharpCodeGeneratorTests
    {
        private readonly Mock<IGeneralOptions> optionsMock = new Mock<IGeneralOptions>();
        private readonly Mock<IProgressReporter> progressMock = new Mock<IProgressReporter>();

        public OpenApiCSharpCodeGeneratorTests()
            => new OpenApiCSharpCodeGenerator(
                    "Swagger.json",
                    new Fixture().Create<string>(),
                    optionsMock.Object,
                    new ProcessLauncher())
                .GenerateCode(progressMock.Object);

        [Xunit.Fact]
        public void Reads_SwaggerCodegenPath()
            => optionsMock.Verify(c => c.OpenApiGeneratorPath);

        [Xunit.Fact]
        public void Updates_Progress()
            => progressMock.Verify(
                c => c.Progress(
                    It.IsAny<uint>(),
                    It.IsAny<uint>()),
                Times.Exactly(5));
    }
}
