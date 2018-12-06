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
            throw new NotImplementedException();
        }
    }
}