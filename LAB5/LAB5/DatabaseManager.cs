using HermitageDatabase;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DatabaseManager
{
    private List<Artist> artists = new List<Artist>();
    private List<Style> styles = new List<Style>();
    private List<Painting> paintings = new List<Painting>();

    // Загружает данные из Excel файла.
    public void LoadData(string filePath)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл '{filePath}' не найден.");
            Environment.Exit(1); // Завершение работы программы
        }
        try
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var artistSheet = package.Workbook.Worksheets["Artists"];
                var styleSheet = package.Workbook.Worksheets["Styles"];
                var paintingSheet = package.Workbook.Worksheets["Paintings"];

                if (artistSheet == null)
                {
                    Console.WriteLine("Лист 'Artists' не найден.");
                    return;
                }

                if (styleSheet == null)
                {
                    Console.WriteLine("Лист 'Styles' не найден.");
                    return;
                }

                if (paintingSheet == null)
                {
                    Console.WriteLine("Лист 'Paintings' не найден.");
                    return;
                }

                // Чтение данных о художниках
                for (int row = 2; row <= artistSheet.Dimension.End.Row; row++)
                {
                    var idText = artistSheet.Cells[row, 1].Text;
                    if (int.TryParse(idText, out int id))
                    {
                        var fullName = artistSheet.Cells[row, 2].Text;
                        artists.Add(new Artist(id, fullName));
                    }
                }

                // Чтение данных о стилях
                for (int row = 2; row <= styleSheet.Dimension.End.Row; row++)
                {
                    var idText = styleSheet.Cells[row, 1].Text;
                    if (int.TryParse(idText, out int id))
                    {
                        var name = styleSheet.Cells[row, 2].Text;
                        styles.Add(new Style(id, name));
                    }
                }

                // Чтение данных о картинах
                for (int row = 2; row <= paintingSheet.Dimension.End.Row; row++)
                {
                    var idText = paintingSheet.Cells[row, 1].Text;
                    if (int.TryParse(idText, out int id))
                    {
                        var title = paintingSheet.Cells[row, 2].Text;
                        var artistIdText = paintingSheet.Cells[row, 3].Text;
                        var hermitagePart = paintingSheet.Cells[row, 4].Text;
                        var yearText = paintingSheet.Cells[row, 5].Text;
                        var styleIdText = paintingSheet.Cells[row, 6].Text;

                        if (int.TryParse(artistIdText, out int artistId) &&
                            int.TryParse(yearText, out int year) &&
                            int.TryParse(styleIdText, out int styleId))
                        {
                            paintings.Add(new Painting(id, title, artistId, hermitagePart, year, styleId));
                        }

                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке данных: {ex.Message}");
        }
    }

    // Отображает список художников.
    public void DisplayArtists()
    {
        Console.WriteLine("Список художников:");
        foreach (var artist in artists)
        {
            Console.WriteLine(artist);
        }
    }

    // Отображает список стилей.
    public void DisplayStyles()
    {
        Console.WriteLine("Список стилей:");
        foreach (var style in styles)
        {
            Console.WriteLine(style);
        }
    }

    // Отображает список картин
    public void DisplayPaintings()
    {
        Console.WriteLine("Список картин:");
        foreach (var painting in paintings)
        {
            Console.WriteLine(painting);
        }
    }

    // Удаляет художника по указанному ID.
    public void RemoveArtist(int id)
    {
        var artist = artists.FirstOrDefault(a => a.Id == id);
        if (artist != null)
        {
            artists.Remove(artist);
            Console.WriteLine("Художник удален.");
        }
        else
        {
            Console.WriteLine("Художник не найден.");
        }
    }

    // Удаляет стиль по указанному ID.
    public void RemoveStyle(int id)
    {
        var style = styles.FirstOrDefault(s => s.Id == id);
        if (style != null)
        {
            styles.Remove(style);
            Console.WriteLine("Стиль удален.");
        }
        else
        {
            Console.WriteLine("Стиль не найден.");
        }
    }

    // Удаляет картину по указанному ID.
    public void RemovePainting(int id)
    {
        var painting = paintings.FirstOrDefault(p => p.Id == id);
        if (painting != null)
        {
            paintings.Remove(painting);
            Console.WriteLine("Картина удалена.");
        }
        else
        {
            Console.WriteLine("Картина не найдена.");
        }
    }

    // Обновляет данные художника по указанному ID.
    public void UpdateArtist(int id, string newName)
    {
        var artist = artists.FirstOrDefault(a => a.Id == id);
        if (artist != null)
        {
            artist.FullName = newName;
            Console.WriteLine("Художник обновлен.");
        }
        else
        {
            Console.WriteLine("Художник не найден.");
        }
    }

    // Обновляет данные стиля по указанному ID
    public void UpdateStyle(int id, string newName)
    {
        var style = styles.FirstOrDefault(s => s.Id == id);
        if (style != null)
        {
            style.Name = newName;
            Console.WriteLine("Стиль обновлен.");
        }
        else
        {
            Console.WriteLine("Стиль не найден.");
        }
    }

    // Обновляет данные картины по указанному ID.
    public void UpdatePainting(int id, string newTitle, int newArtistId, string newHermitagePart, int newYear, int newStyleId)
    {
        var painting = paintings.FirstOrDefault(p => p.Id == id);
        if (painting != null)
        {
            painting.Title = newTitle;
            painting.ArtistId = newArtistId;
            painting.HermitagePart = newHermitagePart;
            painting.Year = newYear;
            painting.StyleId = newStyleId;
            Console.WriteLine("Картина обновлена.");
        }
        else
        {
            Console.WriteLine("Картина не найдена.");
        }
    }

    // Добавляет нового художника.
    public void AddArtist(int id, string fullName)
    {
        artists.Add(new Artist(id, fullName));
        Console.WriteLine("Художник добавлен.");
    }

    // Добавляет новый стиль.
    public void AddStyle(int id, string name)
    {
        styles.Add(new Style(id, name));
        Console.WriteLine("Стиль добавлен.");
    }

    // Добавляет новую картину.
    public void AddPainting(int id, string title, int artistId, string hermitagePart, int year, int styleId)
    {
        paintings.Add(new Painting(id, title, artistId, hermitagePart, year, styleId));
        Console.WriteLine("Картина добавлена.");
    }

    // Подсчитывает количество художников с более чем 5 картинами во второй части Эрмитажа.
    public int CountArtistsWithMoreThanFivePaintingsInPart(string part)
    {
        return paintings
            .Where(p => p.HermitagePart == part)
            .GroupBy(p => p.ArtistId)
            .Count(g => g.Count() > 5);
    }
}
