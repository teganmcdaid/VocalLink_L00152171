// <copyright file="Booking.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink_L00152171.Model
{
    using Microsoft.Maui.Controls;
    using SQLite;

    /// <summary>
    /// Model for storing Bookings.
    /// </summary>
    public class Booking
    {
        /// <summary>
        /// Gets or sets booking id.
        /// </summary>
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets Singer email.
        /// </summary>
        public string SingerEmail { get; set; }

        /// <summary>
        /// Gets or sets Singers name .
        /// </summary>
        public string SingerName { get; set; }

        /// <summary>
        /// Gets or sets Business email .
        /// </summary>
        public string BusinessEmail { get; set; }

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the status of booking.
        /// </summary>
        public string Status { get; set; }
    }
}