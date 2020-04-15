using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Larotech.Workshops.DependencyInjection.TicTacToe.GameTypes;
using Larotech.Workshops.DependencyInjection.TicTacToe.Interfaces;
using Microsoft.AspNetCore.Components;

namespace Larotech.Workshops.DependencyInjection.TicTacToe.Pages
{
    public class IndexBase : ComponentBase
    {
        protected string Symbol { get; set; } = null;

        protected bool IsDraw { get; set; } = false;

        [Inject]
        protected IGame Game { get; set; }

        protected async Task MakeMove(int row, int column)
        {
            if (Symbol != null)
            {
                return;
            }

            Game.MakeMove(row, column);
            await CheckGameStatus();

            this.StateHasChanged();
        }

        private async Task CheckGameStatus()
        {
            if (Game.IsWonByXPlayer())
            {
                await Task.Delay(1000);
                Symbol = "X";
            }
            else if (Game.IsWonBy0Player())
            {
                await Task.Delay(1000);
                Symbol = "O";
            }
            else if (Game.IsOver())
            {
                IsDraw = true;
            }
        }

        protected void Restart()
        {
            Symbol = null;
            IsDraw = false;

            Game.Restart();

            this.StateHasChanged();
        }
    }
}
