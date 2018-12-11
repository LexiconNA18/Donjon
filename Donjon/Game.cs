using System;
using System.Collections.Generic;

namespace Donjon
{
    internal class Game
    {
        private Map map;
        private Hero hero;
        private Messages messages = new Messages();

        public Game()
        {
            map = new Map(width: 15, height: 15);

        }

        internal void Run()
        {
            Init();
            Draw();
            bool gameInProcess = true;



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
                        action = map.MoveCreature(hero, dx: 0, dy: -1);
                        break;
                    case ConsoleKey.DownArrow:
                        // gå norrut
                        action = map.MoveCreature(hero, dx: 0, dy: 1);
                        break;
                    case ConsoleKey.LeftArrow:
                        // gå norrut
                        action = map.MoveCreature(hero, dx: -1, dy: 0);
                        break;
                    case ConsoleKey.RightArrow:
                        // gå norrut
                        action = map.MoveCreature(hero, dx: 1, dy: 0);
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
                foreach (string m in messages.GetAll())
                {
                    Console.WriteLine(m);
                }
                messages.Clear();

            } while (gameInProcess);
        }

        private void Init()
        {

            map.SetMessageHandler(messages);

            hero = new Hero()
            {
                Health = 10,
                Damage = 3
            };
            hero.SetMessageHandler(messages);
            map.Cell(1, 1).Creature = hero;

            Monster troll = new Monster("T", ConsoleColor.Green, "Troll")
            {
                Health = 4,
                Damage = 2,
            };
            troll.SetMessageHandler(messages);
            map.Cell(5, 4).Creature = troll;

            Monster orc = new Monster("O", ConsoleColor.Green, "Orc")
            {
                Health = 3,
                Damage = 1,
            };
            orc.SetMessageHandler(messages);
            map.Cell(8, 5).Creature = orc;

            Item sock = new Item("s", ConsoleColor.Gray, "dirty sock");
            map.Cell(3, 5).Items.Add(sock);
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