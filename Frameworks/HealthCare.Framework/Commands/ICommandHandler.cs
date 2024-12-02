namespace HealthCare.Framework.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        CommandResult Execute(TCommand command);
    }
}
