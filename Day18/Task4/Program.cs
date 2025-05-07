using System;
using System.Collections;
using System.Collections.Generic;

class MusicCatalog
{
    // Ключ - название диска, значение - список песен
    private Hashtable catalog = new Hashtable();

    // Добавить диск, возвращает true если добавлен, false если диск уже существует
    public bool AddDisk(string diskName)
    {
        if (catalog.ContainsKey(diskName))
            return false;

        catalog[diskName] = new List<string>();
        return true;
    }

    // Удалить диск, возвращает true если удалён, false если не найден
    public bool RemoveDisk(string diskName)
    {
        return catalog.Remove(diskName);
    }

    // Добавить песню в диск, возвращает true если добавлена, false если диск не найден или песня уже есть
    public bool AddSong(string diskName, string songName)
    {
        if (!catalog.ContainsKey(diskName))
            return false;

        var songs = (List<string>)catalog[diskName];
        if (songs.Contains(songName))
            return false;

        songs.Add(songName);
        return true;
    }

    // Удалить песню из диска, возвращает true если удалена, false если диск или песня не найдены
    public bool RemoveSong(string diskName, string songName)
    {
        if (!catalog.ContainsKey(diskName))
            return false;

        var songs = (List<string>)catalog[diskName];
        return songs.Remove(songName);
    }

    // Получить список всех дисков (названия)
    public List<string> GetAllDisks()
    {
        List<string> disks = new List<string>();
        foreach (string key in catalog.Keys)
        {
            disks.Add(key);
        }
        return disks;
    }

    // Получить список песен диска, или null если диск не найден
    public List<string> GetSongs(string diskName)
    {
        if (!catalog.ContainsKey(diskName))
            return null;

        // Возвращаем копию списка, чтобы внешний код не мог изменить внутренний список напрямую
        var songs = (List<string>)catalog[diskName];
        return new List<string>(songs);
    }
}

class Program
{
    static void Main()
    {
        MusicCatalog catalog = new MusicCatalog();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1 - Добавить диск");
            Console.WriteLine("2 - Удалить диск");
            Console.WriteLine("3 - Добавить песню в диск");
            Console.WriteLine("4 - Удалить песню из диска");
            Console.WriteLine("5 - Показать весь каталог");
            Console.WriteLine("6 - Показать содержимое диска");
            Console.WriteLine("0 - Выход");
            Console.Write("Выберите действие: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Write("Введите название диска: ");
                    string newDisk = Console.ReadLine();
                    if (catalog.AddDisk(newDisk))
                        Console.WriteLine($"Диск \"{newDisk}\" добавлен.");
                    else
                        Console.WriteLine($"Диск \"{newDisk}\" уже существует.");
                    break;

                case "2":
                    Console.Write("Введите название диска для удаления: ");
                    string delDisk = Console.ReadLine();
                    if (catalog.RemoveDisk(delDisk))
                        Console.WriteLine($"Диск \"{delDisk}\" удалён.");
                    else
                        Console.WriteLine($"Диск \"{delDisk}\" не найден.");
                    break;

                case "3":
                    Console.Write("Введите название диска: ");
                    string diskForAddSong = Console.ReadLine();
                    Console.Write("Введите название песни: ");
                    string newSong = Console.ReadLine();
                    if (catalog.AddSong(diskForAddSong, newSong))
                        Console.WriteLine($"Песня \"{newSong}\" добавлена в диск \"{diskForAddSong}\".");
                    else
                        Console.WriteLine($"Ошибка: диск \"{diskForAddSong}\" не найден или песня уже существует.");
                    break;

                case "4":
                    Console.Write("Введите название диска: ");
                    string diskForRemoveSong = Console.ReadLine();
                    Console.Write("Введите название песни для удаления: ");
                    string delSong = Console.ReadLine();
                    if (catalog.RemoveSong(diskForRemoveSong, delSong))
                        Console.WriteLine($"Песня \"{delSong}\" удалена из диска \"{diskForRemoveSong}\".");
                    else
                        Console.WriteLine($"Ошибка: диск \"{diskForRemoveSong}\" или песня \"{delSong}\" не найдены.");
                    break;

                case "5":
                    List<string> disks = catalog.GetAllDisks();
                    if (disks.Count == 0)
                    {
                        Console.WriteLine("Каталог пуст.");
                    }
                    else
                    {
                        Console.WriteLine("Каталог дисков:");
                        foreach (var disk in disks)
                        {
                            var songs = catalog.GetSongs(disk);
                            Console.WriteLine($"- {disk} ({songs.Count} песен)");
                        }
                    }
                    break;

                case "6":
                    Console.Write("Введите название диска для просмотра: ");
                    string diskToShow = Console.ReadLine();
                    var songsList = catalog.GetSongs(diskToShow);
                    if (songsList == null)
                    {
                        Console.WriteLine($"Диск \"{diskToShow}\" не найден.");
                    }
                    else if (songsList.Count == 0)
                    {
                        Console.WriteLine($"Диск \"{diskToShow}\" пуст.");
                    }
                    else
                    {
                        Console.WriteLine($"Песни в диске \"{diskToShow}\":");
                        int i = 1;
                        foreach (var song in songsList)
                        {
                            Console.WriteLine($"{i}. {song}");
                            i++;
                        }
                    }
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Попробуйте снова.");
                    break;
            }
        }
    }
}
