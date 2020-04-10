using System.IO;
using Xunit;

namespace TestScriptRunnerCliIntegrationTests
{
    public class MouseClickBrowserTests : TestCaseBase
    {
        [Theory]
        [InlineData("single-click-test-scenario.springly", "Single Click")]
        [InlineData("double-click-test-scenario.springly", "Double Click")]
        [InlineData("right-click-test-scenario.springly", "Right Click")]
        public void MouseClick_OnExistingButton_ActsAsExpected(string scriptFileName, string expectedValue)
        {
            // Arrange
            var program = CreateProgramInstance();

            var baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "MouseClickBrowserTests");
            var args = new[]
            {
                Path.Combine(baseDirectory, scriptFileName)
            };

            var indexFileName = Path.Combine(baseDirectory, "index.html");
            indexFileName = "file:///" + indexFileName.Replace(@"\", "/");
            foreach (var file in args)
            {
                var content = File.ReadAllText(file);
                content = content.Replace("$INDEX_FILE_PATH$", indexFileName);
                File.WriteAllText(file, content);
            }


            // Act
            var ex = Record.Exception(() => program.Run(args));

            // Assert
            Assert.Null(ex);
        }
    }
}
