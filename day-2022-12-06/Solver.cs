namespace day_2022_12_06;

public static class Solver
{
    public static object Part1(Data data)
    {
        return MarkerPosition(data.Characters.ToArray(), 4);
    }

    public static object Part2(Data data)
    {
        return MarkerPosition(data.Characters.ToArray(), 14);
    }

    private static int MarkerPositionNaive(char[] chars, int markerSize)
    {
        for (var p = 0; p < chars.Length; p++)
        {
            if (new HashSet<char>(chars[p..(p + markerSize)]).Count == markerSize)
                return p + markerSize;
        }
        throw new ArgumentException();
    }
    
    private static int MarkerPosition(char[] chars, int markerSize)
    {
        var charsCount = new int['z' - 'a' + 1];
        var onesCount = 0;
        
        for (var i = 0; i < chars.Length; i++)
        {
            if (i >= markerSize)
            {
                var lch = chars[i - markerSize];
                charsCount[lch - 'a'] -= 1;
                switch (charsCount[lch - 'a'])
                {
                    case 0:
                        onesCount -= 1;
                        break;
                    case 1:
                        onesCount += 1;
                        break;
                }
            }

            var rch = chars[i];
            charsCount[rch - 'a'] += 1;
            switch (charsCount[rch - 'a'])
            {
                case 1:
                    onesCount += 1;
                    break;
                case 2:
                    onesCount -= 1;
                    break;
            }
            
            if(onesCount == markerSize)
                return i + 1;
        }
        
        throw new ArgumentException();
    }
}