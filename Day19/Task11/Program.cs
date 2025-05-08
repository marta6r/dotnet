using System;
using System.IO;

/// <summary>
/// Класс программы для создания папки с заданным именем.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// Создаёт папку с именем <c>New_folder</c>, если она не существует.
    /// </summary>
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
