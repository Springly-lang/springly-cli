using System.Collections.Generic;

namespace SpringlyLang.Common
{
    public interface ITestScriptInterpreter
    {
        IEnumerable<TestScriptContext> Interpret(IEnumerable<SourceFile> files);
    }
}
