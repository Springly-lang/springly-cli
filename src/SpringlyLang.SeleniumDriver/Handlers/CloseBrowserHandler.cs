﻿using System.Collections.Generic;
using System.Data;
using SpringlyLang.Common.Instructions;
using SpringlyLang.Common.UseDefinitions;

namespace SpringlyLang.SeleniumDriver.Handlers
{
    public class CloseBrowserHandler : IInstructionHandler
    {
        private readonly CloseBrowserInstruction _closeBrowserInstruction;

        public CloseBrowserHandler(CloseBrowserInstruction closeBrowserInstruction)
        {
            _closeBrowserInstruction = closeBrowserInstruction;
        }
        public void Handle(IEnumerable<TestCaseUseDefinition> definitions, BrowserScope scope)
        {
            // Named close browser is not supported yet.
            if (scope.IsEmpty)
                throw new SyntaxErrorException($"There is no browser in this scope to close.");

            scope.Default.Quit();
        }
    }
}