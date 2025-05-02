public class MyDictionary<TKey, TValue>
{
    private struct Entry
    {
        public TKey Key;
        public TValue Value;
    }

    private Entry[] entries;
    private int count;

    public MyDictionary()
    {
        entries = new Entry[4];
        count = 0;
    }

    // Свойство только для чтения - количество пар элементов
    public int Count => count;

    // Индексатор для получения значения по ключу
    public TValue this[TKey key]
    {
        get
        {
            for (int i = 0; i < count; i++)
            {
                if (entries[i].Key.Equals(key))
                {
                    return entries[i].Value;
                }
            }
            throw new KeyNotFoundException();
        }
    }

    // Метод добавления пары элементов
    public void Add(TKey key, TValue value)
    {
        if (count == entries.Length)
        {
            Array.Resize(ref entries, entries.Length * 2);
        }
        entries[count++] = new Entry { Key = key, Value = value };
    }
}

class Program
{
    static void Main()
    {
        MyDictionary<string, int> myDict = new MyDictionary<string, int>();
        myDict.Add("one", 1);
        myDict.Add("two", 2);
        myDict.Add("three", 3);

        Console.WriteLine($"Количество пар: {myDict.Count}");
        Console.WriteLine($"Значение по ключу 'two': {myDict["two"]}");
    }
}