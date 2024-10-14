namespace Lib;

public abstract class Camel
{
    public class StackLandedOnEventArgs : EventArgs
    {
        public TrackSpace LandedOn { get; set; }

        public StackLandedOnEventArgs(TrackSpace landedOn)
        {
            LandedOn = landedOn;
        }
    }
    
    public event EventHandler<StackLandedOnEventArgs>? StackLandedOn;

    public TrackSpace TrackSpace { get; set; }
    public Colors Color { get; set; }
    public Camel? CamelOnTopOfThisCamel { get; set; }
    public Camel? CamelBelowThisCamel { get; set; }

    public Camel(Colors color, TrackSpace trackSpace)
    {
        Color = color;
        TrackSpace = trackSpace;
    }

    public void MoveForward(TrackSpace newTrackSpace, bool originalMove = true)
    {
        // If this is the original camel being moved:
        // - Don't need new trackspace yet
        //   - Set the below camel's above pointer to null
        //   - If this camel was the old trackspace's bottom camel, set the old trackspace's bottom camel to null
        // - Need the new trackspace for
        //   - Set the camel below pointer to the new track space's top camel
        //   - Set the top camel on the new space's above pointer to this camel
        //   - If the new trackspace's bottom camel pointer was null, set it to this camel

        // For all moves, set this camel's trackspace to the new trackspace, and fire the event.

        if (originalMove)
        {
            if (CamelBelowThisCamel is not null)
            {
                CamelBelowThisCamel.CamelOnTopOfThisCamel = null;
            }

            if (TrackSpace.BottomCamel == this)
            {
                TrackSpace.BottomCamel = null;
            }

            var oldTopCamelOnNewSpace = newTrackSpace.GetTopCamel();

            CamelBelowThisCamel = oldTopCamelOnNewSpace;

            if (oldTopCamelOnNewSpace is not null)
            {
                oldTopCamelOnNewSpace.CamelOnTopOfThisCamel = this;
            }

            if (newTrackSpace.BottomCamel is null)
            {
                newTrackSpace.BottomCamel = this;
            }
        }

        TrackSpace = newTrackSpace;
        CamelOnTopOfThisCamel?.MoveForward(newTrackSpace, false);
        OnCamelStackLandedOn(newTrackSpace);
    }

    private void OnCamelStackLandedOn(TrackSpace newTrackSpace)
    {
        StackLandedOn?.Invoke(this, new StackLandedOnEventArgs(newTrackSpace));
    }
}
