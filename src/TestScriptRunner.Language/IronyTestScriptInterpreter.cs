using Irony.Parsing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using SpringlyLang.Common;
using SpringlyLang.Common.UseDefinitions;
using SpringlyLang.Language.Ast;
using SpringlyLang.Language.Visitors;

namespace SpringlyLang.Language
{
    public class IronyTestScriptInterpreter : ITestScriptInterpreter
    {
        public IronyTestScriptInterpreter(IUseDefinitionFactory useDefinitionFactory)
        {
            if (useDefinitionFactory == null)
            {
                throw new ArgumentNullException(nameof(useDefinitionFactory));
            }

            UseDefinitionFactory = useDefinitionFactory;
        }

        public IUseDefinitionFactory UseDefinitionFactory { get; }

        public IEnumerable<TestScriptContext> Interpret(IEnumerable<SourceFile> files)
        {
            var grammar = new SpringlyGrammar();
            var language = new LanguageData(grammar);
            var parser = new Parser(language);

            foreach (var testFile in files)
            {
                var baseDir = Directory.GetParent(testFile.FileName).FullName;
                var context = new TestScriptContext(baseDir, testFile);

                var tree = parser.Parse(testFile.Content, testFile.FileName);
                switch (tree.Status)
                {
                    case ParseTreeStatus.Parsed:
                        var visitor = new ScriptVisitor(UseDefinitionFactory, context);
                        var program = tree.Root.AstNode as ProgramNode;
                        Traverse(visitor, program);

                        yield return context;
                        break;

                    case ParseTreeStatus.Error:

                        var exceptions = tree.ParserMessages.Select(message =>
                            new InvalidOperationException($"Syntax error at '{testFile.FileName}':{message.Location}\t {message.Message}"));

                        throw new AggregateException(exceptions);
                }
            }
        }

        private static void Traverse(IScriptVisitor visitor, BaseAstNode node)
        {
            visitor.BeginVisit(node);
            node.AcceptVisitor(visitor);
            foreach (BaseAstNode child in node.ChildNodes)
                Traverse(visitor, child);
            visitor.EndVisit(node);
        }
    }
}
