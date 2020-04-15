using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Larotech.Workshops.DependencyInjection.TicTacToe.Interfaces;

namespace Larotech.Workshops.DependencyInjection.TicTacToe.PlayerTypes
{
    public class HumanPlayer : IPlayer
    {
        public string Name { get; set; }

        public HumanPlayer(string name)
        {
            Name = name;
        }

        public void InsertX(List<string> board, int[,] moves, int row, int column)
        {
            int index = column + (row * 3);

            board[index] = "X";
            moves[row, column] = 1;
        }

        public void Insert0(List<string> board, int[,] moves, int row, int column)
        {
            int index = column + (row * 3);

            board[index] = "O";
            moves[row, column] = 2;
        }
    }
}
