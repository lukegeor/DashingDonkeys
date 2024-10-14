using Lib;

namespace Test;

public class CrazyCamelTests
{
    [Theory]
    [InlineData(Colors.Black)]
    [InlineData(Colors.White)]
    public void CrazyCamel_Constructor_GoodColor(Colors color)
    {
        // Act
        _ = new CrazyCamel(color, new TrackSpace());
    }

    [Theory]
    [InlineData(Colors.Red)]
    [InlineData(Colors.Blue)]
    [InlineData(Colors.Green)]
    [InlineData(Colors.Purple)]
    [InlineData(Colors.Yellow)]
    public void CrazyCamel_Constructor_BadColor(Colors color)
    {
        // Act
        Assert.Throws<ArgumentOutOfRangeException>(() => _ = new CrazyCamel(color, new TrackSpace()));
    }
}