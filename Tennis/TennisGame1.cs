using System;

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
                //IsAdvOrWin
                if (Math.Abs(player1Score - player2Score) == 1)
                {
                    score = $"Advantage {WhoLead()}";
                }
                else
                {
                    score = $"Win for {WhoLead()}";
                }
            }
            else
            {
                //normal score
                string score2 = GetScore(player1Score, score);
                score2 += "-";
                return GetScore(player2Score, score2);
            }

            return score;
        }

        private string WhoLead()
        {
            var whoLead = player1Score > player2Score ? "player1" : "player2";
            return whoLead;
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