namespace Gym_management_project.Modules
{
    public class ConsoleHelper
    {

        public static void Clear()
        {
            Console.Clear();
        }

        public static void WriteLine()
        {
            Console.WriteLine();
        }

        public static void Write(string text, ConsoleColor textColor)
        {
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.Write(text);
            Console.ForegroundColor = prevColor;
        }

        public static void WriteLine(string text)
        {
            Console.WriteLine(text);
        }

        public static void WriteLine(string text, ConsoleColor textColor)
        {
            var prevColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.WriteLine(text);
            Console.ForegroundColor = prevColor;
        }

        public static string Prompt(string text, string defaultValue = null)
        {
            ConsoleHelper.Write($"{text} > ", ConsoleColor.DarkCyan);
            var line = Console.ReadLine();
            ConsoleHelper.WriteLine();
            if (string.IsNullOrEmpty(line))
            {
                line = defaultValue;
            }
            return line;
        }

        public static void WriteHeader(string text)
        {
            ConsoleHelper.WriteLine();
            ConsoleHelper.WriteLine(text, ConsoleColor.DarkMagenta);
            ConsoleHelper.WriteLine();
        }

        public static void WriteInfo(string text)
        {
            ConsoleHelper.WriteLine();
            ConsoleHelper.WriteLine(text, ConsoleColor.DarkGray);
            ConsoleHelper.WriteLine();
        }

    }

}
