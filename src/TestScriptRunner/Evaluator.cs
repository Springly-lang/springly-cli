using System.Collections.Generic;
using TestScriptRunner.Commands;

namespace TestScriptRunner
{
    public class Evaluator : IEvaluator
    {
        public Evaluator(ILogger logger)
        {
            Logger = logger;
        }

        public ILogger Logger { get; }

        public EvaluationResult Eval(TestCaseSourceFile sourceFile, IEnumerable<CommandBase> commands)
        {
            var context = new CommandExecutionContext(Logger);
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