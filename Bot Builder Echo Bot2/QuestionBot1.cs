using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot;
using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Core.Extensions;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Prompts;
using Microsoft.Bot.Schema;

/// <summary>
/// A simple question bot built off of the online tutorial found at:
/// https://docs.microsoft.com/en-us/azure/bot-service/bot-builder-tutorial-waterfall?view=azure-bot-service-4.0&tabs=cstab
/// </summary>
public class QuestionBot1 : IBot
{
    private readonly DialogSet dialogs;
    public QuestionBot1()
	{
        dialogs = new DialogSet();
        dialogs.Add("greetings", new WaterfallStep[]
        {
            async (dc, args, next) =>
            {
                await dc.Prompt("textPrompt", "What is your name?");
            },
            async (dc, args, next) =>
            {
                await dc.Context.SendActivity($"Hi {args["Text"]}!");
                await dc.End();
            }
        });
        dialogs.Add("textPrompt", new Microsoft.Bot.Builder.Dialogs.TextPrompt());
	}

    public async Task OnTurn(ITurnContext context)
    {
        var state = ConversationState<Dictionary<string, object>>.Get(context);
        var dc = dialogs.CreateContext(context, state);
        if (context.Activity.Type == ActivityTypes.Message)
        {
            await dc.Continue();

            if (!context.Responded)
            {
                await dc.Begin("greetings");
            }
        }
    }
}
