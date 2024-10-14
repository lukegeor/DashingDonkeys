namespace Lib;

public class Track
{
    public IReadOnlyList<TrackSpace> TrackSpaces { get; }

    public Track(IReadOnlyList<TrackSpace> trackSpaces)
    {
        TrackSpaces = trackSpaces;
    }
}
