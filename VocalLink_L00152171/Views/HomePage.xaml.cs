// <copyright file="HomePage.xaml.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Views
{
    using VocalLink_L00152171.ViewModels;

    /// <summary>
    /// Home Page for the VocalLink application.
    /// </summary>
    public partial class HomePage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HomePage"/> class.
        /// </summary>
        public HomePage()
        {
            this.InitializeComponent();
            this.BindingContext = new HomePageViewModel();
        }

        /// <summary>
        /// Method to implement this on page appearing.
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            this.welcomeLabel.Text = "Welcome " + Preferences.Get("UserEmail", "Guest");

            if (this.BindingContext is HomePageViewModel vm)
            {
                await vm.LoadDataAsync();
            }

            // enable flyout navigation
            if (Shell.Current is AppShell shell)
            {
                shell.EnableFlyout();
            }
        }
    }
}