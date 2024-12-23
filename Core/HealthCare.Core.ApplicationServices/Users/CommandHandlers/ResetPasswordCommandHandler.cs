using HealthCare.Core.Domains.UnitOfWork;
using HealthCare.Core.Domains.Users.Commands;
using HealthCare.Framework.Commands;
using HealthCare.Framework.Resources;
using HealthCare.Infrastructures.Shared.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthCare.Core.ApplicationServices.Users.CommandHandlers
{
    public class ResetPasswordCommandHandler(IUnitOfWork unitOfWork) : CommandHandler<ResetPassworldCommand>
    {
        public override CommandResult Execute(ResetPassworldCommand command)
        {
            var commandResult = new CommandResult();

            try
            {
                if (command.Password == string.Empty)
                {
                    commandResult.Failed = true;

                    commandResult.ResultMessages.Add(new ResultMessage()
                    {
                        MessageType = MessageType.Danger,
                        MessageResource = MessageResource.PasswordNotConfirm,
                        Message = EnumHelper<MessageResource>.GetDisplayValue(MessageResource.PasswordIsEmpty)
                    });

                    return commandResult;
                }

                var user = unitOfWork.UserQueryRepository.GetUserByUsername(command.UserName);

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

                if ( !user.IsActive)
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
}