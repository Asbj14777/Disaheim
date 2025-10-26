using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using DisaheimMenu; 
namespace Disaheim
{
    class Program
    {
  
        static void Main(string[] args)
        {
            Menu mainMenu = new Menu("Main Menu");
            Menu settingsMenu = new Menu("Settings");

            mainMenu.AddOption("Start", () => Menu.ShowMessage("Starting..."));
            mainMenu.AddOption("Settings", submenu: settingsMenu);
            mainMenu.AddOption("About", () => Menu.ShowMessage("Console Menu System"));
            mainMenu.AddOption("Exit", () => Environment.Exit(0));

            settingsMenu.AddOption("Display", () => Menu.ShowMessage("Display settings here"));
            settingsMenu.AddOption("Network", () => Menu.ShowMessage("Network settings here"));
            settingsMenu.AddOption("Audio", () => Menu.ShowMessage("Audio settings here")); 
            for (int i = 1; i <= 10; i++)
                mainMenu.AddOption($"Extra Option {i}", () => 
                Menu.ShowMessage($"Selected Extra Option {i}")
             );

        

            mainMenu.ShowMenu();
        }
    }
}
