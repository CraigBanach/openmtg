using Microsoft.Extensions.DependencyInjection;
using System;

namespace MTGEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine();

            var gm = new GameManager();
            gm.StartGame();
        }
    }
}
