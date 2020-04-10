using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using TestScript.Common;
using TestScriptRunner.Cli;
using TestScriptRunner.Driver;
using Xunit;

namespace TestScriptRunnerUnitTests
{
    public class ProgramUnitTests
    {
        [Fact]
        public void Run_ForGivenFiles_ActAsExpected()
        {
            // Arrange
            const string FakeFileName = "file1.test";

            var files = new string[] { FakeFileName };
            var mockedFileReader = new Mock<ISourceFileReader>();
            var mockedInterpreter = new Mock<ITestScriptInterpreter>();
            var mockedExecuter = new Mock<ITestScriptExecuter>();

            var program = new Program(mockedFileReader.Object, mockedInterpreter.Object, mockedExecuter.Object);

            // Act
            program.Run(files);

            // Assert
            mockedFileReader.Verify(x => x.Transform(files), Times.Once());
            mockedInterpreter.Verify(x => x.Interpret(It.IsAny<IEnumerable<SourceFile>>()), Times.Once());
            mockedExecuter.Verify(x => x.Execute(It.IsAny<IEnumerable<TestScriptContext>>()), Times.Once());
        }
    }
}
