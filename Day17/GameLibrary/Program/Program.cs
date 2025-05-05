using System;
using GameLibrary;

namespace GameDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите имя игрока: ");
            string playerName = Console.ReadLine();

            Game game = new Game(playerName);
            game.Start();

            Console.WriteLine("Нажмите любую клавишу для выхода...");
            Console.ReadKey();
        }
    }
}