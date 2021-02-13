using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Context;
using Domain.Entries;
using Enums;

namespace Logic.Services.Initialization
{
    /// <summary>
    /// Initializing default data.
    /// Writing master-data into database.
    /// </summary>
    public class SqlDataInitializer
    {
        private readonly TelegramContext _telegramContext;

        /// <summary>
        /// Initializing default data.
        /// Writing Masterdata into database.
        /// </summary>
        public SqlDataInitializer(TelegramContext telegramContext)
        {
            _telegramContext = telegramContext;
        }

        /// <summary>
        /// Runs chane of initialization methods.
        /// </summary>
        public async Task InitializeAsync()
        {
            await this.InitializeDefaultEntriesAsync();
        }

        /// <summary>
        /// Checking wether app runing first time after database creation and calls initialization menthods.
        /// </summary>
        private async Task InitializeDefaultEntriesAsync()
        {
            if (_telegramContext.NotificationTypes.Any() == false)
            {
                this.InitializeNotificationTypes();
            }

            if (_telegramContext.TelegramCommands.Any() == false)
            {
                this.InitializeTelegramCommands();
            }

            if (_telegramContext.UserStatuses.Any() == false)
            {
                this.InitializeUserStatuses();
            }

            await SaveChangesAsync();
        }

        /// <summary>
        /// Saves chandes in database.
        /// </summary>
        private async Task SaveChangesAsync()
        {
            await _telegramContext.SaveChangesAsync();
        }

        /// <summary>
        /// Adds user statuses entries into database.
        /// </summary>
        private void InitializeUserStatuses()
        {
            _telegramContext.UserStatuses.AddRange(this.GetDefaultStatuses());
        }

        /// <summary>
        /// Adds telegram commands entries into database.
        /// </summary>
        private void InitializeTelegramCommands()
        {
            _telegramContext.TelegramCommands.AddRange(this.GetDefaultCommandsList());
        }

        /// <summary>
        /// Adds notification types to the database.
        /// </summary>
        private void InitializeNotificationTypes()
        {
            _telegramContext.NotificationTypes.AddRange(this.GetDefaultNotificationsList());
        }

        /// <summary>
        /// Returns list of telegram commands.
        /// </summary>
        private List<TelegramCommand> GetDefaultCommandsList()
        {
            return new List<TelegramCommand>
            {
                new TelegramCommand() { Id = (long)TelegramCommandEnum.HELP, Label = nameof(TelegramCommandEnum.HELP) },
                new TelegramCommand() { Id = (long)TelegramCommandEnum.SET_CITY, Label = nameof(TelegramCommandEnum.SET_CITY) }
            };
        }

        /// <summary>
        /// Returns list of notificationTypes.
        /// </summary>
        private List<UserNotificationType> GetDefaultNotificationsList()
        {
            return new List<UserNotificationType>
            {
                new UserNotificationType() { Id = (long)UserNotificationTypeEnum.EVERY_MORNING, Label = nameof(UserNotificationTypeEnum.EVERY_MORNING) },
                new UserNotificationType() { Id = (long)UserNotificationTypeEnum.WEATHER_BECOMES_BAD, Label = nameof(UserNotificationTypeEnum.WEATHER_BECOMES_BAD) }
            };
        }

        /// <summary>
        /// Returns list of user statuses.
        /// </summary>
        private List<UserStatus> GetDefaultStatuses()
        {
            return new List<UserStatus>
            {
                new UserStatus() { Id = (long)UserStatusEnum.ENTER_CITY_NAME, Label = nameof(UserStatusEnum.ENTER_CITY_NAME) },
            };
        }
    }
}
