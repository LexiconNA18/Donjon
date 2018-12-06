namespace Donjon
{
    public abstract class Entity
    {
        public string Symbol { get; private set; }

        public Entity(string symbol)
        {
            this.Symbol = symbol;
        }
    }
}