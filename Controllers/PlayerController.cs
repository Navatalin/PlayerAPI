using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PlayerAPI.Models;
using PlayerAPI.Services;

namespace PlayerAPI.Controllers
{
    [Route("startrucker/api/v1/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly IPlayerService _playerService;

        public PlayerController(ILogger<PlayerController> logger, IPlayerService playerService){
            _logger = logger;
            _playerService = playerService;
        }

        [Route("{playerId:int}")]
        [HttpGet]
        public async Task<ActionResult<Player>> GetPlayer(int playerId){
            return await _playerService.GetPlayerById(playerId);
        }
        [Route("")]
        [HttpPost]
        public async Task<ActionResult> AddOrUpdatePlayer([FromBody]Player player){
            var result = await _playerService.AddOrUpdatePlayer(player);

            if(!result){
                return BadRequest();
            }
            return Ok();
        }
        [Route("{playerId:int}/inventory/additem")]
        [HttpPost]
        public async Task<ActionResult> AddItemToInventory([FromBody] Item item, int playerId){
            var player = await _playerService.GetPlayerById(playerId);
            var result = await _playerService.AddInventory(player, item);

            if(!result){
                return BadRequest();
            }
            return Ok();
        }
        [Route("{playerId:int}/inventory/removeitem")]
        [HttpPost]
        public async Task<ActionResult> RemoveItemFromInventory([FromBody] Item item, int playerId){
            var player = await _playerService.GetPlayerById(playerId);
            if(player != null){
                var result = await _playerService.RemoveInventory(player, item);

                if(!result){
                    return BadRequest();
                }
                return Ok();
            }
            return BadRequest();
        }
        [Route("{playerId:int}/inventory/updatemoney")]
        [HttpPost]
        public async Task<ActionResult> UpdateMoney([FromBody]double money, int playerId){
            var player = await _playerService.GetPlayerById(playerId);
            if(player != null){
                var result = await _playerService.UpdateMoney(player, money);

                if(!result){
                    return BadRequest();
                }
                return Ok();
            }
            return BadRequest();
        }
    }
}