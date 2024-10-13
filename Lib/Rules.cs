using System.Collections.Generic;

namespace Lib;

public class Rules
{
    public IReadOnlyList<(int FirstPlaceWins, int SecondPlaceWins, int DoesntPlaceLoses)> BettingTicketStacks { get; }

    public int NumberOfRegularBoardSpaces { get; }

    public Rules()
    {
        BettingTicketStacks = new List<(int, int, int)>()
        {
            (2, 1, 1),
            (2, 1, 1),
            (3, 1, 1),
            (5, 1, 1)
        };
        NumberOfRegularBoardSpaces = 18;
    }
}
