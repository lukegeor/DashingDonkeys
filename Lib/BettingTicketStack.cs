namespace Lib;

public class BettingTicketStack
{
    private readonly Rules _rules;
    private readonly Colors _color;
    private readonly Stack<BettingTicket> _stack;

    public BettingTicketStack(Rules rules, Colors color)
    {
        _rules = rules;
        _color = color;
        _stack = new Stack<BettingTicket>();
    }

    public bool HasTickets => _stack.Any();

    public void Reset()
    {
        _stack.Clear();
        foreach (var stackSpec in _rules.BettingTicketStacks)
        {
            _stack.Push(new BettingTicket()
            {
                FirstPlaceWins = stackSpec.FirstPlaceWins,
                SecondPlaceWins = stackSpec.SecondPlaceWins,
                DoesntPlaceLoses = stackSpec.DoesntPlaceLoses,
                Color = _color
            });
        }
    }

    public BettingTicket TryTakeTopTicket()
    {
        if (_stack.TryPop(out var topTicket))
        {
            return topTicket;
        }

        throw new EmptyBettingTicketStackException(_color);
    }

    public class EmptyBettingTicketStackException : Exception
    {
        public Colors Color { get; }

        public EmptyBettingTicketStackException(Colors color)
        {
            Color = color;
        }
    }
}
