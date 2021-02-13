using Domain.Entries;
using Microsoft.EntityFrameworkCore;

namespace DAL.Context
{
    /// <summary>
    /// Telegram database context.
    /// </summary>
    public class TelegramContext : DbContext
    {
        /// <summary>
        /// Telegram database context.
        /// </summary>
        public TelegramContext(DbContextOptions<TelegramContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<UserNotificationType> NotificationTypes { get; set; }
        public DbSet<TelegramCommand> TelegramCommands { get; set; }
        public DbSet<UserStatus> UserStatuses { get; set; }

        /// <summary>
        /// EF Core fluent API 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

