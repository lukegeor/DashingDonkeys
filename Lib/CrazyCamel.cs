namespace Lib;

public class CrazyCamel : Camel
{
    public override TrackSpace? Move(TrackSpace current, int spaces)
    {
        var newSpace = current;
        for (var i = 0; i < spaces; i++)
        {
            newSpace = newSpace?.Previous;
        }
        
        OnLandedOnTrackSpace(newSpace);
        return newSpace;
    }
}