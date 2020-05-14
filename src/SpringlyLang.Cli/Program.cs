using CommandLine;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using SpringlyLang.Common;
using SpringlyLang.Common.UseDefinitions;
using SpringlyLang.Driver;
using SpringlyLang.Language;
using SpringlyLang.SeleniumDriver;
using System;
using System.Reflection;

namespace SpringlyLang.Cli
{
    public static class Program
    {
        static int Main(string[] args)
        {
            Introduce();

            return Parser.Default.ParseArguments<RunOptions>(args)
                .MapResult(ProcessRunVerb, _ => 1);
        }

        static void Introduce()
        {
            Console.WriteLine($"Springly Lang (R) Test Engine Version {Assembly.GetExecutingAssembly().GetName().Version}");
            Console.WriteLine($"Copyright (C) {DateTime.Now.Year} All Rights Reserved.");
            Console.WriteLine();
        }

        private static int ProcessRunVerb(RunOptions opts)
        {
            var serviceCollection = new ServiceCollection();
            Configure(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();

            return serviceProvider.GetService<Startup>()
                .Run(opts.FileNames);
        }

        private static void Configure(ServiceCollection services)
        {
            services.AddLogging(config => config.AddConsole());

            services.AddTransient<ISourceFileReader, SourceFileReader>();
            services.AddTransient<IUseDefinitionFactory, UseDefinitionFactory>();
            services.AddTransient<ITestScriptInterpreter, IronyTestScriptInterpreter>();
            services.AddTransient<ITestScriptExecuter, SeleniumTestScriptExecuter>();
            services.AddTransient<IInstructionHandlerFactory, InstructionHandlerFactory>();

            services.AddTransient<Startup>();
        }
    }
}
