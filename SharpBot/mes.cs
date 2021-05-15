using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace SharpBot
{
   public class mes
    {

        public string text;
        public ParseMode parseMode = ParseMode.Default;
        public bool disableWebPagePreview = false;
        public bool disableNotification = false;
        public int replyToMessageId = 0;
        public IReplyMarkup replyMarkup = null;
        public CancellationToken cancellationToken = default;

    }
}
