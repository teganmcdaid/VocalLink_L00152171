// <copyright file="Singer.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Model
{
    using SQLite;

    /// <summary>
    /// Model for storing Singers.
    /// </summary>
    public class Singer
    {
        /// <summary>
        /// Gets or sets User Email .
        /// </summary>
        [PrimaryKey]
        public string UserEmail { get; set; }

        /// <summary>
        /// Gets or sets the Singers Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets Genre.
        /// </summary>
        public string Genre { get; set; }

        /// <summary>
        /// Gets or sets Location.
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Gets or sets About Me Section.
        /// </summary>
        public string AboutMe { get; set; }
    }
}