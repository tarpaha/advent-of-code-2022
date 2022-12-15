namespace day_2022_12_11;

public class Item
{
    public int WorryLevel;
    public Item(int worryLevel)
    {
        WorryLevel = worryLevel;
    }

    public void ApplyOperation(Operation operation)
    {
        WorryLevel = operation switch
        {
            Operation.Add op => WorryLevel + op.X, 
            Operation.Mul op => WorryLevel * op.X,
            Operation.Square => WorryLevel * WorryLevel,
            _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
        };
    }

    public void ReduceWorry()
    {
        WorryLevel /= 3;
    }

    public override string ToString()
    {
        return WorryLevel.ToString();
    }

    public void InitRemainders(List<int> dividers)
    {
        _remainders = dividers.ToDictionary(divider => divider, divider => WorryLevel % divider);
    }
    
    public void ApplyOperationOnRemainders(Operation operation)
    {
        foreach (var divider in _remainders!.Keys)
        {
            var remainder = _remainders[divider];
            _remainders[divider] = operation switch
            {
                Operation.Add op => (remainder + op.X) % divider,
                Operation.Mul op => (remainder * op.X) % divider,
                Operation.Square => (remainder * remainder) % divider,
                _ => throw new ArgumentOutOfRangeException(nameof(operation), operation, null)
            };
        }
    }

    private Dictionary<int, int>? _remainders;
    public int Remainder(int divider) => _remainders![divider];
}