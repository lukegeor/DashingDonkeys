namespace Lib;

public class CrazyCamel : Camel
{
    public CrazyCamel(Colors color, TrackSpace trackSpace) : base(color, trackSpace)
    {
        if (color > 0)
        {
            throw new ArgumentOutOfRangeException(nameof(color), $"Crazy camel cannot have a color of {color}.");
        }
    }
}