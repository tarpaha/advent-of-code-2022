namespace day_2022_12_05;

public record Stack(IEnumerable<char> Crates);
public record Move(int Count, int From, int To);
public record Data(IEnumerable<Stack> Stacks, IEnumerable<Move> Moves);