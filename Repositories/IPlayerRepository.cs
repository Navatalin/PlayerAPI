namespace PlayerAPI.Repositories{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PlayerAPI.Models;

    public interface IPlayerRepository
    {
        Task<Player> GetAsync(int id);
        Task AddPlayer(Player player);
        Task<bool> UpdatePlayer(Player player);
        Task<bool> AddToInventory(Player player, Item item);
        Task<bool> RemoveFromInventory(Player player, Item item);
        Task<bool> UpdateMoney(Player player, double money);
    }
}