using System;
using Logic.Services.Interfaces;

namespace Logic.Services
{
    public class NotificationLogic : INotificationLogic
    {
        public NotificationLogic()
        {

        }

        public void HorlyNotification()
        {
            Console.WriteLine("Easy!", Environment.NewLine);
        }
    }
}
