using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using SpringlyLang.Common;
using SpringlyLang.Common.UseDefinitions;
using SpringlyLang.Driver;
using SpringlyLang.Language;
using SpringlyLang.SeleniumDriver;

namespace SpringlyLang.Cli
{
    public class Program
    {
        public Program(ISourceFileReader fileReader, ITestScriptInterpreter interpreter, ITestScriptExecuter executer)
        {
            FileReader = fileReader;
            Interpreter = interpreter;
            Executer = executer;
        }

        public ISourceFileReader FileReader { get; }

        public ITestScriptInterpreter Interpreter { get; }

        public ITestScriptExecuter Executer { get; }

        public void Run(string[] files)
        {
            var sourceFiles = FileReader.Transform(files);
            var contexts = Interpreter.Interpret(sourceFiles);
            Executer.Execute(contexts);
        }

        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            Configure(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();


            var program = serviceProvider.GetService<Program>();
            program.Run(args);
        }

        private static void Configure(ServiceCollection services)
        {
            services.AddLogging(config => config.AddConsole());

            services.AddTransient<ISourceFileReader, SourceFileReader>();
            services.AddTransient<IUseDefinitionFactory, UseDefinitionFactory>();
            services.AddTransient<ITestScriptInterpreter, IronyTestScriptInterpreter>();
            services.AddTransient<ITestScriptExecuter, SeleniumTestScriptExecuter>();
            services.AddTransient<IInstructionHandlerFactory, InstructionHandlerFactory>();

            services.AddTransient<Program>();
        }
    }
}
