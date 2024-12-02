using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Core.Domains.Users.Commands;
using HealthCare.Core.Domains.Users.Entities;
using HealthCare.Framework.Commands;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;

namespace HealthCare.Core.ApplicationServices.Users.CommandHandlers;

public class CreateUserCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<CreateUserCommand>
{
    public override CommandResult Execute(CreateUserCommand command)
    {
        var commandResult = new CommandResult
        {
            Failed = false,
            ResultMessages = []
        };
        
        try
        {
            var hasUser = unitOfWork.UserQueryRepository.GetUserByUsername(command.Username);

            if (hasUser != null)
            {
                commandResult.Failed = true;

                commandResult.ResultMessages.Add(new ResultMessage()
                {
                    MessageType = MessageType.Danger,
                    MessageResource = MessageResource.UserIsDuplicate,
                    Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.UserIsDuplicate)
                });

                return commandResult;
            }
            
            var user = new User
            {
                Email = command.Email,
                IsActive = command.IsActive,
                Password = command.Password,
                Username = command.Username,
                FirstName = command.FirstName,
                ImageAddress = command.ImageAddress,
                IsAdmin = command.IsAdmin,
                JobPosition = command.JobPosition,
                LastName = command.LastName,
            };

            commandResult.ResultMessages.AddRange(user.GetBrokenRules());

            if (commandResult.ResultMessages.Count != 0)
            {
                commandResult.Failed = false;

                return commandResult;
            }

            unitOfWork.UserCommandRepository.Create(user);
            unitOfWork.Commit();

            // if (commandResult.ResultMessages.Count(x=>x.MessageType==MessageType.Danger) != 0)
            // {
            //     commandResult.Failed = true;
            //     return commandResult;
            // }

            commandResult.ResultMessages.Add(new ResultMessage()
            {
                MessageType = MessageType.Success,
                MessageResource = MessageResource.Successed,
                Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.Successed)
            });
        }
        catch (Exception ex)
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