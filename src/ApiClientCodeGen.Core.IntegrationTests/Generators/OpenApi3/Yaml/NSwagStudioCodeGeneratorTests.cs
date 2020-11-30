﻿using ApiClientCodeGen.Tests.Common.Build;
using ApiClientCodeGen.Tests.Common.Fixtures.OpenApi3.Yaml;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core;
using Xunit;

namespace ApiClientCodeGen.Core.IntegrationTests.Generators.OpenApi3.Yaml
{
    [Trait("Category", "SkipWhenLiveUnitTesting")]
    public class NSwagStudioCodeGeneratorTests : IClassFixture<NSwagStudioCodeGeneratorFixture>
    {
        private readonly string code;

        public NSwagStudioCodeGeneratorTests(NSwagStudioCodeGeneratorFixture fixture)
        {
            code = fixture.Code;
        }

        [Fact]
        public void GeneratedCode_Can_Build_In_NetCoreApp() 
            => BuildHelper.BuildCSharp(ProjectTypes.DotNetCoreApp, code, SupportedCodeGenerator.NSwagStudio);

        [Fact]
        public void GeneratedCode_Can_Build_In_NetStandardLibrary() 
            => BuildHelper.BuildCSharp(ProjectTypes.DotNetStandardLibrary, code, SupportedCodeGenerator.NSwagStudio);
    }
}