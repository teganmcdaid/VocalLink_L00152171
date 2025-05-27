// <copyright file="SingerProfilePage.xaml.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Views
{
    using VocalLink_L00152171.Model;
    using VocalLink_L00152171.ViewModels;

    /// <summary>
    /// Singer Profile Page for the VocalLink application.
    /// </summary>
    public partial class SingerProfilePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingerProfilePage"/> class.
        /// </summary>
        /// <param name="selectedSinger"> Pass through the singers page to view.</param>
        public SingerProfilePage(Singer selectedSinger)
        {
            this.InitializeComponent();
            this.BindingContext = new SingerProfileViewModel(selectedSinger);
        }

        /// <summary>
        /// Method to implement this on page appearing.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // disable flyout navigation
            if (Shell.Current is AppShell shell)
            {
                shell.DisableFlyout();
            }
        }
    }
}