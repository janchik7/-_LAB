using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace main
{

    public class Basic_Class
    {
        protected bool field1;
        protected bool field2;

        // Конструктор
        public Basic_Class(bool f1, bool f2)
        {
            field1 = f1;
            field2 = f2;
        }

        // Конструктор копирования
        public Basic_Class(Basic_Class other)
        {
            field1 = other.field1;
            field2 = other.field2;
        }

        // Метод для вычисления дизъюнкции
        public bool GetDisjunction()
        {
            return field1 || field2;
        }

        // Перегрузка метода ToString()
        public override string ToString()
        {
            return $"Field1: {field1}, Field2: {field2}";
        }
    }
}
