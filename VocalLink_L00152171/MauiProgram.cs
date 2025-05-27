using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using VocalLink_L00152171.Services;

namespace VocalLink_L00152171
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        { 
            // Register the Syncfusion license key
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Ngo9BigBOggjHTQxAR8/V1NNaF5cXmBCf1FpRmJGdld5fUVHYVZUTXxaS00DNHVRdkdmWXped3VSQmJeVExxVktWYUA=");

            var builder = MauiApp.CreateBuilder();

            builder.ConfigureSyncfusionCore();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<IPreferencesWrapper, PreferencesWrapper>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
