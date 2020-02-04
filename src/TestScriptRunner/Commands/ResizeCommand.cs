using System.Drawing;
using System.Linq;

namespace TestScriptRunner.Commands
{
    public class ResizeCommand : CommandBase
    {
        public ResizeCommand(Statement statement) : base(statement)
        {
        }

        public override CommandExecutionResult Execute(CommandExecutionContext context)
        {
            var e = Statement.Tokens.GetEnumerator();
            e.MoveNext();

            if (e.Current.TokenType == TokenType.Maximize)
            {
                context.WebDriver.Manage().Window.Maximize();
            }
            else if (e.Current.TokenType == TokenType.Minimize)
            {
                context.WebDriver.Manage().Window.Minimize();
            }
            else if (e.Current.TokenType == TokenType.Resize)
            {
                var size = new Size();
                //if(e.MoveNext() && e.Current.TokenType != TokenType.Browser)

                context.WebDriver.Manage().Window.Maximize();
            }

            return CommandExecutionResult.SuccessCommand;
        }

    }
}