#pragma warning disable CA1416

using System.Drawing;
using System.Drawing.Imaging;

namespace day_2022_12_14.img;

public class Image
{
    public static void GenerateFromTiles(int width, int height, int tileWidth, int tileHeight, Func<int, int, (int, int, int)> colorFromTile, string filename)
    {
        var bitmap = new Bitmap(
            width * tileWidth,
            height * tileHeight,
            PixelFormat.Format24bppRgb);

        using var gr = Graphics.FromImage(bitmap);
        gr.Clear(Color.Black);
        
        for (var y = 0; y < height; y++)
        for (var x = 0; x < width; x++)
        {
            var (r, g, b) = colorFromTile(x, y);
            gr.FillRectangle(new SolidBrush(Color.FromArgb(255, r, g, b)), x * tileWidth, y * tileHeight, tileWidth, tileHeight);
        }
        
        bitmap.Save(filename, ImageFormat.Png);
    }
}

#pragma warning restore CA1416