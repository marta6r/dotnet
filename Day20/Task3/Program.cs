using System;
using System.Threading.Tasks;

class Program
{
    // Метод перестановки цифр двузначного числа
    static int SwapDigits(int number)
    {
        if (number < 10 || number > 99)
            throw new ArgumentException("Число должно быть двузначным.");

        int tens = number / 10;
        int units = number % 10;

        return units * 10 + tens;
    }

    static void Main()
    {
        int inputNumber = 42; // Пример двузначного числа

        // Первый объект Task, который вычисляет перестановку цифр
        Task<int> task1 = Task.Run(() =>
        {
            Console.WriteLine($"Вычисление перестановки цифр числа {inputNumber}...");
            int swapped = SwapDigits(inputNumber);
            return swapped;
        });

        // Второй объект Task - задача продолжения, которая выводит результат первой задачи
        Task task2 = task1.ContinueWith(antecedent =>
        {
            Console.WriteLine($"Результат перестановки цифр числа {inputNumber}: {antecedent.Result}");
        });

        // Ждём завершения задачи продолжения, чтобы программа не завершилась раньше времени
        task2.Wait();
    }
}
