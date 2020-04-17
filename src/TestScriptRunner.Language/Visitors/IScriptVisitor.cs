using Irony.Interpreter.Ast;
using SpringlyLang.Language.Ast;
using SpringlyLang.Language.Ast.BrowserNodes;

namespace SpringlyLang.Language.Visitors
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
