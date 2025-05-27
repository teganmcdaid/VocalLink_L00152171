// <copyright file="IPreferencesWrapper.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Services
{
    /// <summary>
    /// wrapper interface for accessing user preferences.
    /// </summary>
    public interface IPreferencesWrapper
    {
        /// <summary>
        /// call method GetIsSinger.
        /// </summary>
        /// <returns>retrieves the user's preference.</returns>
        bool GetIsSinger();
    }
}
