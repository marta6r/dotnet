class Program
{
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

    // Метод создания символической ссылки (требует прав администратора)
    // Возвращает true при успехе
    [System.Runtime.InteropServices.DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Unicode)]
    static extern bool CreateSymbolicLink(string lpSymlinkFileName, string lpTargetFileName, int dwFlags);

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