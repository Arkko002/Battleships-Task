using Battleships;
using Battleships.Rules;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Battleships_Task.Controllers
{
    [ApiController]
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
        [Route("/state")]
        public ActionResult GetState()
        {
            return new JsonResult(_battleshipsGame.GetGameState());
        }

        [HttpPost]
        [Route("/rules")]
        public void SetRules([FromBody] IGameRules gameRules)
        {
            _battleshipsGame.GameRules = gameRules;
        }

        [HttpPost]
        [Route("/start")]
        public ActionResult StartGame()
        {
            _battleshipsGame.StartGame();
            return new JsonResult(_battleshipsGame.GetGameState());
        }

        [HttpPost]
        [Route("/move")]
        public IActionResult NextMove()
        {
            return new JsonResult(_battleshipsGame.NextMove());
        }
    }
}
