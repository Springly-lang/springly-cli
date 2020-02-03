using System.Linq;

namespace TestScriptRunner
{
    public class CommandFactory
    {
        public static CommandBase Create(Statement statement)
        {
            var leadingToken = statement.Tokens.FirstOrDefault();
            switch (leadingToken.TokenType)
            {
                case TokenType.Open:
                    return new OpenCommand(statement);

                case TokenType.Click:
                    return new ClickCommand(statement);

                case TokenType.DoubleClick:
                    return new DoubleClickCommand(statement);

                case TokenType.Check:
                    return new CheckCommand(statement);

                case TokenType.Close:
                    return new CloseCommand(statement);

                case TokenType.Expect:
                    return new ExpectCommand(statement);

                case TokenType.Resize:
                case TokenType.Maximize:
                case TokenType.Minimize:
                    return new ResizeCommand(statement);

                case TokenType.Navigate:
                    return new NavigationCommand(statement);

                case TokenType.WaitFor:
                case TokenType.WaitUntil:
                    return new WaitCommand(statement);

                case TokenType.Type:
                    return new TypeCommand(statement);

                case TokenType.Select:
                    return new SelectCommand(statement);

                case TokenType.ScrollTo:
                    return new ScrollToCommand(statement);

                default:
                    throw new SyntaxErrorException(leadingToken.Column, leadingToken.Line, "", "");
            }
        }
    }

    public class ScrollToCommand : CommandBase
    {
        public ScrollToCommand(Statement statement) : base(statement)
        {
        }
    }

    public class SelectCommand : CommandBase
    {
        public SelectCommand(Statement statement) : base(statement)
        {
        }
    }

    public class TypeCommand : CommandBase
    {
        public TypeCommand(Statement statement) : base(statement)
        {
        }
    }

    public class WaitCommand : CommandBase
    {
        public WaitCommand(Statement statement) : base(statement)
        {
        }
    }

    public class NavigationCommand : CommandBase
    {
        public NavigationCommand(Statement statement) : base(statement)
        {
        }
    }

    public class ResizeCommand : CommandBase
    {
        public ResizeCommand(Statement statement) : base(statement)
        {
        }
    }

    public class ExpectCommand : CommandBase
    {
        public ExpectCommand(Statement statement) : base(statement)
        {
        }
    }
}