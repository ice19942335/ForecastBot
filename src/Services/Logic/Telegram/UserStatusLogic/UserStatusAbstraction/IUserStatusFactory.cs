using System.Threading.Tasks;

namespace Logic.Telegram.UserStatusLogic.UserStatusAbstraction
{
    public interface IUserStatusFactory
    {
        string Name { get; set; }

        Task SomeLogic();
    }
}