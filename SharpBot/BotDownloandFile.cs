using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Args;

namespace SharpBot
{
    class BotDownloandFile: TeleBot
    {

        public  async Task DownloadDocument(MessageEventArgs e)
        {
            var file = new TeleBot().Bot.GetFileAsync(e.Message.Document.FileId);
            var fileName = @"C:\Users\Roma\Desktop\d\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
            Debug.WriteLine(file.Result.FilePath);
            using (var saveImageStream = File.Open(fileName, FileMode.Create))
            {


                await new TeleBot().Bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
            }
            await new TeleBot().Bot.SendTextMessageAsync(e.Message.Chat.Id, "Document save");
        }
        public  async Task DownloadPhoto(MessageEventArgs e)
        {
            var file = bot.GetFileAsync(e.Message.Photo.LastOrDefault().FileId);
            var fileName = @"C:\Users\Roma\Desktop\d\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
            Debug.WriteLine(file.Result.FilePath);
            using (var saveImageStream = File.Open(fileName, FileMode.Create))
            {


                await bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
            }
            await bot.SendTextMessageAsync(e.Message.Chat.Id, "Image save");
        }
    }
}
