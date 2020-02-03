using System.Collections.Generic;
using TestScriptRunner.Commands;

namespace TestScriptRunner
{
    public class TestEngine : ITestEngine
    {
        public TestEngine(ILexer lexer, IParser parser, IEvaluator evaluator, ICommandFactory commandFactory)
        {
            Lexer = lexer;
            Parser = parser;
            Evaluator = evaluator;
            CommandFactory = commandFactory;
        }

        public ILexer Lexer { get; }
        public IParser Parser { get; }
        public IEvaluator Evaluator { get; }
        public ICommandFactory CommandFactory { get; }

        public void Execute(TestCaseSourceFile[] files)
        {
            foreach (var scriptFile in files)
            {
                var tokens = Lexer.Tokenize(scriptFile);

                var statements = Parser.Parse(scriptFile, tokens);

                var commandList = new List<CommandBase>();
                foreach (var statement in statements)
                {
                    var command = CommandFactory.Create(statement);
                    if (command != CommandBase.NoOp)
                    {
                        commandList.Add(command);
                    }
                }

                Evaluator.Eval(scriptFile, commandList);
            }
        }
    }
}
