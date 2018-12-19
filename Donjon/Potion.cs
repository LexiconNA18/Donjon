using System;

namespace Donjon
{
    internal class Potion : Item, IUsable
    {
        protected Potion(string symbol, ConsoleColor color, string name)
            : base(symbol, color, name)
        {
        }


      
        public void Use(Creature user) {
            user.Health += 5;
        }

        internal static Potion HealthPotion()
        {
            return new Potion("p", ConsoleColor.Red, "health potion");
        }


    }
}