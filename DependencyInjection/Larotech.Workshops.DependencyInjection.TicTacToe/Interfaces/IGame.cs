using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Larotech.Workshops.DependencyInjection.TicTacToe.Interfaces
{
    public interface IGame
    {
        bool IsOver();

        void Restart();

        bool IsWonByXPlayer();

        bool IsWonBy0Player();

        void MakeMove(int row, int column);

        List<string> Board { get; }
    }
}
