using Irony.Ast;
using Irony.Parsing;
using SpringlyLang.Language.Visitors;

namespace SpringlyLang.Language.Ast.BrowserNodes
{
    public class OpenBrowserNode : BaseAstNode
    {
        public string BrowserName { get; set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            BrowserName = treeNode.ChildNodes[1].Token.Text;
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
