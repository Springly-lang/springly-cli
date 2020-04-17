using Irony.Ast;
using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.Text;
using TestScriptRunner.Language.Visitors;

namespace TestScriptRunner.Language.Ast
{
    public class ValueLiteralNode : BaseAstNode
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            throw new NotImplementedException();
        }
    }
}
