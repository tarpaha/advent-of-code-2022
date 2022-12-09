namespace day_2022_12_09;

public static class Solver
{
    private struct Position { public int x; public int y;
        public override string ToString()
        {
            return $"{x}, {y}";
        }
    }
    
    public static object Part1(Data data)
    {
        return Move(data, 2);
    }

    public static object Part2(Data data)
    {
        return Move(data, 10);
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

        /*var (w, h) = (26, 21);
        var (xc, yc) = (11, 5);
        for (var y = h - 1; y >= 0; y--)
        {
            for (var x = 0; x < w; x++)
            {
                var n = Array.FindIndex(knots, pos => pos.x == x - xc && pos.y == y - yc);
                Console.Write(n switch
                {
                    -1 => ".",
                     0 => "H",
                     _  => n.ToString()
                });
            }
            Console.WriteLine();
        }*/
        
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
            case Direction.UpLeft:
                if (Math.Abs(ancestor.x - knot.x) > 1 && Math.Abs(ancestor.y - knot.y) > 1)
                {
                    knot.x -= 1;
                    knot.y += 1;
                    directionMoved = Direction.UpLeft;
                }
                else if (Math.Abs(ancestor.x - knot.x) > 1)
                {
                    if (ancestor.y == knot.y)
                    {
                        knot.x -= 1;
                        directionMoved = Direction.Left;
                    }
                    else
                    {
                        knot.x -= 1;
                        knot.y += 1;
                        directionMoved = Direction.UpLeft;
                    }
                }
                else if (Math.Abs(ancestor.y - knot.y) > 1)
                {
                    if (ancestor.x == knot.x)
                    {
                        knot.y += 1;
                        directionMoved = Direction.Up;
                    }
                    else
                    {
                        knot.x -= 1;
                        knot.y += 1;
                        directionMoved = Direction.UpLeft;
                    }
                }
                break;
            case Direction.UpRight:
                if (Math.Abs(ancestor.x - knot.x) > 1 && Math.Abs(ancestor.y - knot.y) > 1)
                {
                    knot.x += 1;
                    knot.y += 1;
                    directionMoved = Direction.UpRight;
                }
                else if (Math.Abs(ancestor.x - knot.x) > 1)
                {
                    if (ancestor.y == knot.y)
                    {
                        knot.x += 1;
                        directionMoved = Direction.Right;
                    }
                    else
                    {
                        knot.x += 1;
                        knot.y += 1;
                        directionMoved = Direction.UpRight;
                    }
                }
                else if (Math.Abs(ancestor.y - knot.y) > 1)
                {
                    if (ancestor.x == knot.x)
                    {
                        knot.y += 1;
                        directionMoved = Direction.Up;
                    }
                    else
                    {
                        knot.x += 1;
                        knot.y += 1;
                        directionMoved = Direction.UpRight;
                    }
                }
                break;
            case Direction.DownLeft:
                if (Math.Abs(ancestor.x - knot.x) > 1 && Math.Abs(ancestor.y - knot.y) > 1)
                {
                    knot.x -= 1;
                    knot.y -= 1;
                    directionMoved = Direction.DownLeft;
                }
                else if (Math.Abs(ancestor.x - knot.x) > 1)
                {
                    if (ancestor.y == knot.y)
                    {
                        knot.x -= 1;
                        directionMoved = Direction.Left;
                    }
                    else
                    {
                        knot.x -= 1;
                        knot.y -= 1;
                        directionMoved = Direction.DownLeft;
                    }
                }
                else if (Math.Abs(ancestor.y - knot.y) > 1)
                {
                    if (ancestor.x == knot.x)
                    {
                        knot.y -= 1;
                        directionMoved = Direction.Down;
                    }
                    else
                    {
                        knot.x -= 1;
                        knot.y -= 1;
                        directionMoved = Direction.DownLeft;
                    }
                }
                break;
            case Direction.DownRight:
                if (Math.Abs(ancestor.x - knot.x) > 1 && Math.Abs(ancestor.y - knot.y) > 1)
                {
                    knot.x += 1;
                    knot.y -= 1;
                    directionMoved = Direction.DownRight;
                }
                else if (Math.Abs(ancestor.x - knot.x) > 1)
                {
                    if (ancestor.y == knot.y)
                    {
                        knot.x += 1;
                        directionMoved = Direction.Right;
                    }
                    else
                    {
                        knot.x += 1;
                        knot.y -= 1;
                        directionMoved = Direction.DownRight;
                    }
                }
                else if (Math.Abs(ancestor.y - knot.y) > 1)
                {
                    if (ancestor.x == knot.x)
                    {
                        knot.y -= 1;
                        directionMoved = Direction.Down;
                    }
                    else
                    {
                        knot.x += 1;
                        knot.y -= 1;
                        directionMoved = Direction.DownRight;
                    }
                }
                break;
            case Direction.None:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(ancestorMoveDirection), ancestorMoveDirection, null);
        }
        return directionMoved;
    }
}