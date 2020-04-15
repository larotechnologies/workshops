using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Larotech.Workshops.DependencyInjection.WebDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        #region Step1

        private readonly ILogger<WeatherForecastController> logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            this.logger = logger;
        }

        #endregion

        #region Step2

        private readonly IGame game;

        public WeatherForecastController(IGame game, IServiceProvider serviceProvider)
        {
            this.game = game;

            var anotherGame = serviceProvider.GetService<IGame>();

            Console.WriteLine($"{game.GetHashCode()} - {anotherGame.GetHashCode()}");
        }

        #endregion

        #region Step3

        private readonly Chess chess;

        public WeatherForecastController(Chess chess, IServiceProvider serviceProvider)
        {
            this.chess = chess;

            var anotherChess = serviceProvider.GetService<Chess>();

            Console.WriteLine($"{chess.GetHashCode()} - {anotherChess.GetHashCode()}");
        }

        #endregion

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
