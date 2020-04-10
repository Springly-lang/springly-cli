using Irony.Interpreter.Ast;
using System.IO;
using TestScript.Common;
using TestScript.Common.Instructions;
using TestScriptRunner.Common.UseDefinitions;
using TestScriptRunner.Language.Ast;
using TestScriptRunner.Language.Ast.BrowserNodes;

namespace TestScriptRunner.Language.Visitors
{
    public class ScriptVisitor : IScriptVisitor
    {
        public ScriptVisitor(IUseDefinitionFactory useDefinitionFactory, TestScriptContext context)
        {
            UseDefinitionFactory = useDefinitionFactory;
            Context = context;
        }

        public IUseDefinitionFactory UseDefinitionFactory { get; }
        public TestScriptContext Context { get; }

        public void BeginVisit(IVisitableNode node)
        {
        }

        public void EndVisit(IVisitableNode node)
        {
        }

        public void Visit(ProgramNode node)
        {
            // System.Diagnostics.Debugger.Break();
        }

        public void Visit(ClickBrowserNode node)
        {
            Context.LastTestCase.Instructions.Add(new ClickBrowserInstruction(ClickType.SingleClick, node.Identifier));
        }

        public void Visit(DoubleClickBrowserNode node)
        {
            Context.LastTestCase.Instructions.Add(new ClickBrowserInstruction(ClickType.DoubleClick, node.Identifier));
        }

        public void Visit(RightClickBrowserNode node)
        {
            Context.LastTestCase.Instructions.Add(new ClickBrowserInstruction(ClickType.RightClick, node.Identifier));
        }


        public void Visit(DefinitionNode node)
        {
            var filePath = Path.Combine(Context.BaseDirectory, node.FileName);
            var definition = UseDefinitionFactory.FromFile(filePath);
            Context.AddTestDefinition(definition);
        }

        public void Visit(TestCaseNode node)
        {
            var testCase = new TestCase(node.Name);
            Context.AddTestCase(testCase);
        }

        public void Visit(OpenBrowserNode node)
        {
            Context.LastTestCase.Instructions.Add(new OpenBrowserInstruction(node.BrowserName));
        }

        public void Visit(NavigateBrowserNode node)
        {
            var trimedUrl = node.Url.Trim('\'', '"');
            Context.LastTestCase.Instructions.Add(new BrowserNavigateInstruction(trimedUrl));
        }

        public void Visit(CloseBrowserNode node)
        {
            Context.LastTestCase.Instructions.Add(new CloseBrowserInstruction(null));
        }
    }
}
