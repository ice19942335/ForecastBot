using System;
using System.Threading.Tasks;
using Logic.Telegram.UserStatusLogic.UserStatusAbstraction;

namespace Logic.Telegram.UserStatusLogic.UserStatus
{
    public class UserStatusEnterCityName : IUserStatusFactory
    {
        public string Name { get; set; }

        public Task SomeLogic()
        {
            throw new NotImplementedException();
        }
    }
}