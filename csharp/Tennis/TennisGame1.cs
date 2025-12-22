namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int m_score1 = 0;
        private int m_score2 = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

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
            {
                return ScoreHelper.GetScoreWhenEquality(m_score1);

            }

            if (m_score1 >= 4 || m_score2 >= 4)
            {
                return ScoreHelper.GetScoreWhenWin(m_score1, m_score2, player1Name, player2Name);
            }
            return GetScoreRegular();


        }

        private string GetScoreRegular()
        {
            string score = "";
            for (var i = 1; i < 3; i++)
            {
                int tempScore;
                if (i == 1) tempScore = m_score1;
                else { score += "-"; tempScore = m_score2; }
                switch (tempScore)
                {
                    case 0:
                        score += "Love";
                        break;
                    case 1:
                        score += "Fifteen";
                        break;
                    case 2:
                        score += "Thirty";
                        break;
                    case 3:
                        score += "Forty";
                        break;
                }
            }

            return score;
        }



    }
}

