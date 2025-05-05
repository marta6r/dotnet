using System;

namespace GameLibrary
{
    public class Game
    {
        private Player player;
        private Enemy enemy;

        public Game(string playerName)
        {
            player = new Player(playerName);
            enemy = new Enemy("Злобный Гоблин", 50, 10);
        }

        public void Start()
        {
            Console.WriteLine($"Игра началась! Игрок: {player.Name}, Враг: {enemy.Name}");
            while (player.IsAlive && enemy.IsAlive)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1 - Атаковать");
                Console.WriteLine("2 - Отступить");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AttackEnemy();
                    if (enemy.IsAlive)
                    {
                        enemy.Attack(player);
                    }
                }
                else if (choice == "2")
                {
                    Console.WriteLine("Вы отступили. Игра окончена.");
                    break;
                }
                else
                {
                    Console.WriteLine("Неверный выбор, попробуйте снова.");
                }
            }

            if (!player.IsAlive)
                Console.WriteLine("Вы проиграли...");
            else if (!enemy.IsAlive)
            {
                Console.WriteLine("Вы победили врага!");
                player.LevelUp();
            }
        }

        private void AttackEnemy()
        {
            int damage = 15; // фиксированный урон игрока
            Console.WriteLine($"{player.Name} атакует {enemy.Name} и наносит {damage} урона!");
            enemy.TakeDamage(damage);
        }
    }
}