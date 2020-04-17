using Irony.Parsing;
using TestScriptRunner.Language.Ast;
using TestScriptRunner.Language.Ast.BrowserNodes;

namespace TestScriptRunner.Language
{
    public class SpringlyGrammar : Grammar
    {
        private readonly CommentTerminal LineComment = new CommentTerminal(nameof(LineComment), "#", "\n", "\r\n");

        private readonly DefaultNonTerminal Program = new DefaultNonTerminal(nameof(Program), typeof(ProgramNode));
        private readonly DefaultNonTerminal DefinitionList = new DefaultNonTerminal(nameof(DefinitionList), typeof(DefinitionListNode));
        private readonly DefaultNonTerminal Definition = new DefaultNonTerminal(nameof(Definition), typeof(DefinitionNode));
        private readonly DefaultNonTerminal TestCaseList = new DefaultNonTerminal(nameof(TestCaseList), typeof(TestCaseListNode));
        private readonly DefaultNonTerminal TestCase = new DefaultNonTerminal(nameof(TestCase), typeof(TestCaseNode));

        private readonly DefaultNonTerminal CommandList = new DefaultNonTerminal(nameof(CommandList), typeof(CommandListNode));
        private readonly DefaultNonTerminal Command = new DefaultNonTerminal(nameof(Command), typeof(CommandNode));

        // Browser commands
        private readonly DefaultNonTerminal OpenBrowserCommand = new DefaultNonTerminal(nameof(OpenBrowserCommand), typeof(OpenBrowserNode));
        private readonly DefaultNonTerminal NavigateBrowserCommand = new DefaultNonTerminal(nameof(NavigateBrowserCommand), typeof(NavigateBrowserNode));
        private readonly DefaultNonTerminal CloseBrowserCommand = new DefaultNonTerminal(nameof(CloseBrowserCommand), typeof(CloseBrowserNode));
        private readonly DefaultNonTerminal ClickBrowserCommand = new DefaultNonTerminal(nameof(ClickBrowserCommand), typeof(ClickBrowserNode));
        private readonly DefaultNonTerminal DoubleClickBrowserCommand = new DefaultNonTerminal(nameof(DoubleClickBrowserCommand), typeof(DoubleClickBrowserNode));
        private readonly DefaultNonTerminal RightClickBrowserCommand = new DefaultNonTerminal(nameof(RightClickBrowserCommand), typeof(RightClickBrowserNode));

        private readonly DefaultNonTerminal ExpectEqualCommand = new DefaultNonTerminal(nameof(ExpectEqualCommand), typeof(ExpectNode));
        private readonly DefaultNonTerminal ExpectNotEqualCommand = new DefaultNonTerminal(nameof(ExpectNotEqualCommand), typeof(ExpectNode));
        private readonly DefaultNonTerminal ExpectGreaterThanCommand = new DefaultNonTerminal(nameof(ExpectGreaterThanCommand), typeof(ExpectNode));
        private readonly DefaultNonTerminal ExpectGreaterThanOrEqualCommand = new DefaultNonTerminal(nameof(ExpectGreaterThanOrEqualCommand), typeof(ExpectNode));
        private readonly DefaultNonTerminal ExpectLessThanCommand = new DefaultNonTerminal(nameof(ExpectLessThanCommand), typeof(ExpectNode));
        private readonly DefaultNonTerminal ExpectLessThanOrEqualCommand = new DefaultNonTerminal(nameof(ExpectLessThanOrEqualCommand), typeof(ExpectNode));

        private readonly DefaultIdentifierTerminal Identifier = new DefaultIdentifierTerminal(nameof(Identifier), typeof(IdentifierNode));
        private readonly StringLiteral QoutedIdentifier = new StringLiteral(nameof(QoutedIdentifier), "\"", StringOptions.NoEscapes, typeof(IdentifierNode));
        private readonly StringLiteral StringLiteral = new StringLiteral(nameof(StringLiteral), "'", StringOptions.AllowsAllEscapes, typeof(StringLiteralNode));
        private readonly NumberLiteral NumericLiteral = new NumberLiteral(nameof(NumericLiteral), NumberOptions.AllowSign | NumberOptions.AllowStartEndDot, typeof(NumericLiteralNode));
        private readonly NonTerminal ValueLiteral = new NonTerminal(nameof(ValueLiteral), typeof(ValueLiteralNode));

        public SpringlyGrammar() : base(caseSensitive: false)
        {
            NumericLiteral.AstConfig.DefaultNodeCreator = () => new NumericLiteralNode();
            NumericLiteral.AstConfig.NodeType = typeof(NumericLiteralNode);

            ValueLiteral.Rule = StringLiteral | NumericLiteral;

            //term will be added to NonGrammarTerminals automatically 
            QoutedIdentifier.SetOutputTerminal(this, Identifier);

            //NonGrammarTerminals.Add(Comment);
            NonGrammarTerminals.Add(LineComment);


            // <OpenBrowserCommand> ::= "open" <StringLiteral> "browser"
            OpenBrowserCommand.Rule = ToTerm(Keywords.Open) + StringLiteral + ToTerm(Keywords.Browser);

            // <NavigateBrowserCommand> ::= "navigate" "to" <StringLiteral>
            NavigateBrowserCommand.Rule = ToTerm(Keywords.Navigate) + ToTerm(Keywords.To) + StringLiteral;

            // <CloseBrowserCommand> ::= "close" <StringLiteral> "browser"
            CloseBrowserCommand.Rule = ToTerm(Keywords.Close) + StringLiteral + ToTerm(Keywords.Browser);

            // <ClickBrowserCommand> ::= "click on" <Identifier>
            ClickBrowserCommand.Rule = ToTerm(Keywords.Click) + ToTerm(Keywords.On) + Identifier;
            DoubleClickBrowserCommand.Rule = ToTerm(Keywords.Double) + ToTerm(Keywords.Click) + ToTerm(Keywords.On) + Identifier;
            RightClickBrowserCommand.Rule = ToTerm(Keywords.Right) + ToTerm(Keywords.Click) + ToTerm(Keywords.On) + Identifier;

            // <ExpectEqualCommand> ::= "expect" <Identifier> equal <ValueLiteral>
            ExpectEqualCommand.Rule = ToTerm(Keywords.Expect) + Identifier + ToTerm(Keywords.Equal) + (ValueLiteral);

            // <ExpectEqualCommand> ::= "expect" <Identifier> not equal <ValueLiteral>
            ExpectNotEqualCommand.Rule = ToTerm(Keywords.Expect) + Identifier + ToTerm(Keywords.Not) + ToTerm(Keywords.Equal) + (ValueLiteral);

            // <ExpectEqualCommand> ::= "expect" <Identifier> greater than <ValueLiteral>
            ExpectGreaterThanCommand.Rule = ToTerm(Keywords.Expect) + Identifier + ToTerm(Keywords.Greater) + ToTerm(Keywords.Than) + (ValueLiteral);

            // <ExpectEqualCommand> ::= "expect" <Identifier> greater than or equal <ValueLiteral>
            ExpectGreaterThanOrEqualCommand.Rule = ToTerm(Keywords.Expect) + Identifier + ToTerm(Keywords.Greater) + ToTerm(Keywords.Than) + ToTerm(Keywords.Or) + ToTerm(Keywords.Equal) + (ValueLiteral);

            // <ExpectEqualCommand> ::= "expect" <Identifier> less than <ValueLiteral>
            ExpectLessThanCommand.Rule = ToTerm(Keywords.Expect) + Identifier + ToTerm(Keywords.Less) + ToTerm(Keywords.Than) + (ValueLiteral);

            // <ExpectEqualCommand> ::= "expect" <Identifier> less than or equal <ValueLiteral>
            ExpectLessThanOrEqualCommand.Rule = ToTerm(Keywords.Expect) + Identifier + ToTerm(Keywords.Less) + ToTerm(Keywords.Than) + ToTerm(Keywords.Or) + ToTerm(Keywords.Equal) + (ValueLiteral);


            // <Command> ::= <OpenBrowserCommand> | <NavigateBrowserCommand> | etc.
            Command.Rule = OpenBrowserCommand |
                           NavigateBrowserCommand |
                           CloseBrowserCommand |
                           ClickBrowserCommand | DoubleClickBrowserCommand | RightClickBrowserCommand |
                           ExpectNotEqualCommand | ExpectEqualCommand | 
                           ExpectGreaterThanCommand | ExpectGreaterThanOrEqualCommand | 
                           ExpectLessThanCommand | ExpectLessThanOrEqualCommand;

            // <CommandList> ::= <Command>+
            CommandList.Rule = MakePlusRule(CommandList, null, Command);


            // <TestCase> ::= "test" "case" <StringLiteral> <CommandList>
            TestCase.Rule = ToTerm(Keywords.Test) + ToTerm(Keywords.Case) + StringLiteral + CommandList;


            // <TestCaseList> ::= <TestCase>+
            TestCaseList.Rule = MakePlusRule(TestCaseList, null, TestCase);


            // <Definition> ::= "use" <StringLiteral>
            Definition.Rule = ToTerm(Keywords.Use) + StringLiteral;


            // <DefinitionList> ::= <Definition>*
            DefinitionList.Rule = MakeStarRule(DefinitionList, null, Definition);


            // <Program> ::= <DefinitionList> <TestCaseList>
            Program.Rule = DefinitionList + TestCaseList;

            Root = Program;

            // Grammar configurations
            MarkPunctuation(Keywords.To, Keywords.On);

            LanguageFlags = LanguageFlags.CreateAst;
        }
    }
}
