namespace day_2022_12_14;

public record Path(IEnumerable<(int x, int y)> Coords)
{
    public override string ToString()
    {
        return string.Join(" -> ", Coords.Select(coord => $"{coord.x},{coord.y}"));
    }
}

public record Data(IEnumerable<Path> Paths)
{
    public override string ToString()
    {
        return string.Join(Environment.NewLine, Paths);
    }
}