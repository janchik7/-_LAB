using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using OfficeOpenXml;

namespace HermitageDatabase
{
    public class Artist
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public Artist(int id, string fullName)
        {
            Id = id;
            FullName = fullName;
        }

        public override string ToString()
        {
            return $"{Id}: {FullName}";
        }
    }

    public class Style
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Style(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return $"{Id}: {Name}";
        }
    }

    public class Painting
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ArtistId { get; set; }
        public string HermitagePart { get; set; }
        public int Year { get; set; }
        public int StyleId { get; set; }

        public Painting(int id, string title, int artistId, string hermitagePart, int year, int styleId)
        {
            Id = id;
            Title = title;
            ArtistId = artistId;
            HermitagePart = hermitagePart;
            Year = year;
            StyleId = styleId;
        }

        public override string ToString()
        {
            return $"{Id}: {Title}, Artist ID: {ArtistId}, Year: {Year}, Part: {HermitagePart}, Style ID: {StyleId}";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var dbManager = new DatabaseManager();
            dbManager.LoadData("LR5-var11.xlsx");

            while (true)
            {
                Console.WriteLine("Выберите действие:");
                Console.WriteLine("1. Просмотр художников");
                Console.WriteLine("2. Удаление художника");
                Console.WriteLine("3. Корректировка художника");
                Console.WriteLine("4. Добавление художника");
                Console.WriteLine("5. Просмотр стилей");
                Console.WriteLine("6. Удаление стиля");
                Console.WriteLine("7. Корректировка стиля");
                Console.WriteLine("8. Добавление стиля");
                Console.WriteLine("9. Просмотр картин");
                Console.WriteLine("10. Удаление картины");
                Console.WriteLine("11. Корректировка картины");
                Console.WriteLine("12. Добавление картины");
                Console.WriteLine("13. Количество художников с более чем 5 картинами во второй части Эрмитажа");
                Console.WriteLine("0. Выход");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        dbManager.DisplayArtists();
                        break;
                    case "2":
                        Console.Write("Введите ID художника для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int removeArtistId))
                        {
                            dbManager.RemoveArtist(removeArtistId);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ID.");
                        }
                        break;
                    case "3":
                        Console.Write("Введите ID художника для корректировки: ");
                        if (int.TryParse(Console.ReadLine(), out int updateArtistId))
                        {
                            Console.Write("Введите новое имя художника: ");
                            var newArtistName = Console.ReadLine();
                            dbManager.UpdateArtist(updateArtistId, newArtistName);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ID.");
                        }
                        break;
                    case "4":
                        Console.Write("Введите ID нового художника: ");
                        if (int.TryParse(Console.ReadLine(), out int addArtistId))
                        {
                            Console.Write("Введите имя и фамилию нового художника: ");
                            var newArtistFullName = Console.ReadLine();
                            dbManager.AddArtist(addArtistId, newArtistFullName);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ID.");
                        }
                        break;
                    case "5":
                        dbManager.DisplayStyles();
                        break;
                    case "6":
                        Console.Write("Введите ID стиля для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int removeStyleId))
                        {
                            dbManager.RemoveStyle(removeStyleId);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ID.");
                        }
                        break;
                    case "7":
                        Console.Write("Введите ID стиля для корректировки: ");
                        if (int.TryParse(Console.ReadLine(), out int updateStyleId))
                        {
                            Console.Write("Введите новое имя стиля: ");
                            var newStyleName = Console.ReadLine();
                            dbManager.UpdateStyle(updateStyleId, newStyleName);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ID.");
                        }
                        break;
                    case "8":
                        Console.Write("Введите ID нового стиля: ");
                        if (int.TryParse(Console.ReadLine(), out int addStyleId))
                        {
                            Console.Write("Введите имя нового стиля: ");
                            var newStyleName = Console.ReadLine();
                            dbManager.AddStyle(addStyleId, newStyleName);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ID.");
                        }
                        break;
                    case "9":
                        dbManager.DisplayPaintings();
                        break;
                    case "10":
                        Console.Write("Введите ID картины для удаления: ");
                        if (int.TryParse(Console.ReadLine(), out int removePaintingId))
                        {
                            dbManager.RemovePainting(removePaintingId);
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ID.");
                        }
                        break;
                    case "11":
                        Console.Write("Введите ID картины для корректировки: ");
                        if (int.TryParse(Console.ReadLine(), out int updatePaintingId))
                        {
                            Console.Write("Введите новое название картины: ");
                            var newPaintingTitle = Console.ReadLine();
                            Console.Write("Введите новый ID художника: ");
                            if (int.TryParse(Console.ReadLine(), out int newArtistId))
                                Console.Write("Введите новую часть Эрмитажа: ");
                            var newHermitagePart = Console.ReadLine();
                            Console.Write("Введите новый год: ");
                            if (int.TryParse(Console.ReadLine(), out int newYear))
                                Console.Write("Введите новый ID стиля: ");
                            if (int.TryParse(Console.ReadLine(), out int newStyleId))
                            {
                                dbManager.UpdatePainting(updatePaintingId, newPaintingTitle, newArtistId, newHermitagePart, newYear, newStyleId);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ID.");
                        }
                        break;
                    case "12":
                        Console.Write("Введите ID новой картины: ");
                        if (int.TryParse(Console.ReadLine(), out int addPaintingId))
                        {
                            Console.Write("Введите название картины: ");
                            var paintingTitle = Console.ReadLine();
                            Console.Write("Введите ID художника: ");
                            if (int.TryParse(Console.ReadLine(), out int paintingArtistId))
                                Console.Write("Введите часть Эрмитажа: ");
                            var paintingHermitagePart = Console.ReadLine();
                            Console.Write("Введите год: ");
                            if (int.TryParse(Console.ReadLine(), out int paintingYear)) 
                                Console.Write("Введите ID стиля: ");
                            if (int.TryParse(Console.ReadLine(), out int paintingStyleId))
                            {
                                dbManager.AddPainting(addPaintingId, paintingTitle, paintingArtistId, paintingHermitagePart, paintingYear, paintingStyleId);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Некорректный ID.");
                        }
                        break;
                    case "13":
                        int count = dbManager.CountArtistsWithMoreThanFivePaintingsInPart("2");
                        Console.WriteLine($"Количество художников с более чем 5 картинами во второй части Эрмитажа: {count}");
                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                        break;
                }
            }
        }
    }
}