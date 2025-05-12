public sealed class Singleton
{
    // Приватное статическое поле для хранения единственного экземпляра
    private static Singleton instance = null;

    // Объект для блокировки при многопоточном доступе
    private static readonly object padlock = new object();

    // Приватный конструктор, чтобы предотвратить создание экземпляров извне
    private Singleton()
    {
    } 

    // Публичный статический метод (свойство) для доступа к экземпляру
    public static Singleton Instance
    {
        get
        {
            // Двойная проверка блокировки для потокобезопасности и ленивой инициализации
            if (instance == null)
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                }
            }
            return instance;
        }
    }

    // Пример метода класса
    public void DoSomething()
    {
        Console.WriteLine("Singleton instance invoked.");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Singleton s1 = Singleton.Instance;
        s1.DoSomething();

        Singleton s2 = Singleton.Instance;
        Console.WriteLine(object.ReferenceEquals(s1, s2)); // True - один и тот же объект
    }
}
