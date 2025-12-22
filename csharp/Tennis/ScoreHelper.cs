namespace Tennis;

public class ScoreHelper
{
    public static string GetScoreWhenEquality(int value)
    {
        return value switch
        {
            0 => "Love-All",
            1 => "Fifteen-All",
            2 => "Thirty-All",
            _ => "Deuce",
        };
    }
    public static string GetScoreWhenWin(int score1, int score2, string player1Name, string player2Name)
    {

        var minusResult = score1 - score2;
        if (minusResult == 1)
            return $"Advantage {player1Name}";
        if (minusResult == -1)
            return $"Advantage {player2Name}";
        if (minusResult >= 2)
            return $"Win for {player1Name}";
        return $"Win for {player2Name}";

    }
    public static bool IsWin(int score1, int score2)
    {
        return score1 >= 4 || score2 >= 4;
    }
}
