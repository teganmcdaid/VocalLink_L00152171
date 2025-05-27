// <copyright file="DeveloperSettingsViewModel.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.ViewModels
{
    using System.Threading.Tasks;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using Microsoft.Maui.Storage;

    /// <summary>
    /// Developer settings view model for all developer settings logic.
    /// </summary>
    public partial class DeveloperSettingsViewModel : ObservableObject
    {
        [ObservableProperty]
        private string apiKey;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeveloperSettingsViewModel"/> class.
        /// </summary>
        public DeveloperSettingsViewModel()
        {
            this.LoadExistingKey();
        }

        private async void LoadExistingKey()
        {
            this.ApiKey = await SecureStorage.GetAsync("sendgrid_api_key");
        }

        [RelayCommand]
        private async Task SaveApiKey()
        {
            if (!string.IsNullOrWhiteSpace(this.ApiKey))
            {
                await SecureStorage.SetAsync("sendgrid_api_key", this.ApiKey);
                await Shell.Current.DisplayAlert("Success", "API key saved securely.", "OK");
            }
            else
            {
                await Shell.Current.DisplayAlert("Error", "API key cannot be empty.", "OK");
            }
        }
    }
}