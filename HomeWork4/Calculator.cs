namespace HomeWork4;

public static class Calculator
{
    public static void Run()
    {
        var inputDict = ConsoleMenu.ReadData();
        Parse(inputDict);
    }

    public static void Parse(Dictionary<string, string> inputDict)
    {
        var dictionary = new Dictionary<string, int>();
        var results = new double[1];
        try
        {
            foreach (var item in inputDict)
            {
                dictionary.Add(item.Key, int.Parse(item.Value));
            }
            results = Calculate(dictionary);
            PrintResult(results);
        }
        catch (FormatException e)
        {
            FormatData(e.Message, Severity.Error, inputDict);
        }
        catch (NoSolutionException e)
        {
            FormatData(e.Message, Severity.Warning, inputDict);
        }

        catch (OverflowException e)
        {
            IntOverflow(e.Message, Severity.Warning, inputDict);
        }
    }

    private static double[] Calculate(Dictionary<string, int> inputDict)
    {
        var listx = new List<double>();
        var (a, b, c) = (inputDict.GetValueOrDefault("a"), inputDict.GetValueOrDefault("b"), inputDict.GetValueOrDefault("c"));
        var discriminant = Math.Pow(b, 2) - 4 * a * c;
        if (discriminant < 0)
        {
            throw new NoSolutionException("Вещественных значений не найдено");
        }
        if (discriminant == 0)
        {
            listx.Add((-b + Math.Sqrt(discriminant)) / 2 * a);
        }
        if (discriminant > 0)
        {
            listx.Add((-b + Math.Sqrt(discriminant)) / 2 * a);
            listx.Add((-b - Math.Sqrt(discriminant)) / 2 * a);
        }
        var results = listx.ToArray();
        return results;
    }

    public static double[] Calculate(int a, int b, int c)
    {
        var dict = new Dictionary<string, int>();
        dict.Add("a", a);
        dict.Add("b", b);
        dict.Add("c", c);
        return Calculate(dict);
    }


    private static void PrintResult(double[] results)
    {
        Console.WriteLine("Results:");
        if (results.Length == 1)
        {
            Console.WriteLine("x = {0}", results[0]);
        }

        if (results.Length == 2)
        {
            Console.WriteLine("x1 = {0}", results[0]);
            Console.WriteLine("x2 = {0}", results[1]);
        }
        PrintAnyKey();
    }


    private static void FormatData(string message, Severity severity, IDictionary<string, string> data)
    {
        if (severity == Severity.Error)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Yellow;
        }

        Console.WriteLine(new string('-', 50));
        Console.WriteLine(message);
        Console.WriteLine(new string('-', 50));
        foreach (var item in data)
        {
            Console.WriteLine("{0} = {1}", item.Key, item.Value);
        }
        Console.ResetColor();
        PrintAnyKey();
    }

    private static void IntOverflow(string message, Severity severity, IDictionary<string, string> data)
    {

        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;

        Console.WriteLine(new string('-', 50));
        Console.WriteLine(message);
        Console.WriteLine("Max value is {0}", int.MaxValue);
        Console.WriteLine(new string('-', 50));

        foreach (var item in data)
        {
            Console.WriteLine("{0} = {1}", item.Key, item.Value);
        }

        Console.ResetColor();
        PrintAnyKey();
    }

    private static void PrintAnyKey()
    {
        Console.WriteLine("Press any key to continue");
        Console.ReadKey();
    }

    private enum Severity
    {
        Warning,
        Error
    }
}