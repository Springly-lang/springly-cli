using Irony.Ast;
using Irony.Parsing;
using TestScriptRunner.Language.Visitors;

namespace TestScriptRunner.Language.Ast
{
    public class TestCaseNode : BaseAstNode
    {
        public string Name { get; set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            Name = treeNode.ChildNodes[2].Token.Text.Replace("\"", "");
            foreach (var child in treeNode.ChildNodes[3].ChildNodes)
                AddChild(string.Empty, child);
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
