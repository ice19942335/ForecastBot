using Domain.Cron;
using Hangfire;
using Logic.Services.Interfaces;

namespace Logic.Services
{
    public class HangFireJobInitializer : IHangFireJobInitializer
    {
        private readonly INotificationLogic _notificationLogic;

        public HangFireJobInitializer(INotificationLogic notificationLogic)
        {
            _notificationLogic = notificationLogic;
        }

        public void InitializeAsync()
        {
            RecurringJob.AddOrUpdate(() => _notificationLogic.HorlyNotification(), CronExpressions.EveryMinute);
        }
    }
}
