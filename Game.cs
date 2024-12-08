using System;

namespace TicTacToe
{
    public class Game
    {
        private string[,] board = new string[3, 3]; 

        public string[,] Board
        {
            get => board;
            private set => board = value;
        }

        private string currentPlayer = "X";

        public string CurrentPlayer
        {
            get => currentPlayer;
            private set => currentPlayer = value;
        }

        public Game()
        {
            ResetGame();
        }

        public void ResetGame()
        {
            Board = new string[3, 3];
            CurrentPlayer = "X";
        }

        public bool MakeMove(int row, int col)
        {
            if (Board[row, col] == null)
            {
                Board[row, col] = CurrentPlayer;
                SwitchPlayer();
                return true;
            }
            return false;
        }

        public bool CheckWinner(string currPlayer)
        {
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 0] == currPlayer && Board[i, 1] == currPlayer && Board[i, 2] == currPlayer) //горизонтали
                    return true;

                if (Board[0, i] == currPlayer && Board[1, i] == currPlayer && Board[2, i] == currPlayer) //вертикали
                    return true;
            }

            //диагонали
            if (Board[0, 0] == currPlayer && Board[1, 1] == currPlayer && Board[2, 2] == currPlayer)
                return true;

            if (Board[0, 2] == currPlayer && Board[1, 1] == currPlayer && Board[2, 0] == currPlayer)
                return true;

            return false;
        }

        public bool CheckDraw()
        {
            foreach (var cell in Board)
            {
                if (cell == null) return false;
            }
            return true;
        }

        private void SwitchPlayer()
        {
            CurrentPlayer = CurrentPlayer == "X" ? "O" : "X";
        }
    }
}
