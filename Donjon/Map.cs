namespace Donjon
{


    internal class Map
    {
        Cell[,] map;
        private int width;
        private int height;

        public Map(int width, int height)
        {
            this.width = width;
            this.height = height;
            map = new Cell[width, height];
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    map[x, y] = new Cell();
                }
            }
        }
    }
}