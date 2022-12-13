namespace day_2022_12_11;

public class Item
{
    public long WorryLevel;
    public Item(long worryLevel)
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
}