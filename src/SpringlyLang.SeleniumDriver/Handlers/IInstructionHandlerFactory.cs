using SpringlyLang.Common.Instructions;

namespace SpringlyLang.SeleniumDriver
{
    public interface IInstructionHandlerFactory
    {
        IInstructionHandler Create(InstructionBase instruction);
    }
}
