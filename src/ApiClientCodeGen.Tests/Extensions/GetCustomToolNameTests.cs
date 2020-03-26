﻿using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Core;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Extensions;
using FluentAssertions;


namespace ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Tests.Extensions
{
    
    public class GetCustomToolNameTests
    {
        [Xunit.Fact]
        public void GetCustomToolName_AutoRest()
            => SupportedCodeGenerator.AutoRest
                .GetCustomToolName()
                .Should()
                .Contain("AutoRest");

        [Xunit.Fact]
        public void GetCustomToolName_NSwag()
            => SupportedCodeGenerator.NSwag
                .GetCustomToolName()
                .Should()
                .Contain("NSwag");

        [Xunit.Fact]
        public void GetCustomToolName_Swagger()
            => SupportedCodeGenerator.Swagger
                .GetCustomToolName()
                .Should()
                .Contain("Swagger");

        [Xunit.Fact]
        public void GetCustomToolName_OpenApi()
            => SupportedCodeGenerator.OpenApi
                .GetCustomToolName()
                .Should()
                .Contain("OpenApi");
    }
}
