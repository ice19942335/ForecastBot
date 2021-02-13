using System.Threading;
using Logic.Telegram.CommandLogic.Command;
using Logic.Telegram.CommandLogic.CommandAbstraction;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace Logic.Telegram.CommandLogic.CommandCreators
{
    public class TelegramHelpCommandCreator : TelegramCommandFactory
    {
        private readonly ITurnContext<IMessageActivity> _turnContext;
        private readonly CancellationToken _cancellationToken;

        public TelegramHelpCommandCreator(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            _turnContext = turnContext;
            _cancellationToken = cancellationToken;
        }

        public override ITelegramCommandFactory FactoryMethod()
        {
            return new TelegramHelpCommand(_turnContext, _cancellationToken)
            {
                Name = nameof(TelegramHelpCommand)
            };
        }
    }
}
