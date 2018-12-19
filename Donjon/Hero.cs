using System;
using GameLib;

namespace Donjon
{
    internal class Hero : Creature
    {
        public LimitedList<Item> Backpack { get; } 
            = new LimitedList<Item>(2);

        public Hero() : base("H", ConsoleColor.Cyan, "Hero")
        {
        }
    }
}
