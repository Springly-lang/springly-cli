using System;
using System.Collections.Generic;
using TestScriptRunner.Commands;

namespace TestScriptRunner
{
    public class Evaluator
    {
        public static EvaluationResult Eval(IEnumerable<CommandBase> commands)
        {
            return new EvaluationResult();
        }
    }

    public class EvaluationResult
    {

    }
}