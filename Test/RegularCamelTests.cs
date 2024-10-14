using Lib;

namespace Test;

public class RegularCamelTests
{
    [Theory]
    [InlineData(Colors.Red)]
    [InlineData(Colors.Blue)]
    [InlineData(Colors.Green)]
    [InlineData(Colors.Purple)]
    [InlineData(Colors.Yellow)]
    public void RegularCamel_Constructor_GoodColor(Colors color)
    {
        // Act
        _ = new RegularCamel(color, new TrackSpace());
    }

    [Theory]
    [InlineData(Colors.Black)]
    [InlineData(Colors.White)]
    public void RegularCamel_Constructor_BadColor(Colors color)
    {
        // Act
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new RegularCamel(color, new TrackSpace()));
    }
}