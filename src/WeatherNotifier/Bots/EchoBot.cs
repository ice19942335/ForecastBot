// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DAL.Context;
using Domain.Entries;
using Enums;
using Logic;
using Logic.Services.Interfaces;
using Logic.Telegram.CommandLogic.CommandAbstraction;
using Logic.Telegram.CommandLogic.CommandCreators;
using Logic.Telegram.UserStatusLogic.UserStatusAbstraction;
using Logic.Telegram.UserStatusLogic.UserStatusCreators;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Schema;

namespace Microsoft.BotBuilderSamples.Bots
{
    public class EchoBot : ActivityHandler
    {
        private const string CreatorsNameSpace = "Logic.Telegram.UserStatusLogic.UserStatusCreators";

        private readonly IUserLogic _userLogic;
        private readonly INotificationLogic _weatherNotifierLogic;
        private readonly TelegramContext _telegramContext;

        public EchoBot(IUserLogic userLogic, TelegramContext telegramContext, INotificationLogic weatherNotifierLogic)
        {
            _userLogic = userLogic;
            _telegramContext = telegramContext;
            _weatherNotifierLogic = weatherNotifierLogic;
        }

        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            await turnContext.SendActivityAsync(
                MessageFactory.Text(
                    typeof(UserStatusEnterCityNameCreator).AssemblyQualifiedName,
                    typeof(UserStatusEnterCityNameCreator).AssemblyQualifiedName
                ), cancellationToken);


            string text = turnContext.Activity.Text;
            var commands = _telegramContext.TelegramCommands.Select(x => x.Label).ToList();

            if (!commands.Contains(text))
            {
                User user = _userLogic.GetUserById(turnContext.Activity.From.Id);
                UserStatusFactory userStatusCreator = GetInstance(GetFullyQualifiedCreatorInstanceName(user.UserStatus.Label));

                if (userStatusCreator is null)
                    throw new ArgumentNullException(nameof(userStatusCreator));

                IUserStatusFactory userStatusFactory = userStatusCreator.FactoryMethod();
                await userStatusFactory.SomeLogic();
            }

            TelegramCommandFactory commandCreator = null;
            switch (text)
            {
                case nameof(TelegramCommandEnum.HELP):
                    commandCreator = new TelegramHelpCommandCreator(turnContext, cancellationToken);
                    break;
                case nameof(TelegramCommandEnum.SET_CITY):
                    commandCreator = new TelegramSetCityCommandCreator(turnContext, cancellationToken);
                    break;
                default: throw new ApplicationException($"Command: {text}, does not exist!");
            }

            if (commandCreator is null)
                throw new ArgumentNullException(nameof(commandCreator));

            ITelegramCommandFactory telegramCommandFactory = commandCreator.FactoryMethod();
            await telegramCommandFactory.GenerateResponse();


            await turnContext.SendActivityAsync(MessageFactory.Text("Test", "Test"), cancellationToken);
        }

        /// <summary>
        /// Gets full assembly name.
        /// </summary>
        /// <param name="assemblyName">Not fully qualified assembly name.</param>
        private string GetFullyQualifiedCreatorInstanceName(string assemblyName) => $"{CreatorsNameSpace}.UserStatus{assemblyName.Replace("_", "")}Creator";

        /// <summary>
        /// Instatiating instance by assembly name.
        /// </summary>
        /// <param name="strFullyQualifiedName">Fully qualified assembly name.</param>
        public UserStatusFactory GetInstance(string strFullyQualifiedName)
        {
            Type type = Type.GetType(strFullyQualifiedName);
            if (type != null)
                return (UserStatusFactory)Activator.CreateInstance(type);
            foreach (var asm in AppDomain.CurrentDomain.GetAssemblies())
            {
                type = asm.GetType(strFullyQualifiedName);
                if (type != null)
                    return (UserStatusFactory)Activator.CreateInstance(type);
            }
            return null;
        }

        protected override async Task OnMembersAddedAsync(IList<ChannelAccount> membersAdded, ITurnContext<IConversationUpdateActivity> turnContext, CancellationToken cancellationToken)
        {
            if (membersAdded is null)
                return;

            foreach (var member in membersAdded)
            {
                if (member.Id != turnContext.Activity.Recipient.Id)
                {
                    var welcomeText = "Hello and welcome! Please enter your city name.";
                    OperationResponse result = await _userLogic.AddNewUserAsync(member);

                    if (result.Success)
                        result = await _userLogic.SetUserStatusAsync(member, nameof(UserStatusEnum.Enter_City_Name));

                    if (result.Success != true)
                        throw new ApplicationException($"User status has not been set to: {nameof(UserStatusEnum.Enter_City_Name)}");

                    await turnContext.SendActivityAsync(MessageFactory.Text(welcomeText, welcomeText), cancellationToken);
                }
            }
        }

        //// Creates and sends an activity with suggested actions to the user. When the user
        ///// clicks one of the buttons the text value from the "CardAction" will be
        ///// displayed in the channel just as if the user entered the text. There are multiple
        ///// "ActionTypes" that may be used for different situations.
        //private static async Task SendSuggestedActionsAsync(ITurnContext turnContext, CancellationToken cancellationToken)
        //{
        //    var reply = MessageFactory.Text("What is your favorite color?");

        //    reply.SuggestedActions = new SuggestedActions()
        //    {
        //        Actions = new List<CardAction>()
        //        {
        //            new CardAction() { Title = "Red", Type = ActionTypes.ImBack, Value = "Red", Image = "https://via.placeholder.com/20/FF0000?text=R", ImageAltText = "R" },
        //            new CardAction() { Title = "Yellow", Type = ActionTypes.ImBack, Value = "Yellow", Image = "https://via.placeholder.com/20/FFFF00?text=Y", ImageAltText = "Y" },
        //            new CardAction() { Title = "Blue", Type = ActionTypes.ImBack, Value = "Blue", Image = "https://via.placeholder.com/20/0000FF?text=B", ImageAltText = "B"   },
        //        },
        //    };
        //    await turnContext.SendActivityAsync(reply, cancellationToken);
        //}
    }
}
