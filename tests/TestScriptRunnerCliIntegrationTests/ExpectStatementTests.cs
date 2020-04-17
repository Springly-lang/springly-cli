using System;
using System.Collections.Generic;
using System.Text;
using TestScriptRunnerCliIntegrationTests;
using Xunit;

namespace TestScriptRunner.Cli.IntegrationTests
{
    public class ExpectStatementTests : TestCaseBase
    {
        [Fact]
        public void Expects_ForGivenScriptFile_AssetsWithoutException()
        {
            // Arrange
            var scriptFileName = "expect-test-scenario.springly";
            var args = SetupFiles("ExpectStatementTests", scriptFileName);

            var program = CreateProgramInstance();

            // Act
            var ex = Record.Exception(() => program.Run(args));

            // Assert
            Assert.Null(ex);
        }
    }
}
