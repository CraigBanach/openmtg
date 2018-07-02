using Microsoft.Extensions.DependencyInjection;
using System;

namespace MTGEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            for (var i = 0; i < 100; i++)
            {
                var gm = new GameManager();
                gm.StartGame();

            }
        }
    }
}
