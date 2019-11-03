namespace PlayerAPI.Services
{
    using PlayerAPI.Models;
    using PlayerAPI.Repositories;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PlayerService : IPlayerService{
        private readonly ILogger<PlayerService> _logger;
        private readonly IPlayerRepository _playerRepository;

        public PlayerService(ILogger<PlayerService> logger, IPlayerRepository playerRepository){
            _logger = logger;
            _playerRepository = playerRepository;
            _playerRepository.AddPlayer(new Player{
                PlayerId = 1,
                PlayerName = "Testing"
            });
        }

        public async Task<Player> GetPlayerById(int id){
            return await _playerRepository.GetAsync(id);
        }

        public async Task<bool> AddOrUpdatePlayer(Player player){
            var p = await _playerRepository.GetAsync(player.PlayerId);
            if(p is null){
                await _playerRepository.AddPlayer(player);
                return true;
            }
            else{
                return await _playerRepository.UpdatePlayer(player);
            }
        }

        public async Task<bool> AddInventory(Player player, Item item)
        {
            return await _playerRepository.AddToInventory(player, item);
        }

        public async Task<bool> RemoveInventory(Player player, Item item){
            return await _playerRepository.RemoveFromInventory(player, item);
        }
        public async Task<bool> UpdateMoney(Player player, double money){
            return await _playerRepository.UpdateMoney(player, money);
        }


    }
}