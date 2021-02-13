using System.Threading;
using Logic.Telegram.CommandLogic.Command;
using Logic.Telegram.CommandLogic.CommandAbstraction;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace Logic.Telegram.CommandLogic.CommandCreators
{

    public class TelegramSetCityCommandCreator : TelegramCommandFactory
    {
        private readonly ITurnContext<IMessageActivity> _turnContext;
        private readonly CancellationToken _cancellationToken;

        public TelegramSetCityCommandCreator(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            _turnContext = turnContext;
            _cancellationToken = cancellationToken;
        }

        public override ITelegramCommandFactory FactoryMethod()
        {
            return new TelegramSetCityCommand(_turnContext, _cancellationToken)
            {
                Name = nameof(TelegramSetCityCommand)
            };
        }
    }
}
