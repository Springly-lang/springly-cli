namespace Springly.Commands
{
    public interface ICommand
    {
        int Order => 1;

        ExecutionResult Execute(string statement, ExecutionContext context);
    }
}
