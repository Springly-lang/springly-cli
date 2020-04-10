using System.Collections.Generic;
using TestScript.Common;

namespace TestScriptRunner.Driver
{
    public interface ITestScriptExecuter
    {
        void Execute(IEnumerable<TestScriptContext> contexts);
    }
}
