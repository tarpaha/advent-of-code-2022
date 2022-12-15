namespace day_2022_12_11;

public record ItemData(int WorryLevel);

public abstract record Operation
{
    public record Add(int X) : Operation;
    public record Mul(int X) : Operation;
    public record Square() : Operation;
}

public record MonkeyData(IEnumerable<ItemData> Items, Operation Operation, int Divider, int MonkeyTrue, int MonkeyFalse);

public record Data(IEnumerable<MonkeyData> MonkeyDatas);