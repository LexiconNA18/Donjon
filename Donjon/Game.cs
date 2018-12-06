using System;
using System.Collections.Generic;

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
            bool gameInProcess = true;
            List<string> messages = new List<string>();

            do
            {
                // input
                var key = Console.ReadKey(intercept: true).Key;

                // act
                bool action = false;
                switch (key)
                {
                    case ConsoleKey.X:
                    case ConsoleKey.Q:
                        // avsluta spelet
                        gameInProcess = false;
                        break;
                    case ConsoleKey.UpArrow:
                        // gå norrut
                        action = map.MoveCreature(hero, dx: 0, dy: -1, messages: messages);
                        break;
                    case ConsoleKey.DownArrow:
                        // gå norrut
                        action = map.MoveCreature(hero, dx: 0, dy: 1, messages: messages);
                        break;
                    case ConsoleKey.LeftArrow:
                        // gå norrut
                        action = map.MoveCreature(hero, dx: -1, dy: 0, messages: messages);
                        break;
                    case ConsoleKey.RightArrow:
                        // gå norrut
                        action = map.MoveCreature(hero, dx: 1, dy: 0, messages: messages);
                        break;
                    default:
                        // känns inte igen
                        break;
                }

                // draw
                Draw();
                if (!action)
                {
                    messages.Add("No action");
                }
                foreach (var m in messages)
                {
                    Console.WriteLine(m);
                }

            } while (gameInProcess);
        }

        private void Init()
        {
            map.Cell(1, 1).Creature = hero;
            map.Cell(5, 4).Creature = new Creature("M");
            map.Cell(3, 5).Items.Add(new Item("i"));
        }

        private void Draw()
        {
            Console.Clear();
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