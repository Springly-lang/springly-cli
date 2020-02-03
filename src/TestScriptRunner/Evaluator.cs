using System;
using System.Collections.Generic;

namespace TestScriptRunner
{
    public class Evaluator
    {
        public static IEnumerable<CommandBase> Eval(IEnumerable<Statement> statements)
        {
            var list = new List<CommandBase>();

            foreach (var statement in statements)
            {
                var command = CommandFactory.Create(statement);
                list.Add(command);
            }

            return list;
        }
    }
}