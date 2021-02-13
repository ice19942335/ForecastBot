using System.Threading;
using System.Threading.Tasks;
using Logic.Telegram.CommandLogic.CommandAbstraction;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace Logic.Telegram.CommandLogic.Command
{
    public class TelegramSetCityCommand : ITelegramCommandFactory
    {
        private readonly ITurnContext<IMessageActivity> _turnContext;
        private readonly CancellationToken _cancellationToken;

        public TelegramSetCityCommand(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            _turnContext = turnContext;
            _cancellationToken = cancellationToken;
        }

        public string Name { get; set; }

        public async Task GenerateResponse()
        {
            await _turnContext.SendActivityAsync(MessageFactory.Text("This is a /SetCity command"), _cancellationToken);
        }
    }
}
