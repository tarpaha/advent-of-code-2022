namespace day_2022_12_10;

public abstract record Instruction
{
    public record Noop : Instruction;
    public record AddX(long V) : Instruction;
}

public record Data(IEnumerable<Instruction> Instructions);