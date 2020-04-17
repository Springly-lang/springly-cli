using System;
using System.Runtime.CompilerServices;

namespace SpringlyLang
{
    public interface ILogger
    {
        void Error(string message);

        void Error(string message, Exception ex);

        void Info(string message);

        void Warning(string message);
    }

    public class ConsoleLogger : ILogger
    {
        public void Error(string message)
        {
            Print(message, ConsoleColor.Red);
        }

        public void Error(string message, Exception ex)
        {
            Print(message, ConsoleColor.Red);
            Print(ex.ToString(), ConsoleColor.Red);
        }

        public void Info(string message)
        {
            Print(message, ConsoleColor.White);
        }

        public void Warning(string message)
        {
            Print(message, ConsoleColor.Yellow);
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void Print(string text, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = previousColor;
        }
    }
}
