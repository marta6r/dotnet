using System;
using System.Collections.Generic;

// Класс записи дневника
public class DiaryEntry : ICloneable
{
    public DateTime? Date { get; set; }  // nullable дата
    public string Title { get; set; }
    public string Content { get; set; }

    public DiaryEntry(DateTime? date, string title, string content)
    {
        Date = date;
        Title = title;
        Content = content;
    }

    // Реализация клонирования (глубокое клонирование не требуется, т.к. все поля - immutable или value types)
    public object Clone()
    {
        return new DiaryEntry(Date, Title, Content);
    }

    public override string ToString()
    {
        string dateStr = Date.HasValue ? Date.Value.ToShortDateString() : "Без даты";
        return $"[{dateStr}] {Title}: {Content}";
    }
}

// Класс-прототип для дневника с обобщённым методом
public class Diary<T> where T : ICloneable
{
    private List<T> entries = new List<T>();

    // Добавление записи
    public void AddEntry(T entry)
    {
        entries.Add(entry);
    }

    // Удаление записи
    public bool RemoveEntry(T entry)
    {
        return entries.Remove(entry);
    }

    // Клонирование дневника (создаёт новый дневник с клонами всех записей)
    public Diary<T> Clone()
    {
        Diary<T> clone = new Diary<T>();
        foreach (var entry in entries)
        {
            clone.AddEntry((T)entry.Clone());
        }
        return clone;
    }

    // Получить все записи
    public List<T> GetAllEntries()
    {
        return new List<T>(entries);
    }

    public override string ToString()
    {
        if (entries.Count == 0)
            return "Дневник пуст.";

        return string.Join(Environment.NewLine, entries);
    }
}

class Program
{
    static void Main()
    {
        // Создаём дневник записей
        Diary<DiaryEntry> myDiary = new Diary<DiaryEntry>();

        // Добавляем записи (с nullable датами)
        myDiary.AddEntry(new DiaryEntry(DateTime.Now, "Утро", "Проснулся рано и сделал зарядку."));
        myDiary.AddEntry(new DiaryEntry(null, "Без даты", "Запись без даты."));
        myDiary.AddEntry(new DiaryEntry(DateTime.Today.AddDays(-1), "Вчера", "Работал над проектом."));

        Console.WriteLine("Исходный дневник:");
        Console.WriteLine(myDiary);

        // Удаляем запись
        var toRemove = new DiaryEntry(null, "Без даты", "Запись без даты.");
        // Для удаления нужно найти объект в списке, т.к. объекты разные по ссылке, удалим по содержимому:
        var entries = myDiary.GetAllEntries();
        foreach (var entry in entries)
        {
            if (entry.Title == toRemove.Title && entry.Content == toRemove.Content && entry.Date == toRemove.Date)
            {
                myDiary.RemoveEntry(entry);
                break;
            }
        }

        Console.WriteLine("\nПосле удаления записи без даты:");
        Console.WriteLine(myDiary);

        // Клонирование дневника
        Diary<DiaryEntry> clonedDiary = myDiary.Clone();
        Console.WriteLine("\nКлонированный дневник:");
        Console.WriteLine(clonedDiary);

        // Работа с Dictionary: ключ - дата (string), значение - запись дневника
        Dictionary<string, DiaryEntry> diaryDict = new Dictionary<string, DiaryEntry>();
        foreach (var entry in myDiary.GetAllEntries())
        {
            string key = entry.Date.HasValue ? entry.Date.Value.ToShortDateString() : "Без даты";
            diaryDict[key] = entry;
        }

        Console.WriteLine("\nСодержимое словаря (ключ - дата):");
        foreach (var kvp in diaryDict)
        {
            Console.WriteLine($"Ключ: {kvp.Key}, Значение: {kvp.Value}");
        }

        // Демонстрация nullable-типа
        int? nullableNumber = null;
        Console.WriteLine($"\nNullable число изначально: {nullableNumber}");
        nullableNumber = 100;
        Console.WriteLine($"Nullable число после присвоения: {nullableNumber}");
    }
}