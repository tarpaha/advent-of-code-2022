namespace day_2022_12_04;

public record Pair(int Min, int Max);
public record Data(IEnumerable<(Pair first, Pair second)> Pairs);