using System.Linq;
using TestScriptRunner.UseDefinitions;

namespace TestScriptRunner.Commands
{
    public class CommandFactory : ICommandFactory
    {
        public CommandFactory(ITestCaseUseDefinitionFactory testCaseUseDefinitionFactory)
        {
            TestCaseUseDefinitionFactory = testCaseUseDefinitionFactory;
        }

        public ITestCaseUseDefinitionFactory TestCaseUseDefinitionFactory { get; }

        public CommandBase Create(Statement statement)
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

                case TokenType.Use:
                    return new UseCommand(statement, TestCaseUseDefinitionFactory);

                case TokenType.TestCase:
                    return new TestCaseDefinitionCommand(statement);

                case TokenType.WhiteSpace:
                case TokenType.NewLine:
                    return CommandBase.NoOp;

                default:
                    throw new SyntaxErrorException(leadingToken.Column, leadingToken.Line, "", "");
            }
        }
    }
}