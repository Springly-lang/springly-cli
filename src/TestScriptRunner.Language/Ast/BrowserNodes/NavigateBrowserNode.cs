using Irony.Ast;
using Irony.Parsing;
using SpringlyLang.Language.Visitors;

namespace SpringlyLang.Language.Ast.BrowserNodes
{
    public class NavigateBrowserNode : BaseAstNode
    {
        public string Url { get; protected set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Url = treeNode.ChildNodes[1].Token.Text;
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
