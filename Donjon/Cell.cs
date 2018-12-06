using System.Collections.Generic;

namespace Donjon
{
    internal class Cell
    {
        public Creature Creature { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
    }
}