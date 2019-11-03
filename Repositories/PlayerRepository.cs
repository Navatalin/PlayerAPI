namespace PlayerAPI.Repositories{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using PlayerAPI.Models;
    using System.Linq;

    public class PlayerRepository : IPlayerRepository{
        private List<Player> _players;
        public PlayerRepository(){
            _players = new List<Player>();
        }

        public async Task<Player> GetAsync(int id){
            var p = await Task.Run(() => _players.Find(x => x.PlayerId == id));
            if(p == null){
                return null;
            }
            else{
                return p;
            }
        }

        public async Task AddPlayer(Player player){
            player.Inventory = new Inventory();
            await Task.Run(() => _players.Add(player));
        }
        public async Task<bool> UpdatePlayer(Player player){
           
            var p = await Task.Run(() => _players.FirstOrDefault(x => x.PlayerId == player.PlayerId));
            if(p != null){
                 p.PlayerName = player.PlayerName;
                 p.ShipId = player.ShipId;
                 return true;
            }
            return false;
        }

        public async Task<bool> AddToInventory(Player player, Item item){
            var p = _players.FirstOrDefault(x => x.PlayerId == player.PlayerId);
            if(p != null){
                await Task.Run(() => p.Inventory.Items.Add(item));
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveFromInventory(Player player, Item item){
            var p = _players.FirstOrDefault(x => x.PlayerId == player.PlayerId);
            if(p != null){
                await Task.Run(() => p.Inventory.Items.Remove(item));
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateMoney(Player player, double money){
            var p = _players.FirstOrDefault(x => x.PlayerId == player.PlayerId);
            if(p != null){
                await Task.Run(() => p.Inventory.Money + money);
                return true;
            }
            return false;
        }
    }
}