using Moq;
using VocalLink_L00152171.Converters;
using VocalLink_L00152171.Model;
using VocalLink_L00152171.Services;

namespace VocalLink.Tests;
public class PendingBookingVisibilityConverterTest
{
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
