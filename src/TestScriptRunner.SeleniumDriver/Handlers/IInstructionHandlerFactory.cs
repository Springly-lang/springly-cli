using TestScript.Common.Instructions;

namespace TestScriptRunner.SeleniumDriver
{
    public interface IInstructionHandlerFactory
    {
        IInstructionHandler Create(InstructionBase instruction);
    }
}
