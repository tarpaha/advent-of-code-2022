namespace day_2022_12_09;

public enum Direction { None, Up, Down, Left, Right, UpLeft, UpRight, DownLeft, DownRight }
public record Step(Direction Direction);
public record Data(IEnumerable<Step> Steps);