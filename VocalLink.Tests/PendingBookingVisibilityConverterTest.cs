// <copyright file="PendingBookingVisibilityConverterTest.cs" company="Tegan McDaid">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace VocalLink.Tests
{
    using Moq;
    using VocalLink_L00152171.Converters;
    using VocalLink_L00152171.Model;
    using VocalLink_L00152171.Services;

    /// <summary>
    /// This class is used to toggle boolean based on value input e.g. true returns false.
    /// </summary>
    public class PendingBookingVisibilityConverterTest
    {
        /// <summary>
        /// The tests that pending is true and is singer is true and returns true.
        /// </summary>
        [Fact]
        public void Convert_PendingAndIsSinger_ReturnsTrue()
        {
            var mockPref = new Mock<IPreferencesWrapper>();
            mockPref.Setup(p => p.GetIsSinger()).Returns(true);
            var booking = new Booking { Status = "Pending" };

            var converter = new PendingBookingVisibilityConverter(mockPref.Object);
            var result = converter.Convert(booking, null, null, null);

            Assert.True((bool)result);
        }

        /// <summary>
        /// This tests that pending is true and is singer is false and returns false.
        /// </summary>
        [Fact]
        public void Convert_PendingButNotSinger_ReturnsFalse()
        {
            var mockPref = new Mock<IPreferencesWrapper>();
            mockPref.Setup(p => p.GetIsSinger()).Returns(false);
            var booking = new Booking { Status = "Pending" };

            var converter = new PendingBookingVisibilityConverter(mockPref.Object);
            var result = converter.Convert(booking, null, null, null);

            Assert.False((bool)result);
        }

        /// <summary>
        /// This tests that booking is null and returns false.
        /// </summary>
        [Fact]
        public void Convert_NullBooking_ReturnsFalse()
        {
            var mockPref = new Mock<IPreferencesWrapper>();
            mockPref.Setup(p => p.GetIsSinger()).Returns(true);

            var converter = new PendingBookingVisibilityConverter(mockPref.Object);
            var result = converter.Convert(null, null, null, null);

            Assert.False((bool)result);
        }
    }
}
