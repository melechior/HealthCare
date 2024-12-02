using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;


namespace HealthCare.Framework.Commands;

public class CommandDispatcher
{
    private readonly IServiceProvider _provider;

    public CommandDispatcher(IServiceProvider provider)
    {
        _provider = provider;
    }

    public CommandResult Dispatch(ICommand command)
    {
        try
        {
            var type = typeof(CommandHandler<>);
            Type[] typeArgs = { command.GetType() };
            var handlerType = type.MakeGenericType(typeArgs);
            dynamic handler = _provider.GetService(handlerType);
            CommandResult result = handler.Execute((dynamic)command);
            return result;
        }
        catch (Exception ex)
        {
            return new CommandResult
            {
                Failed = true,
                ResultMessages = new List<ResultMessage> {
                    new ResultMessage{
                        MessageType = MessageType.Danger,
                        MessageResource = MessageResource.ErrorHasBeenOccoured,
                        Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.ErrorHasBeenOccoured)
                    }
                },
            };
        }
    }
}