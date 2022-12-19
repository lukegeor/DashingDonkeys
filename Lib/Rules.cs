namespace Lib;

public class Rules
{
    public List<(int FirstPlaceWins, int SecondPlaceWins, int DoesntPlaceLoses)> BettingTicketStacks => new()
    {
        (2, 1, 1),
        (2, 1, 1),
        (3, 1, 1),
        (5, 1, 1)
    };
}