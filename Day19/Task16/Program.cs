using System;
using System.IO;
using System.Runtime.InteropServices;

/// <summary>
/// Класс программы для работы с файлами и каталогами на локальных дисках.
/// Выполняет вывод списка файлов, создание каталогов, копирование файлов,
/// изменение атрибутов и создание символических ссылок.
/// </summary>
class Program
{
    /// <summary>
    /// Точка входа в программу.
    /// <para>Выполняет следующие действия:</para>
    /// <list type="number">
    /// <item>Выводит список всех файлов на локальных фиксированных дисках (корневой каталог).</item>
    /// <item>Создаёт каталог "Example_36tp" на первом доступном из дисков D, C или V.</item>
    /// <item>Копирует первые три файла из указанного исходного каталога в созданный каталог.</item>
    /// <item>Устанавливает атрибут "Скрытый" для скопированных файлов.</item>
    /// <item>Создаёт символические ссылки на скопированные файлы в том же каталоге.</item>
    /// </list>
    /// </summary>
    static void Main()
    {
        try
        {
            // 1. Вывести список всех файлов на локальных дисках
            Console.WriteLine("Список всех файлов на локальных дисках:");
            foreach (var drive in DriveInfo.GetDrives())
            {
                if (drive.IsReady && drive.DriveType == DriveType.Fixed)
                {
                    Console.WriteLine($"Диск: {drive.Name}");
                    try
                    {
                        // Получаем все файлы на корне диска (рекурсивно не делаем, чтобы не тормозить)
                        string[] files = Directory.GetFiles(drive.RootDirectory.FullName);
                        foreach (var file in files)
                        {
                            Console.WriteLine(file);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка доступа к файлам диска {drive.Name}: {ex.Message}");
                    }
                    Console.WriteLine();
                }
            }

            // 2. Создать каталог Example_36tp на диске D, C или V (проверяем по очереди)
            string[] possibleDrives = { "D:\\", "C:\\", "V:\\" };
            string targetDrive = null;
            foreach (var d in possibleDrives)
            {
                if (Directory.Exists(d))
                {
                    targetDrive = d;
                    break;
                }
            }
            if (targetDrive == null)
            {
                Console.WriteLine("Не найден диск D, C или V.");
                return;
            }

            string targetDir = Path.Combine(targetDrive, "Example_36tp");
            Directory.CreateDirectory(targetDir);
            Console.WriteLine($"Каталог создан: {targetDir}");

            // 3. Копировать 3 разных файла из другого каталога (укажите источник)
            string sourceDir = @"C:\Temp\SourceFiles"; // Укажите существующий путь с файлами
            if (!Directory.Exists(sourceDir))
            {
                Console.WriteLine($"Исходный каталог не найден: {sourceDir}");
                return;
            }

            string[] sourceFiles = Directory.GetFiles(sourceDir);
            if (sourceFiles.Length < 3)
            {
                Console.WriteLine("В исходном каталоге меньше 3 файлов.");
                return;
            }

            // Копируем первые 3 файла
            for (int i = 0; i < 3; i++)
            {
                string sourceFile = sourceFiles[i];
                string destFile = Path.Combine(targetDir, Path.GetFileName(sourceFile));
                File.Copy(sourceFile, destFile, overwrite: true);

                // 4. Поменять атрибуты скопированных файлов на Скрытый
                File.SetAttributes(destFile, FileAttributes.Hidden);

                // 5. Создать вместо них файлы-ссылки (ярлыки)
                // В Windows создание ярлыков требует COM-интерфейса, но можно создать символическую ссылку (требует прав администратора)
                string linkPath = Path.Combine(targetDir, Path.GetFileNameWithoutExtension(sourceFile) + "_link" + Path.GetExtension(sourceFile));
                CreateSymbolicLink(linkPath, destFile);
                Console.WriteLine($"Скопирован и скрыт файл: {destFile}");
                Console.WriteLine($"Создана ссылка: {linkPath}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }

    /// <summary>
    /// Импорт функции CreateSymbolicLink из kernel32.dll для создания символической ссылки.
    /// </summary>
    /// <param name="lpSymlinkFileName">Путь к создаваемой символической ссылке.</param>
    /// <param name="lpTargetFileName">Путь к целевому файлу.</param>
    /// <param name="dwFlags">Флаги создания (0 для файла, 1 для каталога).</param>
    /// <returns><c>true</c>, если символическая ссылка создана успешно; иначе <c>false</c>.</returns>
    [DllImport("kernel32.dll", CharSet = CharSet.Unicode)]
    static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, int dwFlags);

    /// <summary>
    /// Создаёт символическую ссылку на файл.
    /// Требует прав администратора.
    /// </summary>
    /// <param name="linkPath">Путь, по которому будет создана символическая ссылка.</param>
    /// <param name="targetPath">Путь к целевому файлу, на который будет указывать ссылка.</param>
    static void CreateSymbolicLink(string linkPath, string targetPath)
    {
        const int SYMBOLIC_LINK_FLAG_FILE = 0x0;
        bool success = CreateSymbolicLink(linkPath, targetPath, SYMBOLIC_LINK_FLAG_FILE);
        if (!success)
        {
            Console.WriteLine($"Не удалось создать символическую ссылку: {linkPath}");
        }
    }
}
