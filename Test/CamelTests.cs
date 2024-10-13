using Lib;

namespace Test;

public class CamelTests
{
    public class TestCamel : Camel
    {
        public TestCamel(Colors color, TrackSpace trackSpace) : base(color, trackSpace) {}
    }

    private Colors _color;
    private TrackSpace _trackSpace;
    private Camel _sut;

    public CamelTests()
    {
        _trackSpace = new TrackSpace();
        _color = Colors.Red;
        _sut = new TestCamel(_color, _trackSpace);
        _trackSpace.BottomCamel = _sut;
    }

    [Fact]
    public void Camel_Constructor_Nominal()
    {
        // Constructor is called in test setup
    }

    [Fact]
    public void Camel_MoveForward_SingleCamelToEmptySpace()
    {
        // Arrange
        var newTrackSpace = new TrackSpace();
        newTrackSpace.BottomCamel = null;

        // Act
        _sut.MoveForward(newTrackSpace);

        // Assert
        Assert.Null(_trackSpace.BottomCamel);
        Assert.Same(newTrackSpace, _sut.TrackSpace);
        Assert.Same(_sut, newTrackSpace.BottomCamel);
    }
}