using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Larotech.Workshops.DependencyInjection.TicTacToe.Interfaces;
using Larotech.Workshops.DependencyInjection.TicTacToe.PlayerTypes;

namespace Larotech.Workshops.DependencyInjection.TicTacToe.GameTypes
{
    public class MultiplayerGame : Game
    {
        public HumanPlayer Player1 { get; set; }

        public HumanPlayer Player2 { get; }

        public MultiplayerGame(HumanPlayer player1, HumanPlayer player2)
            : base()
        {
            Player1 = player1;
            Player2 = player2;
        }

        public override void MakeMove(int row, int column)
        {
            if (!CanMove(row, column))
            {
                return;
            }

            if (IsXTurn())
            {
                InsertX(row, column);
            }
            else if (Is0Turn())
            {
                Insert0(row, column);
            }

            UpdateStatus();
        }

        public void InsertX(int row, int column)
        {
            Player1.InsertX(Board, moves, row, column);

            moves[row, column] = 1;

            turn++;
        }

        public void Insert0(int row, int column)
        {
            Player2.Insert0(Board, moves, row, column);

            moves[row, column] = 2;

            turn++;
        }
    }
}
