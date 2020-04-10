﻿using Irony.Parsing;
using TestScriptRunner.Language.Ast;

namespace TestScriptRunner.Language
{
    public class SpringlyGrammar : Grammar
    {
        private readonly CommentTerminal Comment = new CommentTerminal(nameof(Comment), "/*", "*/");
        private readonly CommentTerminal LineComment = new CommentTerminal(nameof(LineComment), "#", "\n", "\r\n");

        private readonly DefaultNonTerminal Program = new DefaultNonTerminal(nameof(Program), typeof(ProgramNode));
        private readonly DefaultNonTerminal DefinitionList = new DefaultNonTerminal(nameof(DefinitionList), typeof(DefinitionListNode));
        private readonly DefaultNonTerminal Definition = new DefaultNonTerminal(nameof(Definition), typeof(DefinitionNode));
        private readonly DefaultNonTerminal TestCaseList = new DefaultNonTerminal(nameof(TestCaseList), typeof(TestCaseListNode));
        private readonly DefaultNonTerminal TestCase = new DefaultNonTerminal(nameof(TestCase), typeof(TestCaseNode));

        private readonly DefaultNonTerminal CommandList = new DefaultNonTerminal(nameof(CommandList), typeof(CommandListNode));
        private readonly DefaultNonTerminal Command = new DefaultNonTerminal(nameof(Command), typeof(CommandNode));
        private readonly DefaultNonTerminal OpenBrowserCommand = new DefaultNonTerminal(nameof(OpenBrowserCommand), typeof(OpenBrowserNode));
        private readonly DefaultNonTerminal NavigateBrowserCommand = new DefaultNonTerminal(nameof(NavigateBrowserCommand), typeof(NavigateBrowserNode));
        private readonly DefaultNonTerminal CloseBrowserCommand = new DefaultNonTerminal(nameof(CloseBrowserCommand), typeof(CloseBrowserNode));

        private readonly DefaultIdentifierTerminal Identifier = new DefaultIdentifierTerminal(nameof(Identifier), typeof(IdentifierNode));
        private readonly StringLiteral QoutedIdentifier = new StringLiteral(nameof(QoutedIdentifier), "\"", StringOptions.NoEscapes, typeof(IdentifierNode));
        private readonly StringLiteral StringLiteral = new StringLiteral(nameof(StringLiteral), "'", StringOptions.AllowsAllEscapes, typeof(StringLiteralNode));
        private readonly NumberLiteral NumericLiteral = new NumberLiteral(nameof(NumericLiteral), NumberOptions.Default, typeof(NumericLiteralNode));
        

        public SpringlyGrammar() : base(caseSensitive: false)
        {
            //term will be added to NonGrammarTerminals automatically 
            QoutedIdentifier.SetOutputTerminal(this, Identifier);

            NonGrammarTerminals.Add(Comment);
            NonGrammarTerminals.Add(LineComment);


            Root = Program;

            // <Program> ::= <DefinitionList> <TestCaseList>
            Program.Rule = DefinitionList + TestCaseList;

            // <DefinitionList> ::= <Definition>+
            DefinitionList.Rule = MakePlusRule(DefinitionList, null, Definition);

            // <Definition> ::= "use" <StringLiteral>
            Definition.Rule = ToTerm("use") + StringLiteral;

            // <TestCaseList> ::= <TestCase>+
            TestCaseList.Rule = MakePlusRule(TestCaseList, null, TestCase);

            // <TestCase> ::= "test" "case" <Identifier> <CommandList>
            TestCase.Rule = ToTerm("test") + ToTerm("case") + Identifier + CommandList;

            // <CommandList> ::= <Command>+
            CommandList.Rule = MakePlusRule(CommandList, null, Command);

            // <Command> ::= <OpenBrowserCommand> | <NavigateBrowserCommand> | <CloseBrowserCommand>
            Command.Rule = OpenBrowserCommand | NavigateBrowserCommand | CloseBrowserCommand;

            // <OpenBrowserCommand> ::= "open" <StringLiteral> "browser"
            OpenBrowserCommand.Rule = ToTerm("open") + StringLiteral + ToTerm("browser");

            // <NavigateBrowserCommand> ::= "navigate" "to" <StringLiteral>
            NavigateBrowserCommand.Rule = ToTerm("navigate") + ToTerm("to") + StringLiteral;

            // <CloseBrowserCommand> ::= "close" <StringLiteral> "browser"
            CloseBrowserCommand.Rule = ToTerm("close") + StringLiteral + ToTerm("browser");

            // Grammar configurations
            MarkPunctuation("to");
            
            LanguageFlags = LanguageFlags.CreateAst;
        }
    }
}
