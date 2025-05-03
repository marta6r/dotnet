class Program
{
    static void Main()
    {
        string folderName = "New_folder";

        try
        {
            // Создаём папку (если она уже существует, исключения не будет)
            Directory.CreateDirectory(folderName);
            Console.WriteLine($"Папка '{folderName}' успешно создана или уже существует.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании папки: {ex.Message}");
        }
    }
}