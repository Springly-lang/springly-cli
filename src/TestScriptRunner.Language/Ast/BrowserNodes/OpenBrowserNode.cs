using Irony.Ast;
using Irony.Parsing;
using TestScriptRunner.Language.Visitors;

namespace TestScriptRunner.Language.Ast.BrowserNodes
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
