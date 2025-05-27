// <copyright file="StatusToColourConverterTests.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink.Tests
{
    using VocalLink_L00152171.Converters;

    /// <summary>
    /// This class is used to toggle boolean based on value input e.g. true returns false.
    /// </summary>
    public class StatusToColourConverterTests
    {
        private readonly StatusToColourConverter converter = new ();

        /// <summary>
        /// This test checks staus is available and returns green.
        /// </summary>
        [Fact]
        public void Convert_StatusAvailable_ReturnsGreen()
        {
            var converter = new StatusToColourConverter();
            var result = (Color)converter.Convert("Available", null, null, null);
            Assert.Equal(Colors.Green, result);
        }

        /// <summary>
        /// This test checks staus is pending and returns orange..
        /// </summary>
        [Fact]
        public void Convert_StatusPending_ReturnsOrange()
        {
            var converter = new StatusToColourConverter();
            var result = (Color)converter.Convert("Pending", null, null, null);
            Assert.Equal(Colors.Orange, result);
        }

        /// <summary>
        /// This test checks staus is booked and returns blue.
        /// </summary>
        [Fact]
        public void Convert_StatusBooked_ReturnsBlue()
        {
            var converter = new StatusToColourConverter();
            var result = (Color)converter.Convert("Booked", null, null, null);
            Assert.Equal(Colors.Blue, result);
        }

        /// <summary>
        /// This test checks staus is declined and returns red.
        /// </summary>
        [Fact]
        public void Convert_StatusDeclined_ReturnsRed()
        {
            var converter = new StatusToColourConverter();
            var result = (Color)converter.Convert("Declined", null, null, null);
            Assert.Equal(Colors.Red, result);
        }

        /// <summary>
        /// This test checks staus is Unknown and returns light gray.
        /// </summary>
        [Fact]
        public void Convert_StatusUnknown_ReturnsLightGray()
        {
            var converter = new StatusToColourConverter();
            var result = (Color)converter.Convert("Unknown", null, null, null);
            Assert.Equal(Colors.LightGray, result);
        }

        /// <summary>
        /// This test checks staus is null and returns light gray.
        /// </summary>
        [Fact]
        public void Convert_StatusNull_ReturnsLightGray()
        {
            var converter = new StatusToColourConverter();
            var result = (Color)converter.Convert(null, null, null, null);
            Assert.Equal(Colors.LightGray, result);
        }
    }
}