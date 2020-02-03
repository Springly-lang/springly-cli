namespace TestScriptRunner.Commands
{
    public class OpenCommand : CommandBase
    {
        public OpenCommand(Statement statement) : base(statement)
        {
        }

        public override CommandExecutionResult Execute(CommandExecutionContext context)
        {
            var e = Statement.Tokens.GetEnumerator();

            // Open
            e.MoveNext();


            if (e.MoveNext() && e.Current.TokenType == TokenType.Browser)
            {
                context.SetChromeDriver();
                if (e.MoveNext() && e.Current.TokenType != TokenType.NewLine)
                {
                    throw ThrowTokenExpected(TokenType.NewLine, e.Current.TokenType, context.SourceFile.FileName);
                }
            }
            else if (e.Current.TokenType == TokenType.StringLiteral)
            {
                var value = e.Current.Value;
                if (e.MoveNext() && e.Current.TokenType == TokenType.Browser)
                {
                    switch (value.ToLower())
                    {
                        case "firefox":
                            context.SetFirefoxDriver();
                            break;

                        case "edge":
                            context.SetEdgeDriver();
                            break;

                        case "chrome":
                        default:
                            context.SetChromeDriver();
                            break;
                    }
                }
                else
                {
                    throw ThrowTokenExpected(TokenType.Browser, e.Current.TokenType, context.SourceFile.FileName);
                }
            }

            return CommandExecutionResult.SuccessCommand;
        }
    }
}