namespace SpringlyLang.Commands
{
    public class TestCaseDefinitionCommand : CommandBase
    {
        public TestCaseDefinitionCommand(Statement statement) : base(statement)
        {
        }

        public override CommandExecutionResult Execute(CommandExecutionContext context)
        {
            var enumerator = Statement.Tokens.GetEnumerator();

            if (!enumerator.MoveNext() || enumerator.Current.TokenType != TokenType.TestCase)
            {
                throw new SyntaxErrorException("Test Case statement was expected but not found.", context.SourceFile.FileName);
            }

            if (!enumerator.MoveNext() || string.IsNullOrWhiteSpace(enumerator.Current.Value))
            {
                throw new SyntaxErrorException("Test Case title was expected but not found.", context.SourceFile.FileName);
            }

            context.TestCaseTitle = enumerator.Current.Value.Trim();

            return CommandExecutionResult.SuccessCommand;
        }
    }
}