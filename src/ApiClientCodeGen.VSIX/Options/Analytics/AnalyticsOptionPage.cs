﻿using System.Diagnostics.CodeAnalysis;
using System.Windows.Forms;
using ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Windows;
using Microsoft.VisualStudio.Shell;

namespace ChristianHelle.DeveloperTools.CodeGenerators.ApiClient.Options.Analytics
{
    [ExcludeFromCodeCoverage]
    public class AnalyticsOptionPage : DialogPage
    {
        public const string Name = "Analytics";

        public AnalyticsOptionPage()
        {
        }

        protected override IWin32Window Window
            => new AnalyticsOptionsPageCustom();
    }
}
