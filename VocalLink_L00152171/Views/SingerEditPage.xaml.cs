// <copyright file="SingerEditPage.xaml.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Views
{
    using VocalLink_L00152171.ViewModels;

    /// <summary>
    /// Singer edit page for the VocalLink application.
    /// </summary>
    public partial class SingerEditPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingerEditPage"/> class.
        /// </summary>
        public SingerEditPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Method to implement this on page appearing.
        /// </summary>
        protected override async void OnAppearing()
        {
            base.OnAppearing();

            if (this.BindingContext is SingerEditViewModel vm)
            {
                await vm.LoadSingerAsync();
            }

            // disable flyout navigation
            if (Shell.Current is AppShell shell)
            {
                shell.DisableFlyout();
            }
        }
    }
}