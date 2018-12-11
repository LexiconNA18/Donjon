using System;

namespace Donjon
{
    public class Creature : Entity
    {
        private Messages messages = new Messages();

        public Creature(string symbol, ConsoleColor color, string name)
            : base(symbol, color, name)
        {
        }

        public int X { get; internal set; }
        public int Y { get; internal set; }

        public int Health { get; set; } = 1;
        public int Damage { get; set; }

        public bool IsDead => Health <= 0;

        internal void SetMessageHandler(Messages messages)
        {
            this.messages = messages;
        }

        public void Fight(Creature target)
        {
            if (target.IsDead) return;

            target.Health -= Damage;
            messages.Add($"The {Name} attacks the {target.Name} for {Damage} damage");
            if (target.IsDead) {
                messages.Add($"The {target.Name} is dead");
                return;
            }

            Health -= target.Damage;
            messages.Add($"The {target.Name} attacks the {Name} for {target.Damage} damage");
            if (IsDead)
            {
                messages.Add($"The {Name} is dead");
                return;
            }
        }
    }
}