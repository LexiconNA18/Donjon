using System;
using System.Collections.Generic;

namespace Donjon
{
    public class Creature : Entity
    {
        
        public Creature(string symbol, ConsoleColor color, string name)
            : base(symbol, color, name)
        {
        }

        public override ConsoleColor Color => IsDead ? ConsoleColor.DarkGray : base.Color;

        public int X { get; internal set; }
        public int Y { get; internal set; }

        public int Health { get; set; } = 1;
        public int Damage { get; set; }

        public bool IsDead => Health <= 0;

        private Action<string> addMessage = s => { };
        // Fattigmanshändelsehanterare
        // private List<Action<string>> onMessage = new List<Action<string>>();


        internal void SetMessageHandler(Action<string> addMessage)
        {
            this.addMessage = addMessage;
        }

        public void Fight(Creature target)
        {
            if (target.IsDead) return;

            target.Health -= Damage;
            addMessage($"The {Name} attacks the {target.Name} for {Damage} damage");
            if (target.IsDead) {
                addMessage($"The {target.Name} is dead");
                return;
            }

            Health -= target.Damage;
            addMessage($"The {target.Name} attacks the {Name} for {target.Damage} damage");
            if (IsDead)
            {
                addMessage($"The {Name} is dead");
                return;
            }
        }
    }
}