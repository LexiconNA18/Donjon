using System;
using System.Collections.Generic;
using System.Linq;

namespace Donjon
{
    internal class Game
    {
        private Map map;
        private Hero hero;
        private Messages messages = new Messages();

        private bool gameInProcess;
        private bool acted;

        private Dictionary<ConsoleKey, Action> actionMap;

        public Game()
        {
            map = new Map(width: 15, height: 15);

            actionMap = new Dictionary<ConsoleKey, Action>
            {
                { ConsoleKey.Q, Quit },
                { ConsoleKey.X, Quit },
                { ConsoleKey.UpArrow, MoveNorth },
                { ConsoleKey.DownArrow, MoveSouth },
                { ConsoleKey.LeftArrow, MoveWest },
                { ConsoleKey.RightArrow, MoveEast },
                { ConsoleKey.I, Inventory },
                { ConsoleKey.P, Pickup },
            };

        }



        internal void Run()
        {
            Init();
            Draw();
            gameInProcess = true;

            do
            {
                acted = false;

                // input
                var key = Console.ReadKey(intercept: true).Key;
                map.RemoveDeadMonsters();

                // act
                if (actionMap.ContainsKey(key))
                {
                    Action action = actionMap[key];
                    action();
                }

                if (!acted) messages.Add("No action");
                
                // draw
                Draw();
                

            } while (gameInProcess);
        }

        private void Init()
        {

            map.SetMessageHandler(messages.Add);

            hero = new Hero()
            {
                Health = 4,
                Damage = 1
            };
            hero.SetMessageHandler(messages.Add);
            map.Cell(1, 1).Creature = hero;

            Monster troll = new Monster("T", ConsoleColor.Green, "Troll")
            {
                Health = 4,
                Damage = 2,
            };
            troll.SetMessageHandler(messages.Add);
            map.Cell(5, 4).Creature = troll;

            Monster orc = new Monster("O", ConsoleColor.Green, "Orc")
            {
                Health = 3,
                Damage = 1,
            };
            orc.SetMessageHandler(messages.Add);
            map.Cell(8, 5).Creature = orc;

            map.Cell(3, 5).Items.Add(Item.Sock());
            map.Cell(3, 5).Items.Add(Item.Coin());
            map.Cell(4, 7).Items.Add(Item.Coin());
            map.Cell(6, 7).Items.Add(Item.Gem());

            map.Cell(8, 4).Items.Add(Potion.HealthPotion());

        }

        private void Draw() {
            DrawMap();
            DrawStats();
            WriteMessages();
        }

        private void DrawStats()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"Health: {hero.Health}");
            Console.WriteLine($"Monsters: {map.Monsters.Count}");
        }

        private void WriteMessages() {
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string m in messages.GetAll())
            {
                Console.WriteLine(m);
            }
            messages.Clear();
        }

        private void DrawMap()
        {
            Console.CursorVisible = false;
            Console.Clear();
            //Console.SetCursorPosition(0, 0);
            for (int y = 0; y < map.Height; y++)
            {
                for (int x = 0; x < map.Width; x++)
                {
                    var cell = map.Cell(x, y);
                    var drawable = cell.Creature
                        ?? cell.Items.FirstOrDefault()
                        ?? (IDrawable)cell;

                    Console.ForegroundColor = drawable.Color;
                    Console.Write(" " + drawable.Symbol);
                }
                Console.WriteLine();
            }
        }

        private void Quit() { this.gameInProcess = false; }
        private void MoveNorth() { acted = map.MoveCreature(hero, 0, -1); }
        private void MoveSouth() { acted = map.MoveCreature(hero, 0, 1); }
        private void MoveWest() { acted = map.MoveCreature(hero, -1, 0); }
        private void MoveEast() { acted = map.MoveCreature(hero, 1, 0); }

        private void Pickup()
        {
            var cell = map.Cell(hero.X, hero.Y);

            if (cell.Items.Count == 0) return;

            Item item = cell.Items[0];

            // move this to Use()
            if (item is IUsable usable)
            {
                usable.Use(hero);
                messages.Add($"You use the {item.Name}");
                cell.Items.Remove(item);
                return;
            }

            if (hero.Backpack.IsFull)
            {
                messages.Add("Your backpack is full");
                return;
            };

            hero.Backpack.Add(item);
            cell.Items.Remove(item);
            messages.Add($"You pick up the {item.Name}");
        }

        private void Inventory()
        {
            messages.Add("Inventory:");
            foreach (var item in hero.Backpack)
            {
                messages.Add($" - {item.Name}");
            }
        }
    }
}