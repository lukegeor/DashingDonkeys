namespace Lib;

public abstract class Camel
{
    public event EventHandler<TrackSpace?>? LandedOn;
    public abstract TrackSpace? Move(TrackSpace current, int spaces);

    protected void OnLandedOnTrackSpace(TrackSpace newSpace)
    {
        LandedOn?.Invoke(this, newSpace);
    }
}