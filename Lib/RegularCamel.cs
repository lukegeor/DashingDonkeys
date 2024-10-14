namespace Lib;

public class RegularCamel : Camel
{
    public RegularCamel(Colors color, TrackSpace trackSpace) : base(color, trackSpace)
    {
        if (color < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(color), $"Regular camel cannot have a color of {color}.");
        }
    }
}
