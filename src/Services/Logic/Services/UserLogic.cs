using System;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using Domain.Entries;
using Logic.Services.Interfaces;
using Microsoft.Bot.Schema;
using Microsoft.EntityFrameworkCore;

namespace Logic.Services
{
    /// <summary>
    /// Operations with <see cref="User"/>.
    /// </summary>
    public class UserLogic : IUserLogic
    {
        private readonly TelegramContext _telegramContext;

        /// <summary>
        /// Operations with <see cref="User"/>.
        /// </summary>
        public UserLogic(TelegramContext telegramContext)
        {
            _telegramContext = telegramContext;
        }

        /// <summary>
        /// Adds a new user into database.
        /// </summary>
        /// <param name="channelAccount">Channel acciunt.</param>
        public async Task<OperationResponse> AddNewUserAsync(ChannelAccount channelAccount)
        {
            var response = new OperationResponse();
            User newUserToBeAdded = new User()
            {
                Id = channelAccount.Id,
                Name = channelAccount.Name,
                AadObjectId = channelAccount.AadObjectId,
                Role = channelAccount.Role,
                Properties = channelAccount.Properties.ToString()
            };

            _telegramContext.Users.Add(newUserToBeAdded);

            try
            {
                var entitiesAdded = await _telegramContext.SaveChangesAsync();
                response.Success = true;
                return response;
            }
            catch (System.Exception ex)
            {
                response.ErrorMessage = string.IsNullOrEmpty(ex.InnerException.Message) ? ex.InnerException.Message : ex.Message;
                return response;
            }
        }

        /// <summary>
        /// Sets user notification type.
        /// </summary>
        /// <param name="channelAccount">Channel acciunt</param>
        /// <param name="userNotificationType">Notification type.</param>
        public async Task<OperationResponse> SetUserNotificationTypeAsync(ChannelAccount channelAccount, UserNotificationType userNotificationType)
        {
            if (channelAccount == null) throw new ArgumentNullException(nameof(channelAccount));
            if (userNotificationType == null) throw new ArgumentNullException(nameof(userNotificationType));

            var response = new OperationResponse();
            User user = _telegramContext.Users.FirstOrDefault(x => x.Id == channelAccount.Id);

            if (user is null)
            {
                response.ErrorMessage = $"User with id:{channelAccount.Id} not found.";
                return response;
            }

            user.NotificationType = userNotificationType;

            try
            {
                _telegramContext.Users.Update(user);
                await _telegramContext.SaveChangesAsync();

                response.Success = true;
                return response;
            }
            catch (Exception ex)
            {
                response.ErrorMessage = ex.InnerException is null ? ex.Message : ex.InnerException.Message;
                return response;
            }
        }

        /// <summary>
        /// Sets user status. 
        /// Use case: Setting user status of what we are expecting from user, for instance
        /// we are expecting from user to enter city name, so we are setting user status UserStatusEnum.ENTER_CITY_NAME
        /// </summary>
        /// <param name="channelAccount">Channel account.</param>
        /// <param name="userStatusLabel">User status.</param>
        public async Task<OperationResponse> SetUserStatusAsync(ChannelAccount channelAccount, string userStatusLabel)
        {
            if (channelAccount == null) throw new ArgumentNullException(nameof(channelAccount));
            if (userStatusLabel == null) throw new ArgumentNullException(nameof(userStatusLabel));

            var response = new OperationResponse();
            User user = _telegramContext.Users.Include(x => x.UserStatus).FirstOrDefault(x => x.Id == channelAccount.Id);

            if (user is null)
            {
                response.ErrorMessage = $"User with id:{channelAccount.Id} not found.";
                return response;
            }

            UserStatus userStatus = _telegramContext.UserStatuses.FirstOrDefault(x => x.Label == userStatusLabel);
            user.UserStatus = userStatus;

            try
            {
                _telegramContext.Users.Update(user);
                await _telegramContext.SaveChangesAsync();

                response.Success = true;
                return response;
            }
            catch (System.Exception ex)
            {
                response.ErrorMessage = ex.InnerException is null ? ex.Message : ex.InnerException.Message;
                return response;
            }
        }

        /// <summary>
        /// Gets user by user id.
        /// </summary>
        /// <param name="id">User identifier.</param>
        public User GetUserById(string id) => _telegramContext.Users.Include(x => x.UserStatus).FirstOrDefault(x => x.Id == id);
    }
}
