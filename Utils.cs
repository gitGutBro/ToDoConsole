namespace ToDoConsole;

public static class Utils
{
    public static void Print(string message)
    {
        Console.WriteLine(message);
        Console.ReadKey();
        Console.Clear();
    }

    public static string GetInput(string message)
    {
        Console.Write(message);
        return Console.ReadLine()?.Trim() ?? string.Empty;
    }
}