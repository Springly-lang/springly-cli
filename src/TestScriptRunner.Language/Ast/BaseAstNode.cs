using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;
using TestScriptRunner.Language.Visitors;

namespace TestScriptRunner.Language.Ast
{
    public abstract class BaseAstNode : AstNode
    {
        public abstract void AcceptVisitor(IScriptVisitor visitor);
    }
}
