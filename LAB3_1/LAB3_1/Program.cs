using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB3
{ 
    public class Program
    {

        public static void Main(string[] args)
        {
            //Задание 1
            // Пример использования для первого массива (ввод с клавиатуры)
            Console.WriteLine("Задание 1: Заполнение массива вручную.");
            int n = (int)MatrixFiller.ReadDouble("N: ");
            int m = (int)MatrixFiller.ReadDouble("M: ");
            MatrixFiller matrix1 = new MatrixFiller(n, m);
            matrix1.PrintMatrix();

            // Пример использования для второго массива (случайные числа)
            Console.WriteLine("\nЗадание 1.2: Заполнение массива случайными числами.");
            int n2 = (int)MatrixFiller.ReadDouble("N: ");
            MatrixFiller matrix2 = new MatrixFiller(n2);
            matrix2.PrintMatrix();

            // Пример использования для третьего массива (простые числа)
            Console.WriteLine("\nЗадание 1.3: Заполнение массива простыми числами.");
            MatrixFiller matrix3 = new MatrixFiller();
            matrix3.PrintMatrix();

            // Задание 2: Поиск учеников со средней оценкой > 4.5
            Console.WriteLine("\nЗадание 2: Оценки школьников.");
            int n4 = (int)MatrixFiller.ReadDouble("N: ");
            int m4 = (int)MatrixFiller.ReadDouble("M: ");
            MatrixFiller students = new MatrixFiller(n4, m4, true);
            students.FindTopStudents();

            // Задание 4:
            Console.WriteLine("Задание 4:");
            Binary.t4_Create(100);
            Binary.t4_Read(100);

            // Задание 6
            Console.WriteLine("\n\n\nЗадание 6:");
            Binary.t6_Create(100);
            Binary.t6_Read();

            // Задание 7
            Console.WriteLine("\n\n\nЗадание 7:");
            Binary.t7_Create(10);
            Binary.t7_Read();
        }

    }
}