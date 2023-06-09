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
                if (IsDeuce())
                {
                    return Deuce();
                }

                return SameScore();
            }

            if (IsAdvOrWin())
            {
                if (IsAdv())
                {
                    return Adv();
                }

                return Win();
            }

            return NormalScore();
        }

        private string NormalScore()
        {
            return GetScore(player1Score) + "-" + GetScore(player2Score);
        }

        private string Win()
        {
            return $"Win for {WhoLead()}";
        }

        private string Adv()
        {
            return $"Advantage {WhoLead()}";
        }

        private string SameScore()
        {
            return GetScore(player1Score) + "-All";
        }

        private static string Deuce()
        {
            return "Deuce";
        }

        private bool IsDeuce()
        {
            return player1Score > 2;
        }

        private string GetScore(int score)
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