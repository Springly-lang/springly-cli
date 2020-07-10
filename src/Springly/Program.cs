using Springly.Commands;
using System;
using System.IO;

namespace Springly
{
    public static class Program
    {
        public static void Main(string[] args)
        {
            var commands = CommandExtensions.GetCommands();

            foreach (var file in args)
            {
                if (File.Exists(file))
                {
                    RunScriptFile(commands, file);
                }
            }
        }

        private static void RunScriptFile(System.Collections.Generic.IEnumerable<ICommand> commands, string file)
        {
            using var context = new ExecutionContext();
            try
            {
                var lines = File.ReadAllLines(file);
                var lineNumber = 0;
                foreach (var line in lines)
                {
                    var trimmedLine = line.Trim();

                    lineNumber++;

                    if (string.IsNullOrWhiteSpace(trimmedLine))
                    {
                        // Ignore empty lines.
                        continue;
                    }

                    ExecutionResult result = null;
                    foreach (var command in commands)
                    {
                        result = command.Execute(trimmedLine, context);
                        if (result.ShouldContinue) continue;
                        if (!result.IsSuccess) throw new Exception(result.ErrorMessage);
                        break;
                    }

                    if (result.ShouldContinue)
                    {
                        // No command matched the input!
                        throw new SyntaxErrorException($"Invalid line at '{file}':L{lineNumber}.");
                    }
                }
            }
            catch (Exception ex)
            {
                Error($"Error: {ex}");
                throw;
            }
        }

        static void Error(string message)
        {
            var color = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ForegroundColor = color;
        }
    }
}
