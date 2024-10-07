using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork4
{
    internal class ConsoleMenu
    {
        static string[] menuOptions = { "a", "b", "c", "Exit" };
        
        static void ClearScreen()
        {
            Console.Clear();
        }

        static void ShowMainMenu(int selectedIndex)
        {
            ClearScreen();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("===== Main Menu =====");
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
            Console.WriteLine("ax2 + bx + c = 0");
            var dictionary = new Dictionary<string, string>();

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
                                break;
                            
                        }
                        break;
                }
            }
            return dictionary;

        }

    }

}
