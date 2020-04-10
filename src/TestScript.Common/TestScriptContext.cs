using System;
using System.Collections.Generic;
using System.Linq;
using TestScriptRunner.Common.UseDefinitions;

namespace TestScript.Common
{
    public class TestScriptContext
    {
        public List<TestCaseUseDefinition> Definitions { get; } = new List<TestCaseUseDefinition>();

        public List<TestCase> TestCases { get; } = new List<TestCase>();

        public TestCase LastTestCase => TestCases.Count > 0 ? TestCases[TestCases.Count - 1] : default;

        public string BaseDirectory { get; }

        public SourceFile SourceFile { get; }

        public TestScriptContext(string baseDirectory, SourceFile sourceFile)
        {
            BaseDirectory = baseDirectory;
            SourceFile = sourceFile;
        }

        public void AddTestDefinition(TestCaseUseDefinition testDefinition) => Definitions.Add(testDefinition);

        public void AddTestCase(TestCase testCase)
        {
            if (TestCases.Any(tc => string.Equals(tc.Name, testCase.Name, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException($"There is already another test case with the same name '{testCase.Name}'.");
            }

            TestCases.Add(testCase);
        }
    }
}
