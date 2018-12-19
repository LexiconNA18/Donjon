using System;

namespace Donjon
{
    public class Item : Entity
    {
        protected Item(string symbol, ConsoleColor color, string name)
            : base(symbol, color, name)
        {

        }

        public static Item Sock()
        {
            return new Item("s", ConsoleColor.Gray, "dirty sock");
        }

        public static Item Coin()
        {
            return new Item("c", ConsoleColor.Yellow, "coin");
        }

        public static Item Gem()
        {
            return new Item("g", ConsoleColor.DarkMagenta, "gem");
        }

    }
}