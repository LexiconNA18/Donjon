using System;
using System.Collections.Generic;

namespace Donjon
{


    internal class Map
    {
        Cell[,] cells;

        private Messages messages = new Messages();

        private int width;
        public int Width {
            get => width;
            private set => width = value;
        }

        private int height;
        public int Height {
            get { return height; }
            private set { height = value; }
        }

        public Map(int width, int height)
        {
            this.Width = width;
            this.Height = height;
            cells = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    cells[x, y] = new Cell(x, y);
                }
            }
        }

        internal void SetMessageHandler(Messages messages)
        {
            this.messages = messages;
        }

        internal Cell Cell(int x, int y)
        {
            if (x < 0 || y < 0) return null;
            if (x >= Width || y >= Height) return null;
            return cells[x, y];
        }

        internal bool MoveCreature(Creature creature, int dx, int dy)
        {
            int oldX = creature.X;
            int oldY = creature.Y;

            var newX = oldX + dx;
            var newY = oldY + dy;

            Cell newCell = Cell(newX, newY);
            if (newCell == null) return false;
            if (newCell.Creature != null)
            {
                creature.Fight(newCell.Creature);
                return true;
            }

            Cell(oldX, oldY).Creature = null;            
            newCell.Creature = creature;
            
            
            messages.Add("The creature moves one step");
            
            return true;
        }
    }
}