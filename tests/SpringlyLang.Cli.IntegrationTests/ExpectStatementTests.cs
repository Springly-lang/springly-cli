﻿using System;
using System.Collections.Generic;
using System.Text;
using SpringlyLangCliIntegrationTests;
using Xunit;

namespace SpringlyLang.Cli.IntegrationTests
{
    public class ExpectStatementTests : TestCaseBase
    {
        [Fact]
        public void Expects_ForGivenScriptFile_AssetsWithoutException()
        {
            // Arrange
            var scriptFileName = "expect-test-scenario.springly";
            var args = SetupFiles("ExpectStatementTests", scriptFileName);

            var program = CreateInstance();

            // Act
            var ex = Record.Exception(() => program.Run(args));

            // Assert
            Assert.Null(ex);
        }
    }
}
