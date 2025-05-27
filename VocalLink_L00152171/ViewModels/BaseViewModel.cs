// <copyright file="BaseViewModel.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.ViewModels
{
    using CommunityToolkit.Mvvm.ComponentModel;

    /// <summary>
    /// base view model for all view models in the application.
    /// </summary>
    public partial class BaseViewModel : ObservableObject
    {
        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        private bool isBusy;

        [ObservableProperty]
        private string title;

        /// <summary>
        /// Initializes a new instance of the <see cref="BaseViewModel"/> class.
        /// </summary>
        public BaseViewModel()
        {
        }

        /// <summary>
        /// Gets a value indicating whether the view model is busy or not.
        /// </summary>
        public bool IsNotBusy => !this.IsBusy;
    }
}