// <copyright file="AppShell.xaml.cs" company="Tegan Mc Daid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171
{
    using VocalLink_L00152171.Views;

    /// <summary>
    /// application shell for the VocalLink application.
    /// </summary>
    public partial class AppShell : Shell
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AppShell"/> class.
        /// </summary>
        public AppShell()
        {
            this.InitializeComponent();
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("SignUpPage", typeof(SignUpPage));
            Routing.RegisterRoute("SingerSetupPage", typeof(SingerSetupPage));
            Routing.RegisterRoute("HomePage", typeof(HomePage));
            Routing.RegisterRoute("SingerProfilePage", typeof(SingerProfilePage));
            Routing.RegisterRoute("UserBookingsPage", typeof(UserBookingsPage));
            Routing.RegisterRoute("SingerEditPage", typeof(SingerEditPage));

            Task.Run(async () =>
            {
                await Task.Delay(100); // Give Shell a moment to initialize
                var email = Preferences.Get("UserEmail", string.Empty);
                if (string.IsNullOrWhiteSpace(email))
                {
                    Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
                    await Shell.Current.GoToAsync("//LoginPage");
                }
            });
        }

        /// <summary>
        /// Enables flyout navigation for the application shell.
        /// </summary>
        public void EnableFlyout()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        }

        /// <summary>
        /// Disables flyout navigation for the application shell.
        /// </summary>
        public void DisableFlyout()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
        }
    }
}