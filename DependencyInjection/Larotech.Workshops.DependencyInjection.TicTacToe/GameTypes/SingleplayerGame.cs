using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Larotech.Workshops.DependencyInjection.TicTacToe.Interfaces;
using Larotech.Workshops.DependencyInjection.TicTacToe.PlayerTypes;

namespace Larotech.Workshops.DependencyInjection.TicTacToe.GameTypes
{
    public class SingleplayerGame : Game
    {
        public HumanPlayer HumanPlayer { get; set; }

        public ComputerPlayer ComputerPlayer { get; }

        public SingleplayerGame(HumanPlayer humanPlayer, ComputerPlayer computerPlayer)
            : base()
        {
            HumanPlayer = humanPlayer;
            ComputerPlayer = computerPlayer;
        }

        public override void MakeMove(int row, int column)
        {
            if (!CanMove(row, column))
            {
                return;
            }

            HumanPlayer.InsertX(Board, moves, row, column);
            ComputerPlayer.Insert0(Board, moves);

            turn += 2;

            UpdateStatus();
        }
    }
}
