namespace day_2022_12_02;

public static class Game
{
    public enum Shape
    {
        Rock,
        Paper,
        Scissors
    }

    public enum Result
    {
        Loose,
        Draw,
        Win
    }

    public static readonly IReadOnlyDictionary<(Shape, Shape), Result> Rules = new Dictionary<(Shape, Shape), Result>
    {
        { (Shape.Rock,     Shape.Rock),     Result.Draw  },
        { (Shape.Rock,     Shape.Paper),    Result.Loose },
        { (Shape.Rock,     Shape.Scissors), Result.Win   },
        { (Shape.Paper,    Shape.Rock),     Result.Win   },
        { (Shape.Paper,    Shape.Paper),    Result.Draw  },
        { (Shape.Paper,    Shape.Scissors), Result.Loose },
        { (Shape.Scissors, Shape.Rock),     Result.Loose },
        { (Shape.Scissors, Shape.Paper),    Result.Win   },
        { (Shape.Scissors, Shape.Scissors), Result.Draw  }
    };
}