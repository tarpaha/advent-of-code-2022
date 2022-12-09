namespace day_2022_12_09;

public static class Solver
{
    private struct Position { public int x; public int y; }
    
    public static object Part1(Data data)
    {
        return Move(data, 2);
    }

    public static object Part2(Data data)
    {
        return null!;
    }
    
    private static int Move(Data data, int knotsAmount)
    {
        var knots = new Position[knotsAmount];
        for (var i = 0; i < knots.Length; i++)
            knots[i] = new Position { x = 0, y = 0 };
        
        var uniqueTailPositions = new HashSet<Position>();
        foreach (var step in data.Steps)
        {
            switch (step.Direction)
            {
                case Direction.Up:
                    knots[0].y += 1;
                    break;
                case Direction.Down:
                    knots[0].y -= 1;
                    break;
                case Direction.Left:
                    knots[0].x -= 1;
                    break;
                case Direction.Right:
                    knots[0].x += 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            var previousKnotMoveDirection = step.Direction;
            for (var i = 1; i < knots.Length; i++)
            {
                previousKnotMoveDirection = Follow(previousKnotMoveDirection, knots[i - 1], ref knots[i]);
            }
            uniqueTailPositions.Add(knots[^1]);
        }
        return uniqueTailPositions.Count;
    }

    private static Direction Follow(Direction ancestorMoveDirection, Position ancestor, ref Position knot)
    {
        var directionMoved = Direction.None;
        switch (ancestorMoveDirection)
        {
            case Direction.Up:
                if (ancestor.y - knot.y > 1)
                {
                    knot.y += 1;
                    directionMoved = Direction.Up;
                    if (knot.x < ancestor.x)
                    {
                        knot.x += 1;
                        directionMoved = Direction.UpRight;
                    }
                    else if (knot.x > ancestor.x)
                    {
                        knot.x -= 1;
                        directionMoved = Direction.UpLeft;
                    }
                }
                break;
            case Direction.Down:
                if (knot.y - ancestor.y > 1)
                {
                    knot.y -= 1;
                    directionMoved = Direction.Down;
                    if (knot.x < ancestor.x)
                    {
                        knot.x += 1;
                        directionMoved = Direction.DownRight;
                    }
                    else if (knot.x > ancestor.x)
                    {
                        knot.x -= 1;
                        directionMoved = Direction.DownLeft;
                    }
                }
                break;
            case Direction.Left:
                if (knot.x - ancestor.x > 1)
                {
                    knot.x -= 1;
                    directionMoved = Direction.Left;
                    if (knot.y < ancestor.y)
                    {
                        knot.y += 1;
                        directionMoved = Direction.UpLeft;
                    }
                    else if (knot.y > ancestor.y)
                    {
                        directionMoved = Direction.DownLeft;
                        knot.y -= 1;
                    }
                }
                break;
            case Direction.Right:
                if (ancestor.x - knot.x > 1)
                {
                    knot.x += 1;
                    directionMoved = Direction.Right;
                    if (knot.y < ancestor.y)
                    {
                        knot.y += 1;
                        directionMoved = Direction.UpRight;
                    }
                    else if (knot.y > ancestor.y)
                    {
                        knot.y -= 1;
                        directionMoved = Direction.DownRight;
                    }
                }
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(ancestorMoveDirection), ancestorMoveDirection, null);
        }
        return directionMoved;
    }
}