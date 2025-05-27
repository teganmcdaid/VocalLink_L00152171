// <copyright file="PreferencesWrapper.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Services
{
    /// <summary>
    /// wrapper for rerieving user preferences.
    /// </summary>
    public class PreferencesWrapper : IPreferencesWrapper
    {
        /// <summary>
        /// Get user prefernces set to false by default.
        /// </summary>
        /// <returns> returns user prefernces for IsSinger.</returns>
        public bool GetIsSinger()
        {
            return Preferences.Default.Get("IsSinger", false);
        }
    }
}
