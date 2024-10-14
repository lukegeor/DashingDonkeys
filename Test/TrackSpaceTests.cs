using Lib;

namespace Test;

public class TrackSpaceTests
{
    private TrackSpace _sut;

    public TrackSpaceTests()
    {
        _sut = new();
    }

    [Fact]
    public void TrackSpace_Constructor_Nominal()
    {
        // Constructor is called in test setup
    }

    [Fact]
    public void TrackSpace_GetTopCamel_Empty()
    {
        // Act
        var returnedCamel = _sut.GetTopCamel();

        // Assert
        Assert.Null(returnedCamel);
    }

    [Fact]
    public void TrackSpace_GetTopCamel_OneCamel()
    {
        // Arrange
        var singleCamel = new RegularCamel(Colors.Red, _sut);
        _sut.BottomCamel = singleCamel;

        // Act
        var returnedCamel = _sut.GetTopCamel();

        // Assert
        Assert.Same(singleCamel, returnedCamel);
    }

    [Fact]
    public void TrackSpace_GetTopCamel_MultipleCamels()
    {
        // Arrange
        var bottomCamel = new RegularCamel(Colors.Red, _sut);
        var topCamel = new RegularCamel(Colors.Blue, _sut);
        bottomCamel.CamelOnTopOfThisCamel = topCamel;
        topCamel.CamelBelowThisCamel = bottomCamel;
        _sut.BottomCamel = bottomCamel;

        // Act
        var returnedCamel = _sut.GetTopCamel();

        // Assert
        Assert.Same(topCamel, returnedCamel);
    }
}