using System;
using System.Collections.Generic;
using TestScriptRunner.Commands;

namespace TestScriptRunner
{
    public class Evaluator
    {
        public static EvaluationResult Eval(TestCaseSourceFile sourceFile, IEnumerable<CommandBase> commands)
        {
            var context = new CommandExecutionContext();
            context.SourceFile = sourceFile;

            foreach (var command in commands)
                command.Execute(context);

            return new EvaluationResult();
        }
    }

    public class EvaluationResult
    {

    }
}