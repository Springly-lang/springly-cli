using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace TestScriptRunner.Commands
{
    public class CommandExecutionContext
    {
        public TestCaseUseDefinition Definitions { get; set; }

        public TestCaseSourceFile SourceFile { get; set; }

        public string TestCaseTitle { get; set; }
    }

    public class TestCaseUseDefinition
    {
        public List<TestCaseDefinition> Definitions { get; } = new List<TestCaseDefinition>();
    }

    public class TestCaseDefinition
    {
        public string CssSelector { get; set; }

        public string XPath { get; set; }

        public string Key { get; set; }

        public DefinitionType Type { get; set; }
    }

    public enum DefinitionType
    {
        XPath,
        CssSelector
    }

    public class TestCaseUseDefinitionFactory
    {
        public static TestCaseUseDefinition Create(string definitionContent)
        {
            var toReturn = new TestCaseUseDefinition();

            var jsonContent = JObject.Parse(definitionContent);
            foreach (var definitionJson in jsonContent)
            {
                var useDefinition = new TestCaseDefinition { Key = definitionJson.Key };
                useDefinition.CssSelector = definitionJson.Value?.Value<string>("css-selector");
                useDefinition.XPath = definitionJson.Value?.Value<string>("xpath");
                useDefinition.Type = string.IsNullOrWhiteSpace(useDefinition.CssSelector) ? DefinitionType.XPath : DefinitionType.CssSelector;

                toReturn.Definitions.Add(useDefinition);
            }

            return toReturn;
        }
    }
}