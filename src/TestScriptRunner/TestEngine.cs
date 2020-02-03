namespace TestScriptRunner
{
    public class TestEngine
    {
        public static ExecutionResult Execute(TestCaseSourceFile[] files)
        {
            foreach (var scriptFile in files)
            {
                var tokens = Lexer.Tokenize(scriptFile);

                var statements = LLParser.Parse(scriptFile, tokens);

                Evaluator.Eval(statements);
            }

            return new ExecutionResult();
        }
    }

    public class ExecutionResult
    {

    }
}
