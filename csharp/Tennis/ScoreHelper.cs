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
}
