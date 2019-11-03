namespace PlayerAPI.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PlayerAPI.Models;

    public interface IPlayerService
    {
        Task<Player> GetPlayerById(int id);
        Task<bool> AddOrUpdatePlayer(Player player);
        Task<bool> AddInventory(Player player, Item item);
        Task<bool> RemoveInventory(Player player, Item item);
        Task<bool> UpdateMoney(Player player, double money);    
    }
}