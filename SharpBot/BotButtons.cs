﻿using System;
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

        public  InlineKeyboardMarkup InlineKeyboardMarkupButtons()
        {
            return new InlineKeyboardMarkup(new[]
           {
                    new []
                    {
                        InlineKeyboardButton.WithCallbackData("Одноразовые товары", "Command_1"),
                        InlineKeyboardButton.WithCallbackData("Многоразовые товары","Command_2"),
                    }
                });
        }
    }
}