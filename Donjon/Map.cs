using System;

namespace Donjon
{


    internal class Map
    {
        Cell[,] cells;

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
                    cells[x, y] = new Cell();
                }
            }
        }


        internal Cell Cell(int x, int y)
        {
            return cells[x, y];
        }
    }
}