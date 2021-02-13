using Logic.Telegram.UserStatusLogic.UserStatus;
using Logic.Telegram.UserStatusLogic.UserStatusAbstraction;

namespace Logic.Telegram.UserStatusLogic.UserStatusCreators
{
    public class UserStatusEnterCityNameCreator : UserStatusFactory
    {
        public override IUserStatusFactory FactoryMethod()
        {
            return new UserStatusEnterCityName();
        }
    }
}