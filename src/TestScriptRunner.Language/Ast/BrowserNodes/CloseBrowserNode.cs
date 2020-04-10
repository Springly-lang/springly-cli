using TestScriptRunner.Language.Visitors;

namespace TestScriptRunner.Language.Ast.BrowserNodes
{
    public class CloseBrowserNode : BaseAstNode
    {
        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
