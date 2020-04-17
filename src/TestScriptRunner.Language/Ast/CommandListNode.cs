using Irony.Ast;
using Irony.Parsing;
using SpringlyLang.Language.Visitors;

namespace SpringlyLang.Language.Ast
{
    public class CommandListNode : BaseAstNode
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            foreach (var child in treeNode.ChildNodes)
                AddChild(null, child);
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            //visitor.Visit(this);
        }
    }
}
