using System;

namespace GameLibrary
{
    public class Enemy : ICharacter
    {
        public string Name { get; private set; }
        public int Health { get; private set; }
        public int Damage { get; private set; }

        public bool IsAlive => Health > 0;

        public Enemy(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
            Console.WriteLine($"{Name} получил {damage} урона. Здоровье: {Health}");
        }

        public void Attack(ICharacter target)
        {
            if (!IsAlive)
            {
                Console.WriteLine($"{Name} мёртв и не может атаковать.");
                return;
            }

            Console.WriteLine($"{Name} атакует {target.Name} и наносит {Damage} урона!");
            target.TakeDamage(Damage);
        }
    }
}