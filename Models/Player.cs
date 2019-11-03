namespace PlayerAPI.Models{
    public class Player{
        public Player(){
            Inventory = new Inventory();
        }
        public int PlayerId {get;set;}
        public string PlayerName {get;set;}
        public Inventory Inventory {get; set;}
        public int ShipId {get; set;}
    }
}