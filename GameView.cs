using System;
using System.Windows.Forms;

namespace TicTacToe
{
    public class GameView : Form
    {
        private Game game;
        private Button[,] buttons = new Button[3,3];

        public GameView()
        {
            game = new Game();
            InitializeInterface();
        }

        private void InitializeInterface()
        {
            this.Text = "TicTacToe";
            this.AutoSize = true; // Автоматическая подстройка размера
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink; // Разрешаем изменять размер только в большую сторону

            buttons = new Button[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    buttons[i, j] = new Button
                    {
                        Width = 100,
                        Height = 100,
                        Location = new System.Drawing.Point(100 * i, 100 * j),
                        Font = new System.Drawing.Font("Arial", 24),
                        Text = string.Empty
                    };
                    buttons[i, j].Tag = (i, j); // Сохраняем позицию кнопки
                    buttons[i, j].Click += OnButtonClick!;
                    Controls.Add(buttons[i, j]);
                }
            }
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            var button = sender as Button;
            if (button != null && string.IsNullOrEmpty(button.Text))
            {
                var (row, col) = ((int, int))button.Tag!;
                string currentPlayer = game.CurrentPlayer;
                if (game.MakeMove(row, col))
                {
                    button.Text = currentPlayer;
                    if (game.CheckWinner(currentPlayer))
                    {
                        MessageBox.Show($"Player {currentPlayer} wins!");
                        game.ResetGame();
                        ResetInterface();
                    }
                    else if (game.CheckDraw())
                    {
                        MessageBox.Show("It's a draw!");
                        game.ResetGame();
                        ResetInterface();
                    }
                }
            }
        }

        private void ResetInterface()
        {
            foreach (var button in buttons)
            {
                button.Text = string.Empty;
            }
        }
    }
}
