using LAB2_2;
using System;

class Program
{
    // Метод для безопасного ввода чисел с обработкой исключений
    static double ReadDouble(string message)
    {
        double value;
        while (true)
        {
            Console.Write(message);
            // Попытка преобразования ввода в число
            if (double.TryParse(Console.ReadLine(), out value))
            {
                return value;
            }
            Console.WriteLine("Ошибка ввода! Введите число.");
        }
    }

    static void Main()
    {
        try
        {
            Console.WriteLine("Введите координаты первого отрезка:");
            double x1 = ReadDouble("Начало: ");
            double x2 = ReadDouble("Конец: ");
            LineSegment segment1 = new LineSegment(x1, x2); // Создание первого отрезка
            Console.WriteLine(segment1.ToString());

            Console.WriteLine("Введите координаты второго отрезка:");
            double x3 = ReadDouble("Начало: ");
            double x4 = ReadDouble("Конец: ");
            LineSegment segment2 = new LineSegment(x3, x4); // Создание второго отрезка
            Console.WriteLine(segment2.ToString());

            // Проверка и вывод результата пересечения
            Console.WriteLine($"Пересекаются ли отрезки? {segment1.Intersects(segment2)}");

            // Пример унарной операции
            double length1 = !segment1; // Длина первого отрезка
            double length2 = !segment2; // Длина второго отрезка
            Console.WriteLine($"Длина первого отрезка: {length1}");
            Console.WriteLine($"Длина второго отрезка: {length2}");

            // Пример операции увеличения отрезка
            segment1++;
            segment2++;
            Console.WriteLine($"Расширенный первый отрезок: {segment1}");
            Console.WriteLine($"Расширенный второй отрезок: {segment2}");
            
            // Примеры приведения типов
            int intPart1 = segment1; // Неявное преобразование
            int intPart2 = segment2; // Неявное преобразование
            double doublePart1 = (double)segment1; // Явное преобразование
            double doublePart2 = (double)segment2; // Явное преобразование
            Console.WriteLine($"Целая часть X первого отрезка: {intPart1}");
            Console.WriteLine($"Целая часть X второго отрезка: {intPart2}");
            Console.WriteLine($"Y первого отрезка в double: {doublePart1}");
            Console.WriteLine($"Y второго отрезка в double: {doublePart2}");
        }
        catch (Exception ex)
        {
            // Обработка любых исключений
            Console.WriteLine("Ошибка: " + ex.Message);
        }
    }
}
