using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace App1
{
    class TicTacToeGameEngine
    {
        private int playturn = 1;
        private int[,] Winner = new int[,]
        {
            { 0,1,2 },
            { 3,4,5 },
            { 6,7,8 },
            { 0,3,6 },
            { 1,4,7 },
            { 2,5,8 },
            { 0,4,8 },
            { 2,4,6 }
        };

        public bool CheckWinner(Button[] button)
        {
            bool gameOver = false;

            for (int i = 0; i < 8; i++)
            {
                int a = Winner[i, 0], b = Winner[i, 1], c = Winner[i, 2];
                Button b1 = button[a], b2 = button[b], b3 = button[c];

                if (b1.Text == "" || b2.Text == "" || b3.Text == "")
                    continue;

                if (b1.Text == b2.Text && b2.Text == b3.Text)
                {
                    b1.BackgroundColor = b2.BackgroundColor = b3.BackgroundColor = Color.Aqua;
                    gameOver = true;
                    break;
                }

            }

            bool isTie = true;
            if (!gameOver)
            {
                foreach (Button b in button)
                {
                    if (b.Text == "")
                    {
                        isTie = false;
                        break;
                    }
                }
                if (isTie)
                {
                    gameOver = true;
                }
            }
            return gameOver;
        }

        public void SetButton(Button b)
        {
            if(b.Text =="")
            {
                b.Text = playturn == 1 ? "X" : "O";
                playturn = playturn == 1 ? 2 : 1; //switch player turn
            }
        }

        public void ResetGame(Button[] buttons)
        {
            playturn = 1;
            foreach(Button b in buttons)
            {
                b.Text = "";
                b.BackgroundColor = Color.Gray;
            }
        }
    }
}
