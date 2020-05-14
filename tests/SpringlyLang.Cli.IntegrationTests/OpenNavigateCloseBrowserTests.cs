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

            var baseDirectory = Path.Combine(Directory.GetCurrentDirectory(), "OpenCloseBrowserTests");
            var args = new[]
            {
                Path.Combine(baseDirectory, "open-close-navigate-test-scenario.springly")
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
