using System.Collections.Generic;

namespace PlayerAPI.Models{
    public class Inventory{
        public Inventory(){
            Items = new List<Item>();
            Money = 0.0;
        }
        public List<Item> Items {get; set;}
        public double Money {get; set;}
    }
}