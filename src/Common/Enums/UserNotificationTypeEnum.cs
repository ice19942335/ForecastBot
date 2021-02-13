namespace Enums
{
    /// <summary>
    /// Represent NotificationType etries from MSSQL.
    /// </summary>
    public enum UserNotificationTypeEnum
    {
        /// <summary>
        /// Notify every morning.
        /// ID - 1
        /// </summary>
        EVERY_MORNING = 1,

        /// <summary>
        /// Notify every morning AND on rain/snow.
        /// ID - 2
        /// </summary>
        WEATHER_BECOMES_BAD = 2
    }
}
