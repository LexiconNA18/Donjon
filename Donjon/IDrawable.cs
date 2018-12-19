using System;

namespace Donjon
{
    public interface IDrawable
    {
        string Symbol { get; }
        ConsoleColor Color { get; }
    }
}