
namespace VocalLink_L00152171.Services
{
    public class PreferencesWrapper : IPreferencesWrapper
    {
        public bool GetIsSinger()
        {
            return Preferences.Default.Get("IsSinger", false);
        }
    }
}
