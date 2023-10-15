using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace TelegramPetanque
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var botClient = new TelegramBotClient("6521171506:AAGndVsfgamqdgjb3pZrbl5OjDiCACrLnuw");
            using CancellationTokenSource cts = new();
            // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
            ReceiverOptions receiverOptions = new()
            {
                AllowedUpdates = Array.Empty<UpdateType>() // receive all update types except ChatMember related updates
            };

            botClient.StartReceiving(
                updateHandler: StartActionHandling.HandleUpdateAsync,
                pollingErrorHandler: StartActionHandling.HandlePollingErrorAsync,
                receiverOptions: receiverOptions,
                cancellationToken: cts.Token
            );

            var me = botClient.GetMeAsync().Result;

            Console.WriteLine($"123 Start listening for @{me.Username}");
            Console.ReadLine();

            // Send cancellation request to stop bot
            cts.Cancel();
        }           
    }
}