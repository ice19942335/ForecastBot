using System.Threading.Tasks;

namespace Logic.Telegram.CommandLogic.CommandAbstraction
{
    public interface ITelegramCommandFactory
    {
        string Name { get; set; }

        Task GenerateResponse();
    }
}
