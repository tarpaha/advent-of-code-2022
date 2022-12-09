namespace day_2022_12_09;

public static class Solver
{
    private struct Position { public int x; public int y; }
    
    public static object Part1(Data data)
    {
        var head = new Position { x = 0, y = 0 };
        var tail = new Position { x = 0, y = 0 };
        var uniqueTailPositions = new HashSet<Position>();
        foreach (var step in data.Steps)
        {
            MakeStep(step.Direction, ref head, ref tail);
            uniqueTailPositions.Add(tail);
        }
        return uniqueTailPositions.Count;
    }

    private static void MakeStep(Direction direction, ref Position head, ref Position tail)
    {
        switch (direction)
        {
            case Direction.Up:
                head.y += 1;
                if (head.y - tail.y > 1)
                {
                    tail.y += 1;
                    if (tail.x < head.x)
                        tail.x += 1;
                    else if (tail.x > head.x)
                        tail.x -= 1;
                }
                break;
            case Direction.Down:
                head.y -= 1;
                if (tail.y - head.y > 1)
                {
                    tail.y -= 1;
                    if (tail.x < head.x)
                        tail.x += 1;
                    else if (tail.x > head.x)
                        tail.x -= 1;
                }
                break;
            case Direction.Left:
                head.x -= 1;
                if (tail.x - head.x > 1)
                {
                    tail.x -= 1;
                    if (tail.y < head.y)
                        tail.y += 1;
                    else if (tail.y > head.y)
                        tail.y -= 1;
                }
                break;
            case Direction.Right:
                head.x += 1;
                if (head.x - tail.x > 1)
                {
                    tail.x += 1;
                    if (tail.y < head.y)
                        tail.y += 1;
                    else if (tail.y > head.y)
                        tail.y -= 1;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
        }
    }

    public static object Part2(Data data)
    {
        return null!;
    }
}