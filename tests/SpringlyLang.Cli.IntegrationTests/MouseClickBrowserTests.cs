using System.IO;
using Xunit;

namespace SpringlyLangCliIntegrationTests
{
    public class MouseClickBrowserTests : TestCaseBase
    {
        [Theory]
        [InlineData("single-click-test-scenario.springly")]
        [InlineData("double-click-test-scenario.springly")]
        [InlineData("right-click-test-scenario.springly")]
        public void MouseClick_OnExistingButton_ActsAsExpected(string scriptFileName)
        {
            // Arrange
            var program = CreateProgramInstance();
            var args = SetupFiles("MouseClickBrowserTests", scriptFileName);

            // Act
            var ex = Record.Exception(() => program.Run(args));

            // Assert
            Assert.Null(ex);
        }
    }
}
