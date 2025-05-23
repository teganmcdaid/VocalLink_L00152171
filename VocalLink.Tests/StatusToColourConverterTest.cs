using VocalLink_L00152171.Converters;

namespace VocalLink.Tests;
public class StatusToColourConverterTests
{
    private readonly StatusToColorConverter converter = new();

    [Fact]
    //check if availble returns green
    public void Convert_StatusAvailable_ReturnsGreen()
    {
        var converter = new StatusToColorConverter();
        var result = (Color)converter.Convert("Available", null, null, null);
        Assert.Equal(Colors.Green, result);
    }

    [Fact]
    public void Convert_StatusPending_ReturnsOrange()
    {
        //check if pending returns orange
        var converter = new StatusToColorConverter();
        var result = (Color)converter.Convert("Pending", null, null, null);
        Assert.Equal(Colors.Orange, result);
    }

    [Fact]
    //check if booked returns blue
    public void Convert_StatusBooked_ReturnsBlue()
    {
        var converter = new StatusToColorConverter();
        var result = (Color)converter.Convert("Booked", null, null, null);
        Assert.Equal(Colors.Blue, result);
    }

    [Fact]
    //check if declined returns red
    public void Convert_StatusDeclined_ReturnsRed()
    {
        var converter = new StatusToColorConverter();
        var result = (Color)converter.Convert("Declined", null, null, null);
        Assert.Equal(Colors.Red, result);
    }

    [Fact]
    //check if unknown returns light gray
    public void Convert_StatusUnknown_ReturnsLightGray()
    {
        var converter = new StatusToColorConverter();
        var result = (Color)converter.Convert("Unknown", null, null, null);
        Assert.Equal(Colors.LightGray, result);
    }

    [Fact]
    //check if null returns light gray
    public void Convert_StatusNull_ReturnsLightGray()
    {
        var converter = new StatusToColorConverter();
        var result = (Color)converter.Convert(null, null, null, null);
        Assert.Equal(Colors.LightGray, result);
    }
}

