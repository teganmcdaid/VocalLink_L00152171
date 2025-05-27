// <copyright file="DeveloperSettingsPage.xaml.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Views
{
    using VocalLink_L00152171.ViewModels;

    /// <summary>
    /// Developer settings Page for the VocalLink application.
    /// </summary>
    public partial class DeveloperSettingsPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeveloperSettingsPage"/> class.
        /// </summary>
        public DeveloperSettingsPage()
        {
            this.InitializeComponent();
            this.BindingContext = new DeveloperSettingsViewModel();
        }
    }
}