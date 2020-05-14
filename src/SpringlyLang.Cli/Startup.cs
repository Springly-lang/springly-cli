using SpringlyLang.Common;
using SpringlyLang.Driver;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpringlyLang.Cli
{
    public class Startup
    {
        public const int SuccessCode = 0;
        public const string SpringlyFileExtensions = "*.spr;*.springly;";

        public Startup(ISourceFileReader fileReader, ITestScriptInterpreter interpreter, ITestScriptExecuter executer)
        {
            FileReader = fileReader;
            Interpreter = interpreter;
            Executer = executer;
        }

        public ISourceFileReader FileReader { get; }

        public ITestScriptInterpreter Interpreter { get; }

        public ITestScriptExecuter Executer { get; }

        public int Run(IEnumerable<string> files)
        {
            var scriptFiles = files.Any() ? files : GetScriptFiles();
            if (files.Any())
            {
                var sourceFiles = FileReader.Transform(files);
                var contexts = Interpreter.Interpret(sourceFiles);
                Executer.Execute(contexts);
            }
            else
            {
                Console.WriteLine("No test file(s) were provided.\r\nProcess now exists.");
            }

            return SuccessCode;
        }

        private IEnumerable<string> GetScriptFiles()
        {
            var currentDir = Directory.GetCurrentDirectory();
            var options = new EnumerationOptions { RecurseSubdirectories = true };
            return Directory.GetFiles(currentDir, SpringlyFileExtensions, options);
        }

    }
}
