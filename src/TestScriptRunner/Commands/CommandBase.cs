namespace TestScriptRunner
{
    public abstract class CommandBase
    {
        public CommandBase(Statement statement)
        {
            Statement = statement;
        }

        public Statement Statement { get; }
    }
}