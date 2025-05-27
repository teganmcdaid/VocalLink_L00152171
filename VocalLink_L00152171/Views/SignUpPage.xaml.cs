// <copyright file="SignUpPage.xaml.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Views
{
    using VocalLink_L00152171.ViewModels;

    /// <summary>
    /// Sign up page for the VocalLink application.
    /// </summary>
    public partial class SignUpPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SignUpPage"/> class.
        /// </summary>
        public SignUpPage()
        {
            this.InitializeComponent();
            this.BindingContext = new SignUpViewModel();
        }

        /// <summary>
        /// method to implement this on page appearing.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();
            if (this.BindingContext is SignUpViewModel viewModel)
            {
                viewModel.ClearFields();
            }
        }
    }
}