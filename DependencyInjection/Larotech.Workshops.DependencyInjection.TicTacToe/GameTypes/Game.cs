using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Larotech.Workshops.DependencyInjection.TicTacToe.Interfaces;

namespace Larotech.Workshops.DependencyInjection.TicTacToe.GameTypes
{
    public abstract class Game : IGame
    {
        private bool isWonByXPlayer;
        private bool isWonBy0Player;
        private const int numberOfRowsAndColumns = 3;
        private const int maximumNumberOfTurns = 9;

        protected int turn = 0;
        protected int[,] moves = new int[3, 3];

        public Game()
        {
            Board = new List<string>();
            for (int i = 0; i < 9; i++)
            {
                Board.Add(null);
            }
        }

        public List<string> Board { get; }

        public abstract void MakeMove(int row, int column);

        public bool IsOver()
        {
            return turn >= maximumNumberOfTurns;
        }

        public bool IsWonByXPlayer()
        {
            return isWonByXPlayer;
        }

        public bool IsWonBy0Player()
        {
            return isWonBy0Player;
        }

        public void Restart()
        {
            int row, column;

            for (row = 0; row < numberOfRowsAndColumns; row++)
            {
                for (column = 0; column < numberOfRowsAndColumns; column++)
                {
                    moves[row, column] = 0;
                    Board[column + (row * 3)] = null;
                }
            }

            turn = 0;

            isWonBy0Player = false;
            isWonByXPlayer = false;
        }

        protected void UpdateStatus()
        {
            for (int row = 0; row < numberOfRowsAndColumns; row++)
            {
                IsCompleteLine(row);
            }

            for (int column = 0; column < numberOfRowsAndColumns; column++)
            {
                IsCompleteColumn(column);
            }

            IsCompleteFirstDiagonal();
            IsCompleteSecondDiagonal();
        }

        protected bool IsXTurn()
        {
            return turn % 2 == 0;
        }

        protected bool Is0Turn()
        {
            return turn % 2 != 0;
        }

        protected bool CanMove(int row, int column)
        {
            int index = column + (row * 3);

            return string.IsNullOrEmpty(Board[index]);
        }

        private void IsCompleteSecondDiagonal()
        {
            if (moves[0, 2] == moves[1, 1] && moves[1, 1] == moves[2, 0])
            {
                if (moves[1, 1] == 2)
                {
                    isWonBy0Player = true;
                }

                if (moves[1, 1] == 1)
                {
                    isWonByXPlayer = true;
                }
            }
        }

        private void IsCompleteFirstDiagonal()
        {
            if (moves[0, 0] == moves[1, 1] && moves[1, 1] == moves[2, 2])
            {
                if (moves[0, 0] == 2)
                {
                    isWonBy0Player = true;
                }

                if (moves[0, 0] == 1)
                {
                    isWonByXPlayer = true;
                }
            }
        }

        private void IsCompleteColumn(int column)
        {
            if (moves[column, 0] == moves[column, 1] && moves[column, 1] == moves[column, 2])
            {
                if (moves[column, 0] == 2)
                {
                    isWonBy0Player = true;
                }

                if (moves[column, 1] == 1)
                {
                    isWonByXPlayer = true;
                }
            }
        }

        private void IsCompleteLine(int line)
        {
            if (moves[0, line] == moves[1, line] && moves[1, line] == moves[2, line])
            {
                if (moves[0, line] == 1)
                {
                    isWonByXPlayer = true;
                }

                if (moves[0, line] == 2)
                {
                    isWonBy0Player = true;
                }
            }
        }
    }
}
