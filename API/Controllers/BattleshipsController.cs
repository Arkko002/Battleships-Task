using System.Text.Json;
using Battleships;
using Battleships.Rules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Battleships_Task.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BattleshipsController : ControllerBase
    {
        private readonly ILogger<BattleshipsController> _logger;
        private readonly IBattleshipsGame _battleshipsGame;

        public BattleshipsController(ILogger<BattleshipsController> logger, IBattleshipsGame battleshipsGame)
        {
            _logger = logger;
            _battleshipsGame = battleshipsGame;
        }

        [HttpGet]
        public JsonResult Get()
        {
            return new JsonResult(JsonSerializer.Serialize(_battleshipsGame.GetGameState()));
        }

        [HttpPost]
        public void SetRules([FromBody] IGameRules gameRules)
        {
            _battleshipsGame.GameRules = gameRules;
        }

        [HttpPost]
        public void RestartGame()
        {
            _battleshipsGame.StartGame();
        }

        [HttpPost]
        public JsonResult NextMove()
        {
            return new JsonResult(JsonSerializer.Serialize(_battleshipsGame.NextMove()));
        }
    }
}
