namespace day_2022_12_11;

public record ItemData(long WorryLevel);

public abstract record Operation
{
    public record Add(long X) : Operation;
    public record Mul(long X) : Operation;
    public record Square() : Operation;
}

public record MonkeyData(IEnumerable<ItemData> Items, Operation Operation, long Divider, int MonkeyTrue, int MonkeyFalse);

public record Data(IEnumerable<MonkeyData> MonkeyDatas);