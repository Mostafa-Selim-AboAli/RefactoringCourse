namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int p1point;
        private int p2point;

        private string p1res = "";
        private string p2res = "";
        private string player1Name;
        private string player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            p1point = 0;
            this.player2Name = player2Name;
        }

        public string GetScore()
        {

            if (p1point == p2point)
            {
                return CalcScoreWhenEquality();
            }
            string score;
            score = CalcScoreRegular();

            if (p1point > p2point && p2point >= 3)
            {
                score = "Advantage player1";
            }

            if (p2point > p1point && p1point >= 3)
            {
                score = "Advantage player2";
            }

            if (p1point >= 4 && p2point >= 0 && (p1point - p2point) >= 2)
            {
                score = "Win for player1";
            }
            if (p2point >= 4 && p1point >= 0 && (p2point - p1point) >= 2)
            {
                score = "Win for player2";
            }
            return score;
        }

        private string CalcScoreRegular()
        {
            string score = "";
            if (p1point > 0 && p2point == 0)
            {
                p1res = ClacPlayerResult(p1point);
                p2res = ClacPlayerResult(p2point);
                score = p1res + "-" + p2res;
            }
            if (p2point > 0 && p1point == 0)
            {
                p1res = ClacPlayerResult(p1point);
                p2res = ClacPlayerResult(p2point);
                score = p1res + "-" + p2res;
            }

            if (p1point > p2point && p1point < 4)
            {
                p1res = ClacPlayerResult(p1point);
                p2res = ClacPlayerResult(p2point);

                score = p1res + "-" + p2res;
            }
            if (p2point > p1point && p2point < 4)
            {
                p1res = ClacPlayerResult(p1point);
                p2res = ClacPlayerResult(p2point);
                score = p1res + "-" + p2res;
            }

            return score;
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
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

    }
}

