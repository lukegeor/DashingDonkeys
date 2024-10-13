namespace Lib;

public class TrackSpace
{
    public TrackSpace Previous { get; set; }
    
    public TrackSpace Next { get; set; }

    public Camel? BottomCamel { get; set; }

    public Camel? GetTopCamel()
    {
        Camel? topCamel = BottomCamel;
        while (topCamel?.CamelOnTopOfThisCamel is not null)
        {
            topCamel = topCamel.CamelOnTopOfThisCamel;
        }

        return topCamel;
    }
}
