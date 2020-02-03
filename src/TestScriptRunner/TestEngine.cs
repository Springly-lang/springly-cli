using System.Collections.Generic;
using TestScriptRunner.Commands;

namespace TestScriptRunner
{
    public class TestEngine
    {
        public static ExecutionResult Execute(TestCaseSourceFile[] files)
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

            return new ExecutionResult();
        }
    }

    public class ExecutionResult
    {

    }
}
