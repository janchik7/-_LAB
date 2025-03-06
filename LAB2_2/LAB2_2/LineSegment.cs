using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB2_2
{
    class LineSegment
    {
        // Свойства для начала и конца отрезка
        public double X { get; set; }
        public double Y { get; set; }

        // Конструктор класса, который принимает координаты отрезка
        public LineSegment(double x, double y)
        {
            // Проверка: начальная координата не может быть больше конечной
            if (x > y)
            {
                throw new ArgumentException("Начальная координата не может быть больше конечной");
            }
            X = x;
            Y = y;
        }

        // Метод для получения строкового представления отрезка
        public override string ToString()
        {
            return $"Отрезок: [{X}, {Y}]";
        }

        // Метод для проверки пересечения с другим отрезком
        public bool Intersects(LineSegment other)
        {
            return !(Y < other.X || other.Y < X);
        }

        // Унарная операция: вычисление длины отрезка
        public static double operator !(LineSegment segment)
        {
            return segment.Y - segment.X; // Длина отрезка
        }

        // Унарная операция: расширение отрезка на 1 вправо и влево
        public static LineSegment operator ++(LineSegment segment)
        {
            return new LineSegment(segment.X - 1, segment.Y + 1);
        }
        
        // Приведение типа: неявное преобразование в int
        public static implicit operator int(LineSegment segment)
        {
            return (int)segment.X;
        }

        // Приведение типа: явное преобразование в double
        public static explicit operator double(LineSegment segment)
        {
            return segment.Y;
        }

        
        
    }
}
