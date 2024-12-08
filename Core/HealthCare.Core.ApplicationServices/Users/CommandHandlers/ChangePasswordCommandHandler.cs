using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Core.Domains.Users.Commands;
using HealthCare.Framework.Commands;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;

namespace HealthCare.Core.ApplicationServices.Users.CommandHandlers;

public class ChangePasswordCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<ChangePasswordCommand>
{
    public override CommandResult Execute(ChangePasswordCommand command)
    {
        var commandResult = new CommandResult();
        
        try
        {
            if (command.NewPassword != command.ConfirmPassword)
            {
                commandResult.Failed = true;

                commandResult.ResultMessages.Add(new ResultMessage()
                {
                    MessageType = MessageType.Danger,
                    MessageResource = MessageResource.PasswordNotConfirm,
                    Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.PasswordNotConfirm)
                });

                return commandResult;
            }

            var user = unitOfWork.UserQueryRepository.GetById(command.UserId);

            if (user == null)
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

            if (user.Password != command.OldPassword || !user.IsActive)
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

            user.Password = command.NewPassword;

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