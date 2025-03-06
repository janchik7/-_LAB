using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{
    public class Program
    {
        public static void Main()
        {
            // Тестирование основного класса
            Basic_Class logical1 = new Basic_Class(true, false);
            Console.WriteLine(logical1.ToString());
            Console.WriteLine($"Дизъюнкция: {logical1.GetDisjunction()}");

            // Тестирование конструктора копирования
            Basic_Class logical2 = new Basic_Class(logical1);
            Console.WriteLine(logical2.ToString());

            // Тестирование дочернего класса
            Dother_Class extendedLogical1 = new Dother_Class(false, false, "ДочерныйКласс");
            Console.WriteLine(extendedLogical1.GetInfo());
            Console.WriteLine($"Равенство полей: {extendedLogical1.AreFieldsEqual()}");
            Console.WriteLine($"Дизъюнкция: {extendedLogical1.GetDisjunction2()}");


            // Тестирование конструктора копирования дочернего класса
            Dother_Class extendedLogical2 = new Dother_Class(extendedLogical1);
            Console.WriteLine(extendedLogical2.ToString());
        }
    }
}