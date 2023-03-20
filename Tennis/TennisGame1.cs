namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int player1Score = 0;
        private int player2Score = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Score += 1;
            else
                player2Score += 1;
        }

        public string GetScore()
        {
            string score = "";
            var tempScore = 0;
            if (player1Score == player2Score)
            {
                switch (player1Score)
                {
                    case 0:
                        score = "Love-All";
                        break;
                    case 1:
                        score = "Fifteen-All";
                        break;
                    case 2:
                        score = "Thirty-All";
                        break;
                    default:
                        score = "Deuce";
                        break;
                }
            }
            else if (player1Score >= 4 || player2Score >= 4)
            {
                var minusResult = player1Score - player2Score;
                if (minusResult == 1) score = "Advantage player1";
                else if (minusResult == -1) score = "Advantage player2";
                else if (minusResult >= 2) score = "Win for player1";
                else score = "Win for player2";
            }
            else
            {
                string score1 = score;
                int tempScore1;
                tempScore1 = player1Score;

                score1 = GetScore(tempScore1, score1);
                score = score1;
                string score2 = score;
                int tempScore2;
                score2 += "-";
                tempScore2 = player2Score;

                score2 = GetScore(tempScore2, score2);
                score = score2;
            }

            return score;
        }

        private static string GetScore(int tempScore, string score)
        {
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

            return score;
        }
    }
}