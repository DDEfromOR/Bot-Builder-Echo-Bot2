using System;
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
	}
}
