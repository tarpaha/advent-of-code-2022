﻿namespace day_2022_12_14;

public class Cave
{
    private readonly int _initialX;
    private readonly int _initialY;
    
    private readonly int _xMin;
    private readonly int _yMin;

    private readonly int _width;
    private readonly int _height;
    
    private readonly int[,] _tiles;
    
    public Cave(Data data, int initialX, int initialY)
    {
        _initialX = initialX;
        _initialY = initialY;
        
        (_xMin, _yMin, var xMax, var yMax) = GetDimensions(data);
        
        _width = xMax - _xMin + 1;
        _height = yMax - _yMin + 1;
        
        _tiles = new int[_width, _height];
        FillFromPaths(data);
    }

    private static (int, int, int, int) GetDimensions(Data data)
    {
        var (yMin, yMax, xMin, xMax) = (0, int.MinValue, int.MaxValue, int.MinValue);
        foreach (var path in data.Paths)
        {
            foreach (var (x, y) in path.Coords)
            {
                if (y > yMax)
                    yMax = y;
                if (x < xMin)
                    xMin = x;
                if (x > xMax)
                    xMax = x;
            }
        }
        return (xMin, yMin, xMax, yMax);
    }
    
    private void FillFromPaths(Data data)
    {
        foreach (var path in data.Paths)
        {
            var coords = path.Coords.ToList();
            for (var i = 1; i < coords.Count; i++)
                FillFromPath(coords[i - 1], coords[i]);
        }
    }

    private void FillFromPath((int x, int y) start, (int x, int y) finish)
    {
        var (dx, dy) = (finish.x - start.x, finish.y - start.y) switch
        {
            (var deltaX, 0) => (deltaX > 0 ? 1 : -1, 0),
            (0, var deltaY) => (0, deltaY > 0 ? 1 : -1),
            _ => throw new ArgumentOutOfRangeException()
        };
        while (true)
        {
            _tiles[start.x - _xMin, start.y - _yMin] = 1;
            if(start.x == finish.x && start.y == finish.y)
                break;
            start.x += dx;
            start.y += dy;
        }
    }

    public override string ToString()
    {
        var str = "";
        for (var y = 0; y < _height; y++)
        {
            for (var x = 0; x < _width; x++)
            {
                if (x + _xMin == _initialX && y + _yMin == _initialY)
                {
                    str += '+';
                    continue;
                }
                str += _tiles[x, y] == 1 ? '#' : '.';
            }
            if(y < _height - 1)
                str += Environment.NewLine;
        }
        return str;
    }
}