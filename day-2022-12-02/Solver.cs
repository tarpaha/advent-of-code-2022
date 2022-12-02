namespace day_2022_12_02;

public static class Solver
{
    private static readonly IReadOnlyDictionary<Game.Shape, int> ShapeScore = new Dictionary<Game.Shape, int>
    {
        { Game.Shape.Rock,     1 },
        { Game.Shape.Paper,    2 },
        { Game.Shape.Scissors, 3 }
    };

    private static readonly IReadOnlyDictionary<Game.Result, int> ResultScore = new Dictionary<Game.Result, int>
    {
        { Game.Result.Loose, 0 },
        { Game.Result.Draw,  3 },
        { Game.Result.Win,   6 }
    };

    private static readonly IReadOnlyDictionary<char, Game.Shape> PlayerShapes = new Dictionary<char, Game.Shape>
    {
        { 'X', Game.Shape.Rock     },
        { 'Y', Game.Shape.Paper    },
        { 'Z', Game.Shape.Scissors }
    };

    private static readonly IReadOnlyDictionary<char, Game.Shape> OpponentShapes = new Dictionary<char, Game.Shape>
    {
        { 'A', Game.Shape.Rock     },
        { 'B', Game.Shape.Paper    },
        { 'C', Game.Shape.Scissors }
    };

    private static readonly IReadOnlyDictionary<char, Game.Result> RoundResult = new Dictionary<char, Game.Result>()
    {
        { 'X', Game.Result.Loose },
        { 'Y', Game.Result.Draw  },
        { 'Z', Game.Result.Win   }
    };

    private static int PlayRound(Game.Shape player, Game.Shape opponent)
    {
        var shapeScore = ShapeScore[player];
        var roundScore = ResultScore[Game.Rules[(player, opponent)]];
        return shapeScore + roundScore;
    }

    private static int PlayRoundWithResult(Game.Shape opponent, Game.Result result)
    {
        var player = Game.Rules
            .Where(kvp => kvp.Key.opponent == opponent && kvp.Value == result)
            .Select(kvp => kvp.Key.player)
            .First();
        var shapeScore = ShapeScore[player];
        var roundScore = ResultScore[result];
        return shapeScore + roundScore;
    }
    
    public static object Part1(Data data)
    {
        return data.Pairs
            .Select(pair => (opponent: OpponentShapes[pair.First], player: PlayerShapes[pair.Second]))
            .Select(round => PlayRound(round.player, round.opponent))
            .Sum();
    }

    public static object Part2(Data data)
    {
        return data.Pairs
            .Select(pair => (opponent: OpponentShapes[pair.First], result: RoundResult[pair.Second]))
            .Select(round => PlayRoundWithResult(round.opponent, round.result))
            .Sum();
    }
}