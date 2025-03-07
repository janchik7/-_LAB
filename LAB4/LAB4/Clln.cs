using System;
using System.Collections.Generic;


public class Clln<T> {

    public static List<T> intersect(List<T> L1, List<T> L2)
    {
        List<T> res = new List<T>();
        foreach (T val in L1)
            if (hasVal(L2, val) && !hasVal(res, val))
                res.Add(val);
        return res;
    }

    public static LinkedList<T> addReverse(LinkedList<T> LL)
    {
        LinkedList<T> res = new LinkedList<T>(LL);
        for (LinkedListNode<T> i = LL.Last; i != null; i = i.Previous)
            res.AddLast(i.Value);
        return res;
    }

    private static bool hasVal<T>(List<T> L, T v)
    {
        foreach (T val in L)
            if (v.Equals(val))
                return true;
        return false;
    }

    public static void checkAtten(HashSet<string> mall, HashSet<string>[] stud)
    {
        bool valid;

        foreach (string ml in mall)
        {
            valid = true;
            foreach (HashSet<string> hs in stud)
            {
                if (!hs.Contains(ml))
                {
                    valid = false;
                    break;
                }
            }
            if (valid)
                Console.WriteLine($"В ТРЦ {ml} ходили все.");
        }

        foreach (string ml in mall)
        {
            valid = false;
            foreach (HashSet<string> hs in stud)
            {
                if (hs.Contains(ml))
                {
                    valid = true;
                    break;
                }
            }
            if (valid)
                Console.WriteLine($"В ТРЦ {ml} ходил хотя-бы один студент.");
            if (!valid)
                Console.WriteLine($"В ТРЦ {ml} никто не ходил.");
        }
    }

    static public void checkSym(string e)
    {
        // Создаём файл в текущей директории
        string filePath = e;

        Console.WriteLine("Введите текст (для завершения нажмите Enter дважды):");

        // Создаём файл и открываем его для записи
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            string line;
            while ((line = Console.ReadLine()) != string.Empty)
            {
                writer.WriteLine(line);
            }
        }

        // Читаем текст из файла для подсчёта букв
        string text = File.ReadAllText(filePath);

        // Подсчёт уникальных букв
        HashSet<char> uniqueLetters = new HashSet<char>(
                text.Where(c => (c >= 'А' && c <= 'Я') || (c >= 'а' && c <= 'я') || c == 'Ё' || c == 'ё')
            );


        Console.WriteLine("\nРезультаты:");
        Console.WriteLine($"Количество уникальных букв: {uniqueLetters.Count}");
        Console.WriteLine("Уникальные буквы: " + string.Join(", ", uniqueLetters.OrderBy(c => c)));

    }

}

