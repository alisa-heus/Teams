using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Types;
using Telegram.Bot;
using EntityFW.Strategies;
using EntityFW;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace TelegramPetanque
{
    public static class StartActionHandling
    {
        public static async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            // Only process Message updates: https://core.telegram.org/bots/api#message
            /* if (update.Message is not { } message)
                return;
            // Only process text messages
            if (message.Text is not { } messageText)
                return;

            var chatId = message.Chat.Id;

            Console.WriteLine($"Received a '{messageText}' message in chat {chatId}.");

            // Echo received message text
            Message sentMessage = await botClient.SendTextMessageAsync(
                chatId: chatId,
                text: "You said:\n" + messageText,
                cancellationToken: cancellationToken);*/
            var message = update.Message;
            if(message == null)
            {
                return;
            }
            if (message.Text != null)
            {
                var response = RunGameStrategies(message.Text);
                await botClient.SendTextMessageAsync(message.Chat.Id, response);
                return;
            }
            if (message.Text != null)
            {
                Console.WriteLine(message.From.Username + ": " + message.Text);
                if(message.Text.Contains("Hello", StringComparison.OrdinalIgnoreCase))
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, "Happy to see you here <3");
                }
                else
                {
                    await botClient.SendTextMessageAsync(message.Chat.Id, $"{message.Text} to you too.");
                }
            }

            if(message.Photo != null)
            {
                Console.WriteLine($"{message.From.Username} sent a picture.");
                await botClient.SendTextMessageAsync(message.Chat.Id, "It's a picture. Can you send it as a file instead?");
            }
            if(message.Document != null)
            {
                Console.WriteLine($"{message.From.Username} sent a file.");
                await botClient.SendTextMessageAsync(message.Chat.Id, "It's a file. Cool");

                var fileId = update.Message.Document.FileId;
                var fileInfo = await botClient.GetFileAsync(fileId);
                var filePath = fileInfo.FilePath;

                string destinationFilePath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\BotTest\ {message.From.Username}_{message.Document.FileName}";
                using var imageSaver = new FileStream(destinationFilePath, FileMode.Create);
                await botClient.DownloadFileAsync(filePath, imageSaver);
            }
        }

        public static Task HandlePollingErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
            var ErrorMessage = exception switch
            {
                ApiRequestException apiRequestException
                    => $"Telegram API Error:\n[{apiRequestException.ErrorCode}]\n{apiRequestException.Message}",
                _ => exception.ToString()
            };

            Console.WriteLine(ErrorMessage);
            return Task.CompletedTask;
        }

        public static string RunGameStrategies(string userMessage)
        {
            if(userMessage == null)
            {
                return "";
            }
            using (var context = new TeamsRegistrationDbContext())
            {
                string[] userParams = userMessage.Split(' ');
                IDialogStrategy strategy = Strategy.ChooseStrategy(userParams[0]);
                string parameter = "";
                if(userParams.Length > 1) {
                    parameter = userParams[1];
                }
                var response = strategy.Handle(context, parameter);

                return response;
            }
        }
    }
}

