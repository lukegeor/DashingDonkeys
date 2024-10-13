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
        if (originalMove)
        {
            if (CamelBelowThisCamel?.CamelOnTopOfThisCamel is not null)
            {
                CamelBelowThisCamel.CamelOnTopOfThisCamel = null;
            }

            if (TrackSpace.BottomCamel == this)
            {
                TrackSpace.BottomCamel = null;
            }
        }

        TrackSpace = newTrackSpace;
        CamelOnTopOfThisCamel?.MoveForward(newTrackSpace, false);

        if (originalMove)
        {
            var oldTopCamel = newTrackSpace.GetTopCamel();
            if (oldTopCamel is not null)
            {
                oldTopCamel.CamelOnTopOfThisCamel = this;
            }
            CamelBelowThisCamel = oldTopCamel;
            OnCamelStackLandedOn(newTrackSpace);
        }
    }

    private void OnCamelStackLandedOn(TrackSpace newTrackSpace)
    {
        StackLandedOn?.Invoke(this, new StackLandedOnEventArgs(newTrackSpace));
    }
}
