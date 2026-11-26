using System.Globalization;

class Program
{
    // Добавляем студенту все оценки из массива
    static void AddScores(Student s, int[] scores)
    {
        foreach (int score in scores)
        {
            s.AddScore(score);
        }
    }

    // Формируем строку с информацией о студенте
    static string FormatLine(int number, Student s)
    {
        if (s.Count == 0)
        {
            return $"{number}. {s.Name}: нет оценок";
        }

        return $"{number}. {s.Name}: {Math.Round(s.Average, 1)}";
    }

    // Выводим весь список студентов группы
    static void PrintList(Student[] group)
    {
        for (int i = 0; i < group.Length; i++)
        {
            Console.WriteLine(FormatLine(i + 1, group[i]));
        }
    }

    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        CultureInfo.CurrentCulture = new CultureInfo("ru-RU");

        string groupName = "Ис-25-26б";

        Student[] group =
        {
            new Student("Сериков Дамир", groupName),
            new Student("Ахметова Айгерим", groupName),
            new Student("Ким Анна", groupName),
            new Student("Петровых Александр", groupName),
            new Student("Бекова Мадина", groupName),
            new Student("Ли Виктор", groupName),
            new Student("Жумабаев Нурлан", groupName),
            new Student("Денисова Ольга", groupName),
        };

        AddScores(group[0], new[] { 72, 65, 80 });
        AddScores(group[1], new[] { 95, 88, 92 });
        AddScores(group[2], new[] { 100, 90 });
        AddScores(group[3], new[] { 60, 55, 70, 59 });
        AddScores(group[4], new[] { 85, 90, 78 });
        AddScores(group[5], new int[0]);
        AddScores(group[6], new[] { 88, 92 });
        AddScores(group[7], new[] { 85, 85 });

        Check("Сериков Дамир: Count", group[0].Count, 3);
        Check("Сериков Дамир: Average", group[0].Average, 72.33);
        Check("Ким Анна: Average", group[2].Average, 95);

        var test = new Student("Тестов Тест", groupName);

        AddScores(test, new[] { 50, 150, 70, -10, 90 });

        Check("Тестов Тест: Count (150 и -10 не принимаются)", test.Count, 3);
        Check("Тестов Тест: Average", test.Average, 70);

        var many = new Student("Много Оценок", groupName);

        AddScores(many, new[]
        {
            100, 100, 100, 100, 100, 100,
            100, 100, 100, 100, 100, 100
        });

        Check("Много Оценок: Count (не больше 10)", many.Count, 10);

        Check("FormatLine(1, Сериков Дамир)",
            FormatLine(1, group[0]), "1. Сериков Дамир: 72,3");

        Check("FormatLine(2, Ахметова Айгерим)",
            FormatLine(2, group[1]), "2. Ахметова Айгерим: 91,7");

        Check("FormatLine(3, Ким Анна)",
            FormatLine(3, group[2]), "3. Ким Анна: 95");

        Check("FormatLine(6, Ли Виктор)",
            FormatLine(6, group[5]), "6. Ли Виктор: нет оценок");

        Console.WriteLine();
        Console.WriteLine($"Список группы {groupName}:");

        PrintList(group);
    }

    // Проверка целых чисел
    static void Check(string what, int result, int expected)
    {
        string status = result == expected ? "OK" : "ОШИБКА";

        Console.WriteLine($"{what}: получено {result}, ожидалось {expected} - {status}");
    }

    // Проверка дробных чисел
    static void Check(string what, double result, double expected)
    {
        string status = Math.Abs(result - expected) < 0.005 ? "OK" : "ОШИБКА";

        Console.WriteLine($"{what}: получено {Math.Round(result, 2)}, ожидалось {expected} - {status}");
    }

    // Проверка строк
    static void Check(string what, string result, string expected)
    {
        string status = result == expected ? "OK" : "ОШИБКА";

        Console.WriteLine($"{what}: получено {result}, ожидалось {expected} - {status}");
    }
}