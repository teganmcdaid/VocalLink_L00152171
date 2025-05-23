using VocalLink_L00152171.Converters;

namespace VocalLink.Tests;
public class InverseBoolConverterTests
{
    [Fact]
    public void Convert_True_ReturnsFalse()
    {
        //check that true is converted to false
        var converter = new InverseBoolConverter();
        var result = converter.Convert(true, null, null, null);
        Assert.False((bool)result);
    }

    [Fact]
    public void Convert_False_ReturnsTrue()
    {
        //check that false is converted to true
        var converter = new InverseBoolConverter();
        var result = converter.Convert(false, null, null, null);
        Assert.True((bool)result);
    }

    [Fact]
    public void Convert_NonBool_ReturnsFalse()
    {
        //check if value is not bool
        var converter = new InverseBoolConverter();
        var result = converter.Convert("not a bool", null, null, null);
        Assert.False((bool)result);
    }
}

