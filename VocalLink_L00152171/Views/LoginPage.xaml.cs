// <copyright file="LoginPage.xaml.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Views
{
    using VocalLink_L00152171.ViewModels;

    /// <summary>
    /// Login Page for the VocalLink application.
    /// </summary>
    public partial class LoginPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LoginPage"/> class.
        /// </summary>
        public LoginPage()
        {
            this.InitializeComponent();
            this.BindingContext = new LoginViewModel();
        }

        /// <summary>
        /// Method to implement this on page appearing.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            // clear fields when page opened
            if (this.BindingContext is LoginViewModel viewModel)
            {
                viewModel.ClearFields();
            }

            // disable flyout navigation
            if (Shell.Current is AppShell shell)
            {
                shell.DisableFlyout();
            }
        }
    }
}