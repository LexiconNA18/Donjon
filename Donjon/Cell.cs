using System.Collections.Generic;

namespace Donjon
{
    internal class Cell
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Cell(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        private Creature creature;
        public Creature Creature {
            get => creature;
            set {
                if (value != null)
                {
                    value.X = this.X;
                    value.Y = this.Y;
                }
                creature = value;
            }
        }
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