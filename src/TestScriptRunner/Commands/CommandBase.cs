namespace TestScriptRunner.Commands
{
    public abstract class CommandBase
    {
        public static readonly NoOpCommand NoOp = new NoOpCommand();

        public sealed class NoOpCommand : CommandBase
        {
            public NoOpCommand() : base(null)
            {
            }
        }


        public CommandBase(Statement statement)
        {
            Statement = statement;
        }

        public Statement Statement { get; }
    }
}