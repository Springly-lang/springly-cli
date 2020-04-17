using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;
using SpringlyLang.Common;
using SpringlyLang.Language.Visitors;

namespace SpringlyLang.Language.Ast
{
    public class ProgramNode : BaseAstNode
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            var definitionList = treeNode.ChildNodes[0];
            foreach (var definition in definitionList.ChildNodes)
            {
                AddChild(string.Empty, definition);
            }

            var testCaseList = treeNode.ChildNodes[1];
            foreach (var testCase in testCaseList.ChildNodes)
            {
                AddChild(string.Empty, testCase);
            }
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
