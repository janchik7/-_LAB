using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace main
{
    public class Dother_Class : Basic_Class
    {
        private string description;

        // Конструктор
        public Dother_Class(bool f1, bool f2, string desc) : base(f1, f2)
        {
            description = desc;
        }

        // Конструктор копирования
        public Dother_Class(Dother_Class other) : base(other)
        {
            description = other.description;
        }

        public string GetInfo()
        {
            return $"{description}: {ToString()}";
        }


        // Метод для проверки, равны ли поля
        public bool AreFieldsEqual()
        {
            return field1 == field2;
        }

        // Метод для вычисления дизъюнкции
        public bool GetDisjunction2()
        {
            return field1 || field2;
        }

    }
}
