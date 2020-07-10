using Springly;
using Xunit;

namespace SpringlyLangCliIntegrationTests
{
    public class OpenNavigateCloseBrowserTests : TestCaseBase
    {
        [Fact]
        public void ForGivenScriptFile_IncludingOpenNavigateCloseCommands_ActsAsExpected()
        {
            // Arrange
            var args = SetupFiles("OpenCloseBrowserTests", "open-close-navigate-test-scenario.springly");

            // Act
            var ex = Record.Exception(() => Program.Main(args));

            // Assert
            Assert.Null(ex);
        }
    }
}
