// <copyright file="User.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Model
{
    using SQLite;

    /// <summary>
    /// Model for storing User.
    /// </summary>
    public class User
    {
        /// <summary>
        /// Gets or sets user email address .
        /// </summary>
        [PrimaryKey]
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets user password .
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether user is singer.
        /// </summary>
        public bool IsSinger { get; set; }
    }
}
