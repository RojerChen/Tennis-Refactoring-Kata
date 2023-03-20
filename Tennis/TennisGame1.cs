using System;
using System.Threading;

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
            if (IsSameScore())
            {
                string score = "";
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

                return score;
            }
            else if (IsAdvOrWin())
            {
                //IsAdvOrWin
                if (IsAdv())
                {
                    return $"Advantage {WhoLead()}";
                }

                return $"Win for {WhoLead()}";
            }
            else
            {
                //normal score

                string score2 = GetNormalScore(player1Score);
                score2 += "-";
                string score = "";
                switch (player2Score)
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

                return score2 + score;
            }
        }

        private string GetNormalScore(int score)
        {
            string result = "";
            switch (score)
            {
                case 0:
                    result = "Love";
                    break;
                case 1:
                    result = "Fifteen";
                    break;
                case 2:
                    result = "Thirty";
                    break;
                case 3:
                    result = "Forty";
                    break;
            }

            return result;
        }

        private bool IsSameScore()
        {
            return player1Score == player2Score;
        }

        private bool IsAdv()
        {
            return Math.Abs(player1Score - player2Score) == 1;
        }

        private bool IsAdvOrWin()
        {
            return player1Score >= 4 || player2Score >= 4;
        }

        private string WhoLead()
        {
            var whoLead = player1Score > player2Score ? "player1" : "player2";
            return whoLead;
        }
    }
}