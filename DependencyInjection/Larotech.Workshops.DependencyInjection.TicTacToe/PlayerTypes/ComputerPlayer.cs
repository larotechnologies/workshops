using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Larotech.Workshops.DependencyInjection.TicTacToe.Interfaces;

namespace Larotech.Workshops.DependencyInjection.TicTacToe.PlayerTypes
{
    public class ComputerPlayer : IPlayer
    {
        public string Name { get; set; }

        public ComputerPlayer(string name)
        {
            Name = name;
        }

        public void InsertX(List<string> board, int[,] moves)
        {
            FindMove(board, moves, "X");
        }

        public void Insert0(List<string> board, int[,] moves)
        {
            FindMove(board, moves, "O");
        }

        private void FindMove(List<string> board, int[,] moves, string symbol)
        {
            for (int i = 0; i < 3; i++)
            {
                if (IsPossibleToMoveHere(moves, i, i))
                {
                    MoveHere(board, moves, symbol, i, i);
                    return;

                }
            }

            for (int i = 1; i < 3; i++)
            {
                if (IsPossibleToMoveHere(moves, 0, i))
                {
                    MoveHere(board, moves, symbol, 0, i);
                    return;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (IsPossibleToMoveHere(moves, i, j))
                    {
                        MoveHere(board, moves, symbol, i, j);
                        return;
                    }
                }
            }
        }

        private bool IsPossibleToMoveHere(int[,] moves, int row, int column)
        {
            return moves[row, column] == 0;
        }

        private void MoveHere(List<string> board, int[,] moves, string symbol, int row, int column)
        {
            int index = column + (row * 3);
            board[index] = symbol;

            moves[row, column] = symbol == "X" ? 1 : 2;
        }
    }
}
