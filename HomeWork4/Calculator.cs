namespace HomeWork4;

public static class Calculator
{
    public static void Run()
    {
        
        var inputDict = ReadData();
       Parse(inputDict);
    }

    public static void Parse(Dictionary<string, string> inputDict)
    {
        var dictionary = new Dictionary<string, int>();
        double[] results = [];
        try
        {
            foreach (var item in inputDict)
            {
                dictionary.Add(item.Key, int.Parse(item.Value));
            }
            results = Calculate(dictionary);
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
        
        PrintResult(results);   
    }
    
    private static double[] Calculate(Dictionary<string, int> inputDict)
    {
        var results = new double[2];
        var (a, b, c) = (inputDict["a"], inputDict["b"], inputDict["c"]);
        var discriminant = Math.Pow(b, 2) - 4 * a * c;
        if (discriminant < 0)
        {
            throw new NoSolutionException("Вещественных значений не найдено");
        }
        if (discriminant == 0)
        {
            results[0]= (-b + Math.Sqrt(discriminant)) / 2 * a;
        }
        if (discriminant > 0)
        {
            results[0]= (-b + Math.Sqrt(discriminant)) / 2 * a;
            results[1]= (-b - Math.Sqrt(discriminant)) / 2 * a;
        }

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
        if (results.Length == 1)
        {
            Console.WriteLine("x = {0}",results[0]);
        }

        if (results.Length == 2)
        {
            Console.WriteLine("x1 = {0}",results[0]);
            Console.WriteLine("x2 = {0}",results[1]);
        }
    }

    private static Dictionary<string, string> ReadData()
    {
        string[] operands = ["a","b","c"];
        var dictionary = new Dictionary<string, string>();
        foreach (var item in operands)
        {
            Console.WriteLine("Введите значение {0}",item);
            dictionary.Add(item,Console.ReadLine()??"");
        }
        return dictionary;
    }

    private static void FormatData(string message, Severity severity, IDictionary<string,string> data)
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

        Console.WriteLine(new string('-',50));
        Console.WriteLine(message);
        Console.WriteLine(new string('-',50));
        foreach (var item in data)
        {
            Console.WriteLine("{0} = {1}", item.Key, item.Value);
        }
        Console.ResetColor();
    }
    
    private static void IntOverflow(string message, Severity severity, IDictionary<string,string> data)
    {
        
        Console.BackgroundColor = ConsoleColor.Green;
        Console.ForegroundColor = ConsoleColor.Black;

        Console.WriteLine(new string('-',50));
        Console.WriteLine(message);
        Console.WriteLine("Max value is {0}", int.MaxValue);
        Console.WriteLine(new string('-',50));
       
        foreach (var item in data)
        {
            Console.WriteLine("{0} = {1}", item.Key, item.Value);
        }
        
        Console.ResetColor();
    }

    private enum Severity{
        Warning,
        Error
    }
}