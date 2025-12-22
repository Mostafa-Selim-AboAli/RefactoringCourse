namespace Tennis;

public class TennisGame7 : ITennisGame
{
    private int player1Score;
    private int player2Score;
    private string player1Name;
    private string player2Name;

    public TennisGame7(string player1Name, string player2Name)
    {
        this.player1Name = player1Name;
        this.player2Name = player2Name;
    }

    public void WonPoint(string playerName)
    {
        if (playerName == player1Name)
            player1Score++;
        else
            player2Score++;
    }

    public string GetScore()
    {
        string result = "Current score: ";

        if (player1Score == player2Score)
        {
            // tie score
            result += ScoreHelper.GetScoreWhenEquality(player1Score);

        }
        else if (ScoreHelper.IsWin(player1Score, player2Score))
        {
            // end-game score
            result += ScoreHelper.GetScoreWhenWin(player1Score, player2Score, player1Name, player2Name);

        }
        else
        {
            // regular score
            result += player1Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };

            result += "-";

            result += player2Score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty"
            };
        }

        return result + ", enjoy your game!";
    }
}