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
                    var context = new ExecutionContext();
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
                            throw new Exception($"Invalid line at '{file}':L{lineNumber}.");
                        }
                    }
                }
            }
        }
    }
}
