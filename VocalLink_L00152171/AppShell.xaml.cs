using VocalLink_L00152171.Views;

namespace VocalLink_L00152171
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("LoginPage", typeof(LoginPage));
            Routing.RegisterRoute("SignUpPage", typeof(SignUpPage));
            Routing.RegisterRoute("SingerSetupPage", typeof(SingerSetupPage));
            Routing.RegisterRoute("HomePage", typeof(HomePage));
            Routing.RegisterRoute("SingerProfilePage", typeof(SingerProfilePage));
            Routing.RegisterRoute("UserBookingsPage", typeof(UserBookingsPage));

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
        public void EnableFlyout()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Flyout;
        }

        public void DisableFlyout()
        {
            Shell.Current.FlyoutBehavior = FlyoutBehavior.Disabled;
        }
    }
}
