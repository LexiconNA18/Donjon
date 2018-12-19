using System;
using System.Linq;
using System.Collections.Generic;

namespace Donjon
{


    internal class Map
    {
        Cell[,] cells;

        private Action<string> addMessage = s => { };

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

        public List<Monster> Monsters => cells
            .OfType<Cell>()
            .Select(c => c.Creature)
            .OfType<Monster>()
            .Where(m => !m.IsDead)
            .ToList();

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

        internal void RemoveDeadMonsters()
        {
            foreach (var cell in cells) {
                if (cell.Creature != null && cell.Creature.IsDead)
                {
                    cell.Creature = null;
                }
            }
        }

        internal void SetMessageHandler(Action<string> addMessage)
        {
            this.addMessage = addMessage;
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
            
            
            addMessage($"The {creature.Name} moves one step");
            
            return true;
        }
    }
}