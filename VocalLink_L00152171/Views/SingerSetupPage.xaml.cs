// <copyright file="SingerSetupPage.xaml.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Views
{
    using VocalLink_L00152171.ViewModels;

    /// <summary>
    /// Singer Setup Page for the VocalLink application.
    /// </summary>
    public partial class SingerSetupPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingerSetupPage"/> class.
        /// </summary>
        public SingerSetupPage()
        {
            this.InitializeComponent();
            this.BindingContext = new SingerSetupViewModel();
        }
    }
}