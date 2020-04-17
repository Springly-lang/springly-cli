using Newtonsoft.Json.Linq;

namespace SpringlyLang.UseDefinitions
{
    public class TestCaseUseDefinitionFactory : ITestCaseUseDefinitionFactory
    {
        public TestCaseUseDefinition Create(string definitionContent)
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