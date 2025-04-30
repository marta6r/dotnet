delegate string MessageDelegate();

class Program
{
    static string GetHelloMessage() => "Привет, мир!";
    static string GetTimeMessage() => $"Текущее время: {DateTime.Now:T}";
    static string GetRandomMessage()
    {
        string[] messages = { "Внимание!", "Успех!", "Ошибка!" };
        return messages[new Random().Next(0, messages.Length)];
    }

    // Метод с параметром-делегатом
    static void ProcessDelegate(MessageDelegate del)
    {
        try
        {
            foreach (MessageDelegate d in del.GetInvocationList())
            {
                try
                {
                    Console.WriteLine(d());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в {d.Method.Name}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Общая ошибка: {ex.Message}");
        }
    }

    static void Main()
    {
        // Создаем и настраиваем делегат
        MessageDelegate messageDelegate = GetHelloMessage;
        messageDelegate += GetTimeMessage;
        messageDelegate += GetRandomMessage;

        // Передаем делегат в метод
        ProcessDelegate(messageDelegate);
    }
}