using System.Collections.Generic;
using TestScriptRunner.Commands;

namespace TestScriptRunner
{
    public interface IEvaluator
    {
        EvaluationResult Eval(TestCaseSourceFile sourceFile, IEnumerable<CommandBase> commands);
    }
}