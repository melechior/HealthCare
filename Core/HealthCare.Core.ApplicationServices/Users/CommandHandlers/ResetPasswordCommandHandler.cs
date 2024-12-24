using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Core.Domains.Users.Commands;
using HealthCare.Framework.Commands;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;

namespace HealthCare.Core.ApplicationServices.Users.CommandHandlers;

public class ResetPasswordCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<ResetPasswordCommand>
{
    public override CommandResult Execute(ResetPasswordCommand command)
    {
        var commandResult = new CommandResult();

        try
        {
            if (string.IsNullOrEmpty(command.Password))
            {
                commandResult.Failed = true;

                commandResult.ResultMessages.Add(new ResultMessage()
                {
                    MessageType = MessageType.Danger,
                    MessageResource = MessageResource.PasswordIsEmpty,
                    Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.PasswordIsEmpty)
                });

                return commandResult;
            }

            var user = unitOfWork.UserQueryRepository.GetById(command.UserId);

            if (user == null || user.Username != command.UserName)
            {
                commandResult.Failed = true;

                commandResult.ResultMessages.Add(new ResultMessage()
                {
                    MessageType = MessageType.Danger,
                    MessageResource = MessageResource.UserNotFound,
                    Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.UserNotFound)
                });

                return commandResult;
            }

            if (!user.IsActive)
            {
                commandResult.Failed = true;

                commandResult.ResultMessages.Add(new ResultMessage()
                {
                    MessageType = MessageType.Danger,
                    MessageResource = MessageResource.UserIsInActive,
                    Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.UserIsInActive)
                });

                return commandResult;
            }

            user.Password = command.Password;

            unitOfWork.UserCommandRepository.Edit(user);
            unitOfWork.Commit();

            commandResult.ResultMessages.Add(new ResultMessage()
            {
                MessageType = MessageType.Success,
                MessageResource = MessageResource.Successed,
                Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.Successed)
            });
        }
        catch (Exception)
        {
            commandResult.Failed = true;

            commandResult.ResultMessages.Add(new ResultMessage
            {
                MessageType = MessageType.Danger,
                MessageResource = MessageResource.ErrorHasBeenOccoured,
                Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.ErrorHasBeenOccoured)
            });
        }

        return commandResult;
    }
}