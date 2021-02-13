namespace Logic.Services.Interfaces
{
    /// <summary>
    /// Represents jobs to be runed in Hangfire.
    /// </summary>
    public interface INotificationLogic
    {
        /// <summary>
        /// Hourly notification. This method has to be runed every hour.
        /// Fetch the latest weather data, depending on that and user settings sends notifications.
        /// </summary>
        void HorlyNotification();
    }
}
