using System;

namespace GameLibrary
{
    public class Player : ICharacter
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Level { get; private set; }

        public bool IsAlive => Health > 0;

        public Player(string name)
        {
            Name = name;
            Health = 100;
            Level = 1;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} получил {damage} урона. Здоровье: {Health}");
        }

        public void LevelUp()
        {
            Level++;
            Health = 100;
            Console.WriteLine($"{Name} повысил уровень до {Level} и восстановил здоровье!");
        }
    }
}
