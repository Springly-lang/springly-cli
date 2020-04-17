using Irony.Ast;
using Irony.Parsing;
using SpringlyLang.Language.Visitors;

namespace SpringlyLang.Language.Ast
{
    public class DefinitionNode : BaseAstNode
    {
        public string FileName { get; set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
            var fileName = treeNode.ChildNodes[1].Token.Text;
            FileName = fileName.Trim('\'', '"');
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
