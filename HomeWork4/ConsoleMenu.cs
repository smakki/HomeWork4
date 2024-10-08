namespace HomeWork4
{
    internal class ConsoleMenu
    {
        static Dictionary<string, string> operands = new Dictionary<string, string>();
        static string[] menuOptions = { "a", "b", "c", "Exit" };

        static void ClearScreen()
        {
            Console.Clear();
        }

        static void ShowMainMenu(int selectedIndex)
        {
            ClearScreen();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{0} * x^2 + {1} * x + {2} = 0",
                operands.GetValueOrDefault("a") ?? "a", operands.GetValueOrDefault("b") ?? "b", operands.GetValueOrDefault("c") ?? "c");
            Console.ResetColor();

            // Loop through menu options
            for (int i = 0; i < menuOptions.Length; i++)
            {
                if (i == selectedIndex)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"> {menuOptions[i]}");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine($"  {menuOptions[i]}");
                }
            }

            Console.WriteLine("=====================");
        }

        public static Dictionary<string, string> ReadData()
        {
            int selectedIndex = 0;
            bool running = true;

            while (running)
            {
                ShowMainMenu(selectedIndex);
                ConsoleKeyInfo keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedIndex--;
                        if (selectedIndex < 0) selectedIndex = menuOptions.Length - 1;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedIndex++;
                        if (selectedIndex >= menuOptions.Length) selectedIndex = 0;
                        break;

                    case ConsoleKey.Enter:
                        switch (selectedIndex)
                        {
                            case 3:
                                ClearScreen();
                                Console.WriteLine("Exiting... Thank you!");
                                Thread.Sleep(1000);
                                running = false;
                                Environment.Exit(0);
                                break;
                            default:
                                return operands;
                        }
                        break;

                    case ConsoleKey.Backspace:
                        try
                        {
                            var before = operands[menuOptions[selectedIndex]];
                            var after = before.Remove(before.Length - 1, 1);
                            operands[menuOptions[selectedIndex]] = after.Length == 0 ? null : after;
                        }
                        catch
                        {
                            operands[menuOptions[selectedIndex]] = null;
                        }
                        break;
                    
                    case ConsoleKey.Subtract or ConsoleKey.OemMinus:
                        try
                        {
                            var before = operands[menuOptions[selectedIndex]];
                            if (String.IsNullOrEmpty(before))
                            {
                                operands[menuOptions[selectedIndex]] = "-";
                            }
                            else
                            {
                                if (before.StartsWith("-"))
                                {
                                    operands[menuOptions[selectedIndex]] = before.Substring(1);
                                }
                                else
                                {
                                    operands[menuOptions[selectedIndex]] = "-" + before;
                                }
                            }
                        }
                        catch
                        {
                            operands[menuOptions[selectedIndex]] = "-";
                        }
                        break;
                   
                    default:
                        if (Char.IsDigit(keyInfo.KeyChar))
                        {
                            try
                            {
                                operands[menuOptions[selectedIndex]] += keyInfo.KeyChar;
                            }
                            catch
                            {
                                operands.Add(menuOptions[selectedIndex], keyInfo.KeyChar.ToString());
                            }
                        }
                        break;
                }
            }
            return operands;

        }

    }

}
