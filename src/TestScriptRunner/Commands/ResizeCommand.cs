using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;

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
            // maximize browser
            if (e.Current.TokenType == TokenType.Maximize)
            {
                context.WebDriver.Manage().Window.Maximize();
            }
            // minimize browser
            else if (e.Current.TokenType == TokenType.Minimize)
            {
                context.WebDriver.Manage().Window.Minimize();
            }
            // resize [browser] [to] "widthXheight"
            else if (e.Current.TokenType == TokenType.Resize)
            {
                var sizeStrToken = Statement.Tokens.SingleOrDefault(x => x.TokenType == TokenType.StringLiteral);
                if (sizeStrToken == null)
                {
                    throw ThrowTokenExpected(TokenType.StringLiteral, context.SourceFile.FileName);
                }

                var sizeMatch = Regex.Match(sizeStrToken.Value, "(?<width>\\d+)X(?<height>\\d+)", RegexOptions.IgnoreCase);
                if (sizeMatch.Success)
                {
                    var width = int.Parse(sizeMatch.Groups["width"].Value);
                    var height = int.Parse(sizeMatch.Groups["height"].Value);
                    var resizeTo = new Size(width, height);
                    context.WebDriver.Manage().Window.Size = resizeTo;
                }
                else
                {
                    throw ThrowInvalidStringLiteral("Expected <width>X<height> format for size but invalid format detected.", context.SourceFile.FileName);
                }
            }

            return CommandExecutionResult.SuccessCommand;
        }

    }
}