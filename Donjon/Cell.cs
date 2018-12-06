using System.Collections.Generic;

namespace Donjon
{
    internal class Cell
    {
        public Creature Creature { get; set; }
        public List<Item> Items { get; set; } = new List<Item>();
        public string Symbol {
            get {
                if (Creature != null) return Creature.Symbol;
                if (Items.Count > 0) return Items[0].Symbol;
                return ".";
            }
        }
    }
}