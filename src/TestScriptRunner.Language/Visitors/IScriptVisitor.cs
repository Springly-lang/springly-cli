using Irony.Interpreter.Ast;
using TestScriptRunner.Language.Ast;
using TestScriptRunner.Language.Ast.BrowserNodes;

namespace TestScriptRunner.Language.Visitors
{
    public interface IScriptVisitor : IAstVisitor
    {
        void Visit(ProgramNode node);
        void Visit(DefinitionNode node);
        void Visit(TestCaseNode node);
        void Visit(OpenBrowserNode node);
        void Visit(NavigateBrowserNode node);
        void Visit(CloseBrowserNode node);
        void Visit(ClickBrowserNode node);
        void Visit(DoubleClickBrowserNode node);
        void Visit(RightClickBrowserNode node);
        void Visit(ExpectNode node);
    }
}
