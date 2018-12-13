using System;
namespace Donjon
{
    public abstract class Entity
    {
        public string Symbol { get; private set; }
        public virtual ConsoleColor Color { get; private set; }
        public string Name { get; private set; }

        public Entity(string symbol, ConsoleColor color, string name)
        {
            Symbol = symbol;
            Color = color;
            Name = name;
        }
    }
}