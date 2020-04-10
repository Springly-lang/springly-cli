using System;
using TestScript.Common.Instructions;
using TestScriptRunner.SeleniumDriver.Handlers;

namespace TestScriptRunner.SeleniumDriver
{
    public class InstructionHandlerFactory : IInstructionHandlerFactory
    {
        public IInstructionHandler Create(InstructionBase instruction)
        {
            if (instruction is OpenBrowserInstruction openBrowserInstruction)
                return new OpenBrowserHandler(openBrowserInstruction);

            if (instruction is CloseBrowserInstruction closeBrowserInstruction)
                return new CloseBrowserHandler(closeBrowserInstruction);

            if (instruction is BrowserNavigateInstruction browserNavigateInstruction)
                return new NavigateBrowserHandler(browserNavigateInstruction);

            throw new NotSupportedException($"Instruction {instruction} is not supported by this driver.");
        }
    }
}
