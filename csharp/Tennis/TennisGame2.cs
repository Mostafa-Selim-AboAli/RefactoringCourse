namespace Tennis
{
    public class TennisGame2(string player1Name, string player2Name) : ITennisGame
    {
        private int p1point = 0;
        private int p2point;

        private string p1res = "";
        private string p2res = "";

        public string GetScore()
        {

            if (p1point == p2point)
            {
                return CalcScoreWhenEquality();
            }
            string score;
            score = CalcScoreAdvantageOrWin();
            if (!string.IsNullOrWhiteSpace(score))
                return score;
            score = CalcScoreRegular();



            return score;
        }
        private string CalcScoreAdvantageOrWin()
        {
            string score = "";
            if (p1point > p2point && p2point >= 3)
            {
                score = $"Advantage {player1Name}";
            }

            if (p2point > p1point && p1point >= 3)
            {
                score = $"Advantage {player2Name}";
            }

            if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                score = $"Win for {player1Name}";
            }
            if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
            {
                score = $"Win for {player2Name}";
            }
            return score;
        }
        private string CalcScoreRegular()
        {

            if (p1point > 0 && p2point == 0)
            {
                p1res = ClacPlayerResult(p1point);
                p2res = ClacPlayerResult(p2point);
                return p1res + "-" + p2res;
            }
            if (p2point > 0 && p1point == 0)
            {
                p1res = ClacPlayerResult(p1point);
                p2res = ClacPlayerResult(p2point);
                return p1res + "-" + p2res;
            }

            if (p1point > p2point && p1point < 4)
            {
                p1res = ClacPlayerResult(p1point);
                p2res = ClacPlayerResult(p2point);

                return p1res + "-" + p2res;
            }
            if (p2point > p1point && p2point < 4)
            {
                p1res = ClacPlayerResult(p1point);
                p2res = ClacPlayerResult(p2point);
                return p1res + "-" + p2res;
            }
            return "";

        }

        private string ClacPlayerResult(int palyerPoint)
        {
            return palyerPoint switch
            {
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => "Love",
            };

        }

        private string CalcScoreWhenEquality()
        {
            return p1point switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            };

        }


        private void P1Score()
        {
            p1point++;
        }

        private void P2Score()
        {
            p2point++;
        }

        public void WonPoint(string player)
        {
            if (player == player1Name)
                P1Score();
            else
                P2Score();
        }

    }
}

