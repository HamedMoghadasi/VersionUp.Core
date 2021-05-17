using System;

public static class ConsoleHelper
{
    public static void WriteLine(string message, ConsoleColor color = ConsoleColor.White)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void ShowUsageHelp()
    {
        ConsoleHelper.WriteLine("======================================================================", ConsoleColor.DarkRed);
        ConsoleHelper.WriteLine("=============================== HELP =================================", ConsoleColor.DarkRed);
        ConsoleHelper.WriteLine("======================================================================", ConsoleColor.DarkRed);
        ConsoleHelper.WriteLine("Invalid use. Correct call format is:", ConsoleColor.Red);
        ConsoleHelper.WriteLine("    --> VersionUp.exe \"$(ProjectPath)\"");
        ConsoleHelper.WriteLine("$(ProjectPath) is visual studio macros.", ConsoleColor.Red);
        ConsoleHelper.WriteLine("======================================================================", ConsoleColor.DarkRed);
        ConsoleHelper.WriteLine("======================================================================", ConsoleColor.DarkRed);
        ConsoleHelper.WriteLine("======================================================================", ConsoleColor.DarkRed);
    }
}
