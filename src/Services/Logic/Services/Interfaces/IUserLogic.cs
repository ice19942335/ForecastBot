using System.Threading.Tasks;
using Domain.Entries;
using Microsoft.Bot.Schema;

namespace Logic.Services.Interfaces
{
    /// <summary>
    /// Operations with <see cref="User"/>.
    /// </summary>
    public interface IUserLogic
    {
        /// <summary>
        /// Adds a new user into database.
        /// </summary>
        /// <param name="channelAccount">Channel account.</param>
        Task<OperationResponse> AddNewUserAsync(ChannelAccount channelAccount);

        /// <summary>
        /// Sets user notification type.
        /// </summary>
        /// <param name="userNotificationType">User notification type.</param>
        Task<OperationResponse> SetUserNotificationTypeAsync(ChannelAccount user, UserNotificationType userNotificationType);

        /// <summary>
        /// Sets user status. 
        /// Use case: Setting user status of what we are expecting from user, for instance
        /// we are expecting from user to enter city name, so we are setting user status UserStatusEnum.ENTER_CITY_NAME
        /// </summary>
        /// <param name="channelAccount">Channel account.</param>
        /// <param name="userStatusLabel">User status.</param>
        Task<OperationResponse> SetUserStatusAsync(ChannelAccount channelAccount, string userStatusLabel);

        /// <summary>
        /// Gets user by user id.
        /// </summary>
        /// <param name="id">User identifier.</param>
        User GetUserById(string id);
    }
}