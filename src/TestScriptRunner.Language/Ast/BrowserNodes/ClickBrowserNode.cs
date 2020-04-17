using Irony.Ast;
using Irony.Parsing;
using TestScript.Common;
using TestScriptRunner.Language.Visitors;

namespace TestScriptRunner.Language.Ast.BrowserNodes
{
    public class ClickBrowserNode : BaseAstNode, IHaveIdentifierNode
    {
        public string Identifier { get; set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Identifier = treeNode.ChildNodes[1].Token.Text.TrimSurroundings();
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class DoubleClickBrowserNode : BaseAstNode, IHaveIdentifierNode
    {
        public string Identifier { get; set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Identifier = treeNode.ChildNodes[2].Token.Text.TrimSurroundings();
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class RightClickBrowserNode : BaseAstNode, IHaveIdentifierNode
    {
        public string Identifier { get; set; }
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Identifier = treeNode.ChildNodes[2].Token.Text.TrimSurroundings();
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
