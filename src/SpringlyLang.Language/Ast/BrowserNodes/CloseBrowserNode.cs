using SpringlyLang.Language.Visitors;

namespace SpringlyLang.Language.Ast.BrowserNodes
{
    public class CloseBrowserNode : BaseAstNode
    {
        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
