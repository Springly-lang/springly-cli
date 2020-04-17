﻿using System;
using SpringlyLang.Common.Instructions;
using SpringlyLang.SeleniumDriver.Handlers;

namespace SpringlyLang.SeleniumDriver
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

            if (instruction is ClickBrowserInstruction clickBrowserInstruction)
                return new ClickBrowserHandler(clickBrowserInstruction);

            if (instruction is ExpectStatementInstruction expectStatementInstruction)
                return new ExpectStatementHandler(expectStatementInstruction);

            throw new NotSupportedException($"Instruction {instruction} is not supported by this driver.");
        }
    }
}