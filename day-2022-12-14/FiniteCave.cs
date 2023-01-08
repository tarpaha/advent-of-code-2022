namespace day_2022_12_14;

public class FiniteCave : Cave
{
    public FiniteCave(Data data, int initialX, int initialY) : base(data, initialX, initialY, GetWidthAndHeight)
    {
        FillFloor();
    }
    
    private static (int w, int h, int xMin) GetWidthAndHeight(int initialX, int initialY, int xMin, int yMin, int xMax, int yMax)
    {
        var height = yMax - yMin + 1;
        height += 2;

        xMin = initialX - (height - 1) - 1;
        xMax = initialX + (height - 1) + 1;
        var width = xMax - xMin + 1;
        
        return (width, height, xMin);
    }

    private void FillFloor()
    {
        for (var x = 0; x < Width; x++)
            SetTile(x, Height - 1,  Material.Rock);
    }

    public void FillWithSand()
    {
        var (initialX, initialY) = InitialTile;
        SetTile(initialX, initialY, Material.Sand);
        
        for (var y = 1; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if(GetTile(x, y) != Material.Air)
                    continue;
                if ((x > 0 && GetTile(x - 1, y - 1) == Material.Sand) ||
                    (GetTile(x, y - 1) == Material.Sand) ||
                    (x < Width - 1 && GetTile(x + 1, y - 1) == Material.Sand))
                {
                    SetTile(x, y, Material.Sand);
                }
            }
        }
    }

    public int SandAmount()
    {
        var amount = 0;
        for(var y = 0; y < Height; y++)
            for(var x = 0; x < Width; x++)
                if (GetTile(x, y) == Material.Sand)
                    amount += 1;
        return amount;
    }
}