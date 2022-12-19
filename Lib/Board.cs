namespace Lib;

public class Board
{
    public OverallWinnerBettingStack OverallWinnerBettingStack { get; }
    
    public OverallLoserBettingStack OverallLoserBettingStack { get; }
    
    public IEnumerable<OverallFinishBettingStack> OverallFinishBettingStacks => new OverallFinishBettingStack[] {
        OverallWinnerBettingStack,
        OverallLoserBettingStack
    };
    
    public Dictionary<Colors, BettingTicketStack> BettingTicketStacks { get; }

    public Track Track { get; }
    
    public int PyramidCardsRemaining { get; private set; }
    
    public List<DiceTent> DiceTents { get;  }
}