namespace day_2022_12_09;

public enum Direction { Up, Down, Left, Right }
public record Step(Direction Direction);
public record Data(IEnumerable<Step> Steps);