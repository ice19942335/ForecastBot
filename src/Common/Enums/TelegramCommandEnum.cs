namespace Enums
{
    /// <summary>
    /// Represents TelegramCommand entries from MSSQL.
    /// </summary>
    public enum TelegramCommandEnum
    {
        /// <summary>
        /// Command that show all possible commands and instructions.
        /// ID - 1
        /// </summary>
        HELP = 1,

        /// <summary>
        /// Command that saves city name and run logic afterwards.
        /// ID - 2
        /// </summary>
        SET_CITY = 2
    }
}
