namespace SpringlyLang.Commands
{
    public class NavigationCommand : CommandBase
    {
        public NavigationCommand(Statement statement) : base(statement)
        {
        }

        public override CommandExecutionResult Execute(CommandExecutionContext context)
        {
            // navigate to "https://www.google.com"
            
            var enumerator = Statement.Tokens.GetEnumerator();
            if (!enumerator.MoveNext() || enumerator.Current.TokenType != TokenType.Navigate)
            {
                throw ThrowTokenExpected(TokenType.Navigate, context.SourceFile.FileName);
            }

            if (!enumerator.MoveNext())
            {
                throw ThrowTokenExpected(TokenType.StringLiteral, context.SourceFile.FileName);
            }

            if (enumerator.Current.TokenType == TokenType.To && !enumerator.MoveNext())
            {
                throw ThrowTokenExpected(TokenType.StringLiteral, context.SourceFile.FileName);
            }

            context.WebDriver.Url = enumerator.Current.Value;

            return CommandExecutionResult.SuccessCommand;
        }
    }
}