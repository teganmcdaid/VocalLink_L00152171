// <copyright file="DateCell.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Model
{
    using CommunityToolkit.Mvvm.ComponentModel;

    /// <summary>
    /// Model for storing Date Cell.
    /// </summary>
    public partial class DateCell : ObservableObject
    {
        [ObservableProperty]
        private DateTime date;
        [ObservableProperty]
        private string status;

        /// <summary>
        /// Gets a value indicating whether the date cell is available.
        /// </summary>
        public bool IsAvailable => this.Status == "Available";
    }
}