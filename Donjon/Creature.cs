namespace Donjon
{
    public class Creature : Entity
    {
        public Creature(string symbol) : base(symbol)
        {

        }

        public int X { get; internal set; }
        public int Y { get; internal set; }
    }
}