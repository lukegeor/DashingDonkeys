namespace Lib;

public class RegularCamel : Camel
{
    public override TrackSpace? Move(TrackSpace current, int spaces)
    {
        var newSpace = current;
        for (var i = 0; i < spaces; i++)
        {
            newSpace = newSpace?.Next;
        }

        return newSpace;
    }
}