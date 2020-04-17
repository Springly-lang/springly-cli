using System;
using System.IO;
using SpringlyLang.UseDefinitions;

namespace SpringlyLang.Commands
{
    public class UseCommand : CommandBase
    {
        public UseCommand(Statement statement, ITestCaseUseDefinitionFactory testCaseUseDefinitionFactory) : base(statement)
        {
            TestCaseUseDefinitionFactory = testCaseUseDefinitionFactory;
        }

        public ITestCaseUseDefinitionFactory TestCaseUseDefinitionFactory { get; }

        public override CommandExecutionResult Execute(CommandExecutionContext context)
        {
            var enumerator = Statement.Tokens.GetEnumerator();
            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException("Use statement was expected.");
            }

            if (enumerator.Current.TokenType != TokenType.Use)
            {
                throw new InvalidOperationException($"'Use' statement was expected but found '{enumerator.Current.TokenType}'.");
            }

            if (!enumerator.MoveNext())
            {
                throw new InvalidOperationException("definition file name was expected.");
            }

            if (enumerator.Current.TokenType != TokenType.StringLiteral)
            {
                throw new InvalidOperationException($"definition file name was expected but found '{enumerator.Current.TokenType}'.");
            }

            var sourceFileInfo = new FileInfo(context.SourceFile.FileName);
            var definitionFilePath = Path.Combine(sourceFileInfo.DirectoryName, enumerator.Current.Value);
            string content;
            if (File.Exists(definitionFilePath))
            {
                content = File.ReadAllText(definitionFilePath);
            }
            else if (File.Exists(enumerator.Current.Value))
            {
                content = File.ReadAllText(enumerator.Current.Value);
            }
            else
            {
                throw new InvalidOperationException($"definition file was not found at '{enumerator.Current.Value}'.");
            }


            context.Definitions = TestCaseUseDefinitionFactory.Create(content);

            return CommandExecutionResult.SuccessCommand;
        }
    }
}