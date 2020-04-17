using Irony.Parsing;
using TestScriptRunner.Language.Ast;
using TestScriptRunner.Language.Ast.BrowserNodes;

namespace TestScriptRunner.Language
{
    public class SpringlyGrammar : Grammar
    {
        //private readonly CommentTerminal Comment = new CommentTerminal(nameof(Comment), "/*", "*/");
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
        private readonly DefaultNonTerminal ExpectSmallerThanCommand = new DefaultNonTerminal(nameof(ExpectSmallerThanCommand), typeof(ExpectNode));
        private readonly DefaultNonTerminal ExpectSmallerThanOrEqualCommand = new DefaultNonTerminal(nameof(ExpectSmallerThanOrEqualCommand), typeof(ExpectNode));

        private readonly DefaultIdentifierTerminal Identifier = new DefaultIdentifierTerminal(nameof(Identifier), typeof(IdentifierNode));
        private readonly StringLiteral QoutedIdentifier = new StringLiteral(nameof(QoutedIdentifier), "\"", StringOptions.NoEscapes, typeof(IdentifierNode));
        private readonly StringLiteral StringLiteral = new StringLiteral(nameof(StringLiteral), "'", StringOptions.AllowsAllEscapes, typeof(StringLiteralNode));
        private readonly NumberLiteral NumericLiteral = TerminalFactory.CreatePythonNumber(nameof(NumericLiteral));
        private readonly Terminal ValueLiteral = new Terminal(nameof(ValueLiteral), TokenCategory.Content, TermFlags.IsLiteral);


        public SpringlyGrammar() : base(caseSensitive: false)
        {
            NumericLiteral.AstConfig.DefaultNodeCreator = () => new NumericLiteralNode();
            NumericLiteral.AstConfig.NodeType = typeof(NumericLiteralNode);

            ValueLiteral.AstConfig.DefaultNodeCreator = () => new NumericLiteralNode();
            ValueLiteral.AstConfig.NodeType = typeof(NumericLiteralNode);


            //term will be added to NonGrammarTerminals automatically 
            QoutedIdentifier.SetOutputTerminal(this, Identifier);

            //NonGrammarTerminals.Add(Comment);
            NonGrammarTerminals.Add(LineComment);


            Root = Program;

            // <Program> ::= <DefinitionList> <TestCaseList>
            Program.Rule = DefinitionList + TestCaseList;

            // <DefinitionList> ::= <Definition>*
            DefinitionList.Rule = MakeStarRule(DefinitionList, null, Definition);

            // <Definition> ::= "use" <StringLiteral>
            Definition.Rule = ToTerm("use") + StringLiteral;

            // <TestCaseList> ::= <TestCase>+
            TestCaseList.Rule = MakePlusRule(TestCaseList, null, TestCase);

            // <TestCase> ::= "test" "case" <StringLiteral> <CommandList>
            TestCase.Rule = ToTerm("test") + ToTerm("case") + StringLiteral + CommandList;

            // <CommandList> ::= <Command>+
            CommandList.Rule = MakePlusRule(CommandList, null, Command);

            // <Command> ::= <OpenBrowserCommand> | <NavigateBrowserCommand> | etc.
            Command.Rule = OpenBrowserCommand |
                           NavigateBrowserCommand |
                           CloseBrowserCommand |
                           ClickBrowserCommand | DoubleClickBrowserCommand | RightClickBrowserCommand |
                           ExpectNotEqualCommand | ExpectEqualCommand |
                           ExpectGreaterThanCommand | ExpectGreaterThanOrEqualCommand | ExpectSmallerThanCommand | ExpectSmallerThanOrEqualCommand;

            // <OpenBrowserCommand> ::= "open" <StringLiteral> "browser"
            OpenBrowserCommand.Rule = ToTerm("open") + StringLiteral + ToTerm("browser");

            // <NavigateBrowserCommand> ::= "navigate" "to" <StringLiteral>
            NavigateBrowserCommand.Rule = ToTerm("navigate") + ToTerm("to") + StringLiteral;

            // <CloseBrowserCommand> ::= "close" <StringLiteral> "browser"
            CloseBrowserCommand.Rule = ToTerm("close") + StringLiteral + ToTerm("browser");

            // <ClickBrowserCommand> ::= "click on" <Identifier>
            ClickBrowserCommand.Rule = ToTerm("click") + ToTerm("on") + Identifier;
            DoubleClickBrowserCommand.Rule = ToTerm("double click") + ToTerm("on") + Identifier;
            RightClickBrowserCommand.Rule = ToTerm("right click") + ToTerm("on") + Identifier;

            ExpectEqualCommand.Rule = ToTerm("expect") + Identifier + ToTerm("equal") + (ValueLiteral);
            ExpectNotEqualCommand.Rule = ToTerm("expect") + Identifier + ToTerm("not") + ToTerm("equal") + (ValueLiteral);

            ExpectGreaterThanCommand.Rule = ToTerm("expect") + Identifier + ToTerm("greater") + ToTerm("than") + (ValueLiteral);
            ExpectGreaterThanOrEqualCommand.Rule = ToTerm("expect") + Identifier + ToTerm("greater") + ToTerm("than") + ToTerm("or") + ToTerm("equal") + (ValueLiteral);

            ExpectSmallerThanCommand.Rule = ToTerm("expect") + Identifier + ToTerm("smaller") + ToTerm("than") + (ValueLiteral);
            ExpectSmallerThanOrEqualCommand.Rule = ToTerm("expect") + Identifier + ToTerm("smaller") + ToTerm("than") + ToTerm("or") + ToTerm("equal") + (ValueLiteral);

            // Grammar configurations
            MarkPunctuation("to", "on");

            LanguageFlags = LanguageFlags.CreateAst;
        }


        //public override void BuildAst(LanguageData language, ParseTree parseTree)
        //{
        //    var opHandler = new OperatorHandler(language.Grammar.CaseSensitive);
        //    Util.Check(!parseTree.HasErrors(), "ParseTree has errors, cannot build AST.");
        //    var astContext = new InterpreterAstContext(language, opHandler);
        //    astContext.DefaultNodeType = typeof(NumericLiteralNode);
        //    var astBuilder = new AstBuilder(astContext);
        //    astBuilder.BuildAst(parseTree);
        //}
    }
}
