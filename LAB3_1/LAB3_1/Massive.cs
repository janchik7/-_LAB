using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{
    public class MatrixFiller
    {
        // Двумерный массив
        private int[,] matrix;

        // Конструктор для первого массива (по столбцам от последних к первым)
        public MatrixFiller(int n, int m)
        {
            matrix = new int[n, m];
            Console.WriteLine("Заполнение массива вручную:");

            // Заполнение массива по столбцам от последних элементов
            for (int j = 0; j < m; j++)
            {
                Console.WriteLine($"Заполнение столбца {j + 1}:");
                for (int i = n - 1; i >= 0; i--)
                {
                    matrix[i, j] = ReadInt($"Введите элемент [{i + 1}][{j + 1}]: ");
                }
            }
        }


        // Конструктор для второго массива (случайные числа, возрастающие по столбцам)
        public MatrixFiller(int n)
        {
            matrix = new int[n, n];
            Random random = new Random();

            // Заполнение массива случайными числами в возрастающем порядке по столбцам
            for (int j = 0; j < n; j++)
            {
                int r = random.Next(1000);
                for (int i = 0; i < n; i++)
                {
                    matrix[i, j] = r + random.Next(100);
                    r = matrix[i, j];
                }
            }
        }

        // Конструктор для третьего массива (последовательность простых чисел)
        public MatrixFiller()
        {
            int n = ReadDouble("N: ");
            matrix = new int[n, n];
            int[] primes = GeneratePrimes(n * n); // Генерация первых n*n простых чисел
            int k = 0;

            // Заполнение массива простыми числами
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = primes[k++];
                }
            }
        }

        // Метод для вывода массива на экран
        public void PrintMatrix()
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        // Метод для генерации первых n простых чисел
        private int[] GeneratePrimes(int count)
        {
            int[] primes = new int[count];
            int num = 2, primeCount = 0;

            while (primeCount < count)
            {
                if (IsPrime(num))
                {
                    primes[primeCount++] = num;
                }
                num++;
            }
            return primes;
        }

        // Метод для проверки, является ли число простым
        private bool IsPrime(int num)
        {
            if (num <= 1) return false;
            for (int i = 2; i * i <= num; i++)
            {
                if (num % i == 0)
                {
                    return false;
                }
            }
            return true;
        }

        // Проверка на корректность ввода
        public int ReadInt(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                string input = Console.ReadLine();

                if (int.TryParse(input, out value))
                {
                    return value;
                }
                else
                {
                    Console.WriteLine("Ошибка: введено некорректное значение. Пожалуйста, введите целое число.");
                }
            }
        }

        // Метод для безопасного ввода чисел с обработкой исключений
        internal static int ReadDouble(string message)
        {
            int value;
            while (true)
            {
                Console.Write(message);
                // Попытка преобразования ввода в число
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    if (value > 0)
                        return value;
                }
                Console.WriteLine("Ошибка ввода! Введите целое число.");
            }
        }

        // Конструктор для задания 2 (оценки школьников)
        public MatrixFiller(int n, int m, bool isGrades)
        {
            matrix = new int[n, m];
            Random rand = new Random();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    matrix[i, j] = rand.Next(2, 6); // Оценки от 2 до 5
                }
            }
        }

        // Метод для поиска учеников со средней оценкой > 4.5
        public void FindTopStudents()
        {
            Console.WriteLine("Оценки школьников:");
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                double sum = 0;
                Console.Write($"Школьник {i + 1}: ");

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                    sum += matrix[i, j];
                }

                double average = sum / matrix.GetLength(1);
                Console.WriteLine($"| Средний балл: {average:F2}");

                if (average > 4.5)
                {
                    Console.WriteLine($"Школьник {i + 1} имеет средний балл выше 4.5!");
                }
            }
        }
    }
}
