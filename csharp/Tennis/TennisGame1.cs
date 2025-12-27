namespace Tennis;

public class TennisGame1(string player1Name, string player2Name) : ITennisGame
{
    private byte m_score1 = 0;
    private byte m_score2 = 0;

    public void WonPoint(string playerName)
    {
        if (playerName == player1Name)
            m_score1 += 1;
        else
            m_score2 += 1;
    }
    public string GetScore()
    {
        if (m_score1 == m_score2)
            return CalcScoreWhenEquality();

        if (IsScoreAdvantageOrWin())
            return CalaScoreWhenAdvantageOrWin();

        return CalcScoreRegular();
    }
    private bool IsScoreAdvantageOrWin()
    {
        return m_score1 >= 4 || m_score2 >= 4;
    }
    private string CalcScoreRegular()
    {
        string score = "";

        for (byte i = 1; i < 3; i++)
        {
            int tempScore;
            if (i == 1)
            {
                tempScore = m_score1;
            }
            else
            {
                score += "-";
                tempScore = m_score2;
            }

            score += tempScore switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };

        }

        return score;
    }
    private string CalaScoreWhenAdvantageOrWin()
    {

        var minusResult = m_score1 - m_score2;
        return minusResult switch
        {
            1 => $"Advantage {player1Name}",
            -1 => $"Advantage {player2Name}",
            >= 2 => $"Win for {player1Name}",
            _ => $"Win for {player2Name}"
        };

    }
    private string CalcScoreWhenEquality()
    {
        return m_score1 switch
        {
            0 => "Love-All",
            1 => "Fifteen-All",
            2 => "Thirty-All",
            _ => "Deuce",
        };

    }
}

