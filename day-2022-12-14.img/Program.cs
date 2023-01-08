using day_2022_12_14;
using day_2022_12_14.app;
using day_2022_12_14.img;

var infiniteCave = new InfiniteCave(Parser.Parse(Input.GetData()), 500, 0);
var step = 0;
while (true)
{
    var filename = $"img/{step:D6}.png";
    Image.GenerateFromTiles(
        infiniteCave.Width, infiniteCave.Height, 4, 4,
        (x, y) =>
        {
            return infiniteCave.GetTile(x, y) switch
            {
                Cave.Material.Air => (0, 0, 0),
                Cave.Material.Rock => (100, 100, 100),
                Cave.Material.Sand => (255, 201, 14),
                _ => throw new ArgumentOutOfRangeException()
            };
        },
        filename);
    if (!infiniteCave.DropSand())
        break;
    step += 1;
}