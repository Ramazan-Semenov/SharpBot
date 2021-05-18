using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telegram.Bot.Args;
using Telegram.Bot.Types.ReplyMarkups;

namespace SharpBot
{
  public  class BotButtons
    {
        private string text = "qqqqqq";
        private int count = 4;
        public string Text { get => text; set => text = value; }
        public int Count { get => count; set => count = value; }

        public IReplyMarkup GetButtons()
        {
            return new ReplyKeyboardMarkup
            {
                Keyboard = new List<List<KeyboardButton>>
                 {
                     new List<KeyboardButton>
                     {
                        new KeyboardButton{ Text =this.text},
                        new KeyboardButton{Text =this.text}
                     }

                 }
            
            };
          
           

        }
        public InlineKeyboardMarkup send()
        {

            var KeyboardButons = new InlineKeyboardButton[][]
                  {
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Отправить", "send") ,
                  }
                  };
            return KeyboardButons;
        }
        public InlineKeyboardMarkup InlineKeyboardMarkupButtons()
        {

            var KeyboardButons = new InlineKeyboardButton[][]
                  {
                  new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("правила приёма в КубГТУ на обучение", "сш") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("перечень испытаний", "dsd") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("информация о наличие общежитий", "dsd") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("стоимость обучения", "Command_3") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("подача документов", "Command_2") ,
                  },
                   new InlineKeyboardButton[]
                  {
                     InlineKeyboardButton.WithCallbackData("Другое", "Command_1") ,
                  }
                  };
            return KeyboardButons;
        }
        //public  InlineKeyboardMarkup InlineKeyboardMarkupButtons()
        //{
        //    return new InlineKeyboardMarkup(new[]
        //   {
        //            new []
        //            {
        //                InlineKeyboardButton.WithCallbackData("Одноразовые товары", "Command_1"),
        //                InlineKeyboardButton.WithCallbackData("Многоразовые товары","Command_2"),
        //            }
        //        });
        //}
    }
}
