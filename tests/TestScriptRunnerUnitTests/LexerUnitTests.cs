using System;
using System.Linq;
using TestScriptRunner;
using Xunit;

namespace TestScriptRunnerUnitTests
{
    public class LexerUnitTests
    {
        const string SampleScriptFile = "C:\\sample.testcase";

        [Fact]
        public void Tokenize_ForEmptyScript_ReturnsZeroToken()
        {
            var emptyFile = new TestCaseSourceFile(SampleScriptFile, " \t \n ");
            var tokens = Lexer.Tokenize(emptyFile);
            Assert.Empty(tokens);
        }

        [Fact]
        public void Tokenize_ElementIdentifier_ReturnsExpectedTokens()
        {
            var sampleFile = new TestCaseSourceFile(SampleScriptFile, "@google-home-page");
            var tokens = Lexer.Tokenize(sampleFile);
            Assert.NotEmpty(tokens);
            Assert.Equal(TokenType.ElementIdentifier, tokens.ElementAt(0).TokenType);
            Assert.Equal("google-home-page", tokens.ElementAt(0).Value);
        }

        [Theory]
        [InlineData(TokenType.Comment, "", "\\\\ here is a normal comment that ends with new line.\n", 0)]
        [InlineData(TokenType.Colon, "", "\"item 1\", \"item 2\"\n", 1)]
        [InlineData(TokenType.StringLiteral, "\\\\this should be a string not a comment", "\"\\\\this should be a string not a comment\"\n", 0)]
        public void Tokenize_ForGivenTokenType_ReturnsExpectedTokens(TokenType expectedTokenType, string expectedValue, string script, int index)
        {
            // Arrange
            var sourceFile = new TestCaseSourceFile(SampleScriptFile, script);

            // Act
            var tokens = Lexer.Tokenize(sourceFile);

            // Assert
            var actualToken = tokens.ElementAt(index);
            Assert.Equal(expectedTokenType, actualToken.TokenType);
            Assert.Equal(expectedValue, actualToken.Value);
        }

        [Fact]
        public void Tokenize_ForUseCommand_ReturnsExpectedTokens()
        {
            // Arrange
            var scriptFile = new TestCaseSourceFile(SampleScriptFile, "use \"tour-platform.json\"");

            // Act
            var tokens = Lexer.Tokenize(scriptFile);

            // Assert
            Assert.Equal(2, tokens.Count());
            Assert.Equal(TokenType.Use, tokens.ElementAt(0).TokenType);
            Assert.Empty(tokens.ElementAt(0).Value);

            Assert.Equal(TokenType.StringLiteral, tokens.ElementAt(1).TokenType);
            Assert.Equal("tour-platform.json", tokens.ElementAt(1).Value);
        }

        [Fact]
        public void Tokenize_ForCheckWithColonCommand_ReturnsExpectedTokens()
        {
            // Arrange
            var scriptFile = new TestCaseSourceFile(SampleScriptFile, "check @luxary-tours, @last-second from @tour-types");

            // Act
            var tokens = Lexer.Tokenize(scriptFile);

            // Assert
            Assert.Equal(6, tokens.Count());

            Assert.Equal(TokenType.Check, tokens.ElementAt(0).TokenType);
            Assert.Empty(tokens.ElementAt(0).Value);

            Assert.Equal(TokenType.ElementIdentifier, tokens.ElementAt(1).TokenType);
            Assert.Equal("luxary-tours", tokens.ElementAt(1).Value);

            Assert.Equal(TokenType.Colon, tokens.ElementAt(2).TokenType);
            Assert.Empty(tokens.ElementAt(2).Value);

            Assert.Equal(TokenType.ElementIdentifier, tokens.ElementAt(3).TokenType);
            Assert.Equal("last-second", tokens.ElementAt(3).Value);

            Assert.Equal(TokenType.From, tokens.ElementAt(4).TokenType);
            Assert.Empty(tokens.ElementAt(4).Value);

            Assert.Equal(TokenType.ElementIdentifier, tokens.ElementAt(5).TokenType);
            Assert.Equal("tour-types", tokens.ElementAt(5).Value);
        }

        [Fact]
        public void Tokenize_ForValidScriptWithNewLineAtEnd_ReturnsExpectedTokens()
        {
            // Arrange
            var script = new TestCaseSourceFile(SampleScriptFile, "use \"tour-platform.json\"\r\n");

            // Act
            var tokens = Lexer.Tokenize(script);

            // Assert
            Assert.Equal(3, tokens.Count());
            Assert.Equal(TokenType.Use, tokens.ElementAt(0).TokenType);
            Assert.Empty(tokens.ElementAt(0).Value);

            Assert.Equal(TokenType.StringLiteral, tokens.ElementAt(1).TokenType);
            Assert.Equal("tour-platform.json", tokens.ElementAt(1).Value);

            Assert.Equal(TokenType.NewLine, tokens.ElementAt(2).TokenType);
            Assert.Empty(tokens.ElementAt(2).Value);
        }
    }
}
