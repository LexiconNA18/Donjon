using System;

namespace Donjon
{
    internal class Game
    {
        Map map;
        Hero hero;

        public Game()
        {
            map = new Map(width: 15, height: 15);
            hero = new Hero();
        }
        
        internal void Run()
        {
            Init();

            Draw();
        }

        private void Init()
        {
            map.Cell(1, 1).Creature = hero;
            map.Cell(5, 4).Creature = new Creature("M");
            map.Cell(3, 5).Items.Add(new Item("i"));
        }

        private void Draw()
        {
            for (int y = 0; y < map.Height; y++)
            {
                string row = "";
                for (int x = 0; x < map.Width; x++)
                {
                    var cell = map.Cell(x, y);
                    var symbol = cell.Symbol;
                    row += " " + symbol;                  
                }
                Console.WriteLine(row);
            }
        }
    }
}