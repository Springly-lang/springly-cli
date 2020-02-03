using System;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TestScriptRunner
{
    class Program
    {
        const int FileNotFoundErrorCode = 0x2;
        const int InvalidDataErrorCode = 0xC;

        static void Main(string[] args)
        {
            Info("Welcome to Springly test script runner v1.0");
            if (args?.Length == 0)
            {
                Error("No script file is specified.");
                Environment.Exit(InvalidDataErrorCode);
            }

            var missingFileNames = args.Where(tsf => !File.Exists(tsf)).ToArray();
            if (missingFileNames.Any())
            {
                foreach (var missing in missingFileNames)
                {
                    Error($"Test script file not found in path '{missing}'.");
                }

                Environment.Exit(FileNotFoundErrorCode);
            }

            var testCaseFiles = args.Select(arg => new TestCaseSourceFile(arg, File.ReadAllText(arg))).ToArray();

            try
            {
                Info("Test script execution started...");
                var result = TestEngine.Execute(testCaseFiles);

                Info(result.ToString());
            }
            catch (SyntaxErrorException se)
            {
                Error(se.Message);
            }
            catch (Exception ex)
            {
                Error(ex.Message);
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        static void Print(string text, ConsoleColor color)
        {
            var previousColor = Console.ForegroundColor;
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ForegroundColor = previousColor;
        }

        static void Error(string message)
        {
            Print(message, ConsoleColor.Red);
        }

        static void Info(string message)
        {
            Print(message, ConsoleColor.White);
        }
    }

    public class TestCaseSourceFile
    {
        public TestCaseSourceFile(string fileName, string content)
        {
            FileName = fileName;
            Content = content;
        }

        public string FileName { get; }

        public string Content { get; }
    }
}
