using System;
using System.Collections.Generic;
using System.Threading;

namespace DisaheimMenu
{
    public class Menu
    {
        public class MenuOption
        {
            public string Name { get; set; }
            public Action Action { get; set; }
            public Menu SubMenu { get; set; }

            public MenuOption(string name, Action action = null, Menu submenu = null)
            {
                Name = name;
                Action = action;
                SubMenu = submenu;
            }
        }

        public string Title { get; set; }
        public List<MenuOption> Options { get; private set; } = new List<MenuOption>();
        public Menu ParentMenu { get; set; }

        private const int VisibleHeight = 10;

        public Menu(string title)
        {
            Title = title;
        }

        public void AddOption(string name, Action action = null, Menu submenu = null)
        {
            if (submenu != null)
                submenu.ParentMenu = this;
            Options.Add(new MenuOption(name, action, submenu));
        }

        public void ShowMenu()
        {
            int selectedIndex = 0;
            int topIndex = 0;

            while (true)
            {
                DrawMenu(selectedIndex, topIndex);
                ConsoleKey key = ReadKey();

                if (key == ConsoleKey.UpArrow)
                {
                    selectedIndex = (selectedIndex - 1 + Options.Count) % Options.Count;
                    if (selectedIndex < topIndex)
                        topIndex = selectedIndex;
                    else if (selectedIndex == Options.Count - 1)
                        topIndex = Math.Max(0, Options.Count - VisibleHeight);
                }
                else if (key == ConsoleKey.DownArrow)
                {
                    selectedIndex = (selectedIndex + 1) % Options.Count;
                    if (selectedIndex >= topIndex + VisibleHeight)
                        topIndex = selectedIndex - VisibleHeight + 1;
                    else if (selectedIndex == 0)
                        topIndex = 0;
                }
                else if (key == ConsoleKey.Enter)
                {
                    var selected = Options[selectedIndex];
                    if (selected.SubMenu != null)
                        selected.SubMenu.ShowMenu();
                    else
                        selected.Action?.Invoke();
                }
                else if (key == ConsoleKey.Backspace || key == ConsoleKey.Escape)
                {
                    if (ParentMenu != null)
                        return;
                }
            }
        }

        private ConsoleKey ReadKey()
        {
            while (!Console.KeyAvailable)
                Thread.Sleep(15);
            return Console.ReadKey(true).Key;
        }

        private void DrawMenu(int selectedIndex, int topIndex)
        {
            Console.Clear();
            int consoleWidth = 60;
            int consoleHeight = 25;
            int startX = (Console.WindowWidth - consoleWidth) / 2;
            int startY = (Console.WindowHeight - (VisibleHeight + 12)) / 2;

            DrawBorder(startX, startY, consoleWidth);
            DrawTitle(startX, startY, consoleWidth);

            Console.SetCursorPosition(startX + 2, startY + 4);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(GetBreadcrumb());
            Console.ResetColor();
            Console.WriteLine();

            Console.SetCursorPosition(startX + 1, startY + 5);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('═', consoleWidth - 2));
            Console.ResetColor();

            int bottomIndex = Math.Min(topIndex + VisibleHeight, Options.Count);
            for (int i = topIndex; i < bottomIndex; i++)
            {
                bool selected = i == selectedIndex;
                Console.SetCursorPosition(startX + 2, startY + 6 + i - topIndex);

                if (selected)
                {
                    Console.BackgroundColor = ConsoleColor.DarkCyan;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(Options[i].Name.PadRight(consoleWidth - 4));
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(Options[i].Name.PadRight(consoleWidth - 4));
                    Console.ResetColor();
                }
            }

            Console.SetCursorPosition(startX + 1, startY + VisibleHeight + 6);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('═', consoleWidth - 2));
            Console.ResetColor();


            Console.SetCursorPosition(startX + 2, startY + VisibleHeight + 7);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine("Console Output: ".PadRight(consoleWidth - 4));
            Console.ResetColor();

            Console.SetCursorPosition(startX + 2, startY + VisibleHeight + 8);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"Currently Selected : [{selectedIndex + 1} / {Options.Count}]".PadRight(consoleWidth - 4));
            Console.ResetColor();

            Console.SetCursorPosition(startX + 2, startY + VisibleHeight + 9);
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Controls: UP/DOWN Arrow | Enter | ESC".PadRight(consoleWidth - 4));
            Console.ResetColor();

        }

        private void DrawBorder(int startX, int startY, int width)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.SetCursorPosition(startX, startY);
            Console.Write("╔" + new string('═', width - 2) + "╗");

            for (int i = 1; i <= VisibleHeight + 10; i++)
            {
                Console.SetCursorPosition(startX, startY + i);
                Console.Write("║" + new string(' ', width - 2) + "║");
            }

            Console.SetCursorPosition(startX, startY + VisibleHeight + 11);
            Console.Write("╚" + new string('═', width - 2) + "╝");
            Console.ResetColor();
        }

        private void DrawTitle(int startX, int startY, int width)
        {
            string title = "DISAHEIM";
            Console.Title = title;  
            int leftPadding = startX + (width - title.Length) / 2;
            Console.SetCursorPosition(leftPadding, startY + 1);
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(title);
            Console.ResetColor();
        }

        private string GetBreadcrumb()
        {
            List<string> names = new List<string>();
            Menu current = this;
            while (current != null)
            {
                names.Insert(0, current.Title);
                current = current.ParentMenu;
            }
            return string.Join(" > ", names);
        }

        public static void ShowMessage(string text)
        {
            int consoleWidth = 60;
            int consoleHeight = 25;
            int startX = (Console.WindowWidth - consoleWidth) / 2;
            int startY = (Console.WindowHeight - (VisibleHeight + 12)) / 2;
        
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.SetCursorPosition(startX + 18, startY + VisibleHeight + 7);
            foreach (char c in text)
            {
                Console.Write(c);
                Thread.Sleep(15);
            }
            Console.ResetColor();
            Thread.Sleep(300);
        }
    }
}
