using Telegram.Bot;

namespace SharpBot
{
    public class TeleBot
    {

        private static readonly string token = "1833119055:AAFk3L81Z4lHybJo54uusZWCBX2a6D6z2hI";
        protected static TelegramBotClient bot = new TelegramBotClient(token: token);

        public TelegramBotClient Bot { get => bot; set => bot = value; }

        //public TeleBot()
        //{

        //    bot = new TelegramBotClient(token);
        //}

        //public TeleBot(string token)
        //{

        //    bot = new TelegramBotClient(token);
        //}
    }
}
