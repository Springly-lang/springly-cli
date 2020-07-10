using System.IO;
using Xunit;

namespace SpringlyLangCliIntegrationTests
{
    public class OpenNavigateCloseBrowserTests : TestCaseBase
    {
        [Fact]
        public void ForGivenScriptFile_IncludingOpenNavigateCloseCommands_ActsAsExpected()
        {
            // Arrange
            var program = CreateInstance();
            var args = SetupFiles("OpenCloseBrowserTests", "open-close-navigate-test-scenario.springly");

            // Act
            var ex = Record.Exception(() => program.Run(args));

            // Assert
            Assert.Null(ex);
        }
    }
}
