using Irony.Ast;
using Irony.Parsing;
using System;
using System.Linq;
using TestScript.Common;
using TestScript.Common.Instructions;
using TestScriptRunner.Language.Visitors;

namespace TestScriptRunner.Language.Ast
{
    public class ExpectNode : BaseAstNode
    {
        public ExpectComparerOperator ComparerOperator { get; private set; }
        public string Target { get; private set; }
        public string Value { get; private set; }

        public override void Init(AstContext context, ParseTreeNode treeNode)
        {
            base.Init(context, treeNode);

            var isNegative = ContainsAny(treeNode.ChildNodes, Keywords.Not);

            if (ContainsAll(treeNode.ChildNodes, Keywords.Greater, Keywords.Equal))
                ComparerOperator = ExpectComparerOperator.GreaterThanOrEqual;
            else if (ContainsAny(treeNode.ChildNodes, Keywords.Greater))
                ComparerOperator = ExpectComparerOperator.Greater;
            else if (ContainsAll(treeNode.ChildNodes, Keywords.Less, Keywords.Equal))
                ComparerOperator = ExpectComparerOperator.LessThanOrEqual;
            else if (ContainsAny(treeNode.ChildNodes, Keywords.Less))
                ComparerOperator = ExpectComparerOperator.Less;
            else
                ComparerOperator = isNegative ? ExpectComparerOperator.NotEqual : ExpectComparerOperator.Equal;

            var identifier = treeNode.ChildNodes.FirstOrDefault(x => x.AstNode?.GetType() == typeof(IdentifierNode));
            Target = identifier.Token.Text.TrimSurroundings();

            var valueLiteral = treeNode.ChildNodes.Last(x => x.Term.GetType() == typeof(NonTerminal));

            Value = valueLiteral.ChildNodes[0].Token?.Text?.TrimSurroundings();
        }

        private static bool ContainsAny(ParseTreeNodeList nodes, string term)
        {
            return nodes.Any(node => string.Equals(node?.Token?.Text, term, StringComparison.OrdinalIgnoreCase));
        }

        private static bool ContainsAll(ParseTreeNodeList nodes, params string[] terms)
        {
            return terms.All(term => nodes.Any(node => string.Equals(node?.Token?.Text, term, StringComparison.OrdinalIgnoreCase)));
        }

        public override void AcceptVisitor(IScriptVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
