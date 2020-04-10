using Irony.Ast;
using Irony.Parsing;
using TestScriptRunner.Language.Visitors;

namespace TestScriptRunner.Language.Ast
{
    public class TestCaseListNode : BaseAstNode
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            foreach (var child in treeNode.ChildNodes)
                AddChild(string.Empty, child);
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            //visitor.Visit(this);
        }
    }
}
