namespace Lib;

public class Track(IReadOnlyList<TrackSpace> trackSpaces)
{
    public IReadOnlyList<TrackSpace> TrackSpaces { get; } = trackSpaces;
}
