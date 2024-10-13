namespace Lib;

public class BettingTicket
{
    public Colors Color { get; set; }
    public int FirstPlaceWins { get; set; }
    public int SecondPlaceWins { get; set; }
    public int DoesntPlaceLoses { get; set; }
    public Player? Owner { get; set; }
}
