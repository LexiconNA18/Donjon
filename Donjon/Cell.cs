using System;
using System.Collections.Generic;
using System.Linq;

namespace Donjon
{
    internal class Cell : IDrawable
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

        public string Symbol => ".";

        public ConsoleColor Color => ConsoleColor.DarkGray;
    }
}