namespace GameLibrary
{
    public interface ICharacter
    {
        string Name { get; }
        int Health { get; }
        void TakeDamage(int damage);
        bool IsAlive { get; }
    }
}