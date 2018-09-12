using System;
using Microsoft.Bot;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Builder.Prompts;

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
	}
}
