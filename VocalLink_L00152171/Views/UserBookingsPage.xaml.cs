// <copyright file="UserBookingsPage.xaml.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Views
{
    using VocalLink_L00152171.ViewModels;

    /// <summary>
    /// Booking page for the VocalLink application.
    /// </summary>
    public partial class UserBookingsPage : ContentPage
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UserBookingsPage"/> class.
        /// </summary>
        public UserBookingsPage()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// method to implement this on page appearing.
        /// </summary>
        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (this.BindingContext is UserBookingsViewModel vm)
            {
                vm.LoadBookingsAsync();
            }
        }
    }
}