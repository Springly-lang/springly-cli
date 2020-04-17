using Irony.Ast;
using Irony.Interpreter.Ast;
using Irony.Parsing;
using SpringlyLang.Language.Visitors;

namespace SpringlyLang.Language.Ast
{
    public abstract class BaseAstNode : AstNode
    {
        public abstract void AcceptVisitor(IScriptVisitor visitor);
    }
}
