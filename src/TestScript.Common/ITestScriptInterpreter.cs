using System.Collections.Generic;

namespace TestScript.Common
{
    public interface ITestScriptInterpreter
    {
        IEnumerable<TestScriptContext> Interpret(IEnumerable<SourceFile> files);
    }
}
