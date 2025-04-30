// Объявляем делегат
delegate string MessageDelegate();

class Program
{
    // Метод 1
    static string GetHelloMessage()
    {
        return "Привет, мир!";
    }

    // Метод 2
    static string GetTimeMessage()
    {
        return $"Текущее время: {DateTime.Now:T}";
    }

    // Метод 3
    static string GetRandomMessage()
    {
        Random rnd = new Random();
        string[] messages = { "Внимание!", "Успех!", "Ошибка!" };
        return messages[rnd.Next(0, messages.Length)];
    }

    static void Main()
    {
        try
        {
            // Создаем экземпляр делегата
            MessageDelegate messageDelegate = GetHelloMessage;
            
            // Добавляем остальные методы
            messageDelegate += GetTimeMessage;
            messageDelegate += GetRandomMessage;

            // Вызываем все методы через делегат
            foreach (MessageDelegate del in messageDelegate.GetInvocationList())
            {
                try
                {
                    Console.WriteLine(del());
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка в методе {del.Method.Name}: {ex.Message}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Критическая ошибка: {ex.Message}");
        }
    }
}