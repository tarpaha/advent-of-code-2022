namespace day_2022_12_14;

public class InfiniteCave : Cave
{
    public InfiniteCave(Data data, int initialX, int initialY) : base(data, initialX, initialY, GetWidthAndHeight)
    {
    }

    private static (int w, int h, int xMin) GetWidthAndHeight(int initialX, int initialY, int xMin, int yMin, int xMax, int yMax)
    {
        return (xMax - xMin + 1, yMax - yMin + 1, xMin);
    }

    public bool DropSand()
    {
        var (x, y) = InitialTile;
        while (true)
        {
            if (GetTile(x, y + 1) == Material.Air)
            {
                y += 1;
                if (y == Height)
                    return false;
                continue;
            }
            if (GetTile(x - 1, y + 1) == Material.Air)
            {
                x -= 1;
                y += 1;
                if (x == 0 || y == Height)
                    return false;
                continue;
            }
            if (GetTile(x + 1, y + 1) == Material.Air)
            {
                x += 1;
                y += 1;
                if (x == Width || y == Height)
                    return false;
                continue;
            }
            break;
        }
        SetTile(x, y, Material.Sand);
        return true;
    }
}