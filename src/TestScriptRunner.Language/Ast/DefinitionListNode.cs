﻿using Irony.Ast;
using Irony.Parsing;
using TestScriptRunner.Language.Visitors;

namespace TestScriptRunner.Language.Ast
{
    public class DefinitionListNode : BaseAstNode
    {
        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            //visitor.Visit(this);
        }
    }
}