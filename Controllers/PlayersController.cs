using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using OfficeBall.Api.Database;
using OfficeBall.Api.Models;

namespace OfficeBall.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly PlayerService _playerService;

        public PlayersController(PlayerService playerService)
        {
            this._playerService = playerService;
        }

        [HttpGet]
        public ActionResult<List<Player>> Get() =>
            _playerService.Get();

        [HttpGet("{id:length(24)}", Name = "GetPlayer")]
        public ActionResult<Player> Get(string id)
        {
            var player = _playerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            return player;
        }

        [HttpPost]
        public ActionResult<Player> Create(Player player)
        {
            _playerService.Create(player);

            return CreatedAtRoute("GetPlayer", new { id = player.Id.ToString() }, player);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Player playerIn)
        {
            var player = _playerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _playerService.Update(id, playerIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var player = _playerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            _playerService.Remove(player.Id);

            return NoContent();
        }


        [HttpPut("{id:length(24)}/setshots")]
        public IActionResult SetShots([FromRoute] string id, [FromQuery] int shots)
        {
            var player = _playerService.Get(id);

            if (player == null)
            {
                return NotFound();
            }

            player.Shots = shots;

            _playerService.Update(id, player);

            return NoContent();
        }
    }
}