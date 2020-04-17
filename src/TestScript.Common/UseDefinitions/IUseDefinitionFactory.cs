namespace SpringlyLang.Common.UseDefinitions
{
    public interface IUseDefinitionFactory
    {
        TestCaseUseDefinition Create(string definitionContent);
     
        TestCaseUseDefinition FromFile(string fileName);
    }
}