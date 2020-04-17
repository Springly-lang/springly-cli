using System.Collections.Generic;
using SpringlyLang.Commands;

namespace SpringlyLang
{
    public interface IEvaluator
    {
        EvaluationResult Eval(TestCaseSourceFile sourceFile, IEnumerable<CommandBase> commands);
    }
}