using System;

namespace Donjon
{
    class Monster : Creature
    {
        public Monster(string symbol, ConsoleColor color, string name) 
            : base(symbol, color, name)
        {
        }
    }
}