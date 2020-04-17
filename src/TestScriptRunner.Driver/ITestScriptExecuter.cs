using System.Collections.Generic;
using SpringlyLang.Common;

namespace SpringlyLang.Driver
{
    public interface ITestScriptExecuter
    {
        void Execute(IEnumerable<TestScriptContext> contexts);
    }
}
