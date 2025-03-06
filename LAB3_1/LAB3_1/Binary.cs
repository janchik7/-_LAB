using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace LAB3
{
    public class Binary
    {
        //Задание 4.создание и заполнение файла
        public static void t4_Create(int amount)
        {
            Random rng = new Random();
            using (BinaryWriter writer = new BinaryWriter(File.Open("t4.dat", FileMode.OpenOrCreate)))
            {
                for (int i = 0; i < amount; ++i)
                    writer.Write(rng.Next(1, 101));
            }
        }

        //Задание 4.чтение и вывод файла
        public static void t4_Read(int amount)
        {
            using (System.IO.BinaryReader reader = new System.IO.BinaryReader(File.Open("t4.dat", FileMode.Open)))
            {
                int temp;
                int count = 0;
                for (int i = 0; i < amount; ++i)
                {
                    temp = reader.ReadInt32();
                    System.Console.Write($"{temp} ");
                    if (isValid(temp))
                        ++count;
                }
                System.Console.WriteLine($"\nКоличество подходящих элементов: {count}");
            }
        }

        //Задание 6.создание и заполнение файла
        public static void t6_Create(int amount)
        {
            Random rng = new Random();
            using (System.IO.StreamWriter sw = new StreamWriter("t6.txt"))
            {
                for (int i = 0; i < amount; ++i)
                    sw.WriteLine(rng.Next(0, 1000));
            }
        }

        //Задание 6.чтение и вывод файла
        public static void t6_Read()
        {
            using (System.IO.StreamReader sr = new StreamReader("t6.txt"))
            {
                int min = 99999999;
                int max = 0;
                int temp;
                string line = sr.ReadLine();
                while (line != null)
                {
                    Console.Write($"{line} ");
                    temp = Int32.Parse(line);
                    min = Math.Min(temp, min);
                    max = Math.Max(temp, max);
                    line = sr.ReadLine();
                }
                Console.WriteLine($"min: {min}, max: {max}, arif: {(double)(min + max) / 2}");
            }
        }

        //Задание 7.создание и заполнение файла
        public static void t7_Create(int amount)
        {
            using (System.IO.StreamWriter sw = new StreamWriter("t7.txt"))
            {
                Random rng = new Random();
                for (int i = 0; i < amount / 10; ++i)
                {
                    for (int j = 0; j < 10; ++j)
                        if (j < 9)
                            sw.Write($"{rng.Next(0, 101)} ");
                        else
                            sw.Write(rng.Next(0, 101));
                    sw.Write("\n");
                }
            }
        }

        //Задание 7.чтение и вывод файла
        public static void t7_Read()
        {
            using (System.IO.StreamReader sr = new StreamReader("t7.txt"))
            {
                string line = sr.ReadLine();
                int temp, res = 1;
                while (line != null)
                {
                    foreach (string val in line.Split(' '))
                    {
                        temp = Int32.Parse(val);
                        System.Console.Write($"{temp} ");
                        if (temp % 2 == 0)
                            res *= temp;
                    }
                    System.Console.WriteLine();
                    line = sr.ReadLine();
                }
                System.Console.WriteLine($"Ответ на задачу 7: {res}");
            }
        }


        //квадраты нечетных чисел(4)
        private static bool isValid(int a)
        {
            int i;
            for (i = 1; i * i < a; ++i) ;
            if (i * i == a && i % 2 == 0)
                return true;
            return false;
        }
    }
}
