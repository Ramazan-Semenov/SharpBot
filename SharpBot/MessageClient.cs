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

namespace SharpBot
{
   public class MessageClient : TeleBot
    {


        private ObservableCollection<BotUser> Users;
        private ObservableCollection<Questions> mes;
       public static bool Read;
        ObservableCollection<UserEmail> userEmails;
        private StepQuestionsClass StepQuestions;
        public MessageClient(ObservableCollection<BotUser> Users, ObservableCollection<Questions> mes, bool read=false, ObservableCollection<UserEmail> userEmails=null)
        {
            this.Users = Users;
            this.mes = mes;
            Read = read;
            this.userEmails = userEmails;
            StepQuestions = new StepQuestionsClass(Users, mes);
        }

        public void GenMessage(MessageEventArgs e)
        {

            string msg = $"{DateTime.Now}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";

            File.AppendAllText("data.log", $"{msg}\n");

            Debug.WriteLine(msg);
            Application.Current.Dispatcher.Invoke(() =>
            {
                NewUser(e);

            });
        }
        public async Task DownloadDocument(MessageEventArgs e)
        {
            try
            {
                NewUser(e);
                var person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id);

                var file = new TeleBot().Bot.GetFileAsync(e.Message.Document.FileId);
                var fileName = @"C:\Users\Roma\Desktop\d\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
                Debug.WriteLine(file.Result.FilePath);
                using (var saveImageStream = File.Open(fileName, FileMode.Create))
                {


                    await new TeleBot().Bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
                }
                await new TeleBot().Bot.SendTextMessageAsync(e.Message.Chat.Id, "Document save");
                await new TeleBot().Bot.SendTextMessageAsync(Users[Users.IndexOf(person)].ID, mes[Users[Users.IndexOf(person)].Сount].Text, replyMarkup: mes[Users[Users.IndexOf(person)].Сount].replyMarkup);

                Users[Users.IndexOf(person)].Сount++;
            }
            catch { }

        }
        public async Task DownloadPhoto(MessageEventArgs e)
        {
            try
            {
                var person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id);

                var file = bot.GetFileAsync(e.Message.Photo.LastOrDefault().FileId);
                var fileName = @"C:\Users\Roma\Desktop\d\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
                Debug.WriteLine(file.Result.FilePath);
                using (var saveImageStream = File.Open(fileName, FileMode.Create))
                {


                    await bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
                }
                await bot.SendTextMessageAsync(e.Message.Chat.Id, "Image save");
                await new TeleBot().Bot.SendTextMessageAsync(Users[Users.IndexOf(person)].ID, mes[Users[Users.IndexOf(person)].Сount].Text, replyMarkup: mes[Users[Users.IndexOf(person)].Сount].replyMarkup);

                Users[Users.IndexOf(person)].Сount++;
            }
            catch { }
        }
        private void NewUser(MessageEventArgs e)
        {
           
            var person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id);
            if (!Users.Contains(person))
            {
                Users.Add(person);
            }
            Users[Users.IndexOf(person)].AddMessage($"{person.Nike}: {e.Message.Text}");
           // MessageBox.Show(Read.ToString());
            if (Read == true)
            {

                var person_email = new UserEmail(e.Message.Chat.FirstName, e.Message.Chat.Id);

                if (!userEmails.Contains(person_email))
                {

                    userEmails.Add(person_email);
                }
                userEmails[userEmails.IndexOf(person_email)].AddMessage($"{person.Nike}: {e.Message.Text}");
                MessageBox.Show("dfdfdf");
            }

            StepQuestions.StepQuestions(person);
        }
        /// ///////////////////////////////////////////////////////////////////////

        public async Task DownloadDocument(CallbackQueryEventArgs e)
        {
            try
            {
                NewUser(e);
                var person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id);

                var file = new TeleBot().Bot.GetFileAsync(e.CallbackQuery.Message.Document.FileId);
                var fileName = @"C:\Users\Roma\Desktop\d\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
                Debug.WriteLine(file.Result.FilePath);
                using (var saveImageStream = File.Open(fileName, FileMode.Create))
                {


                    await new TeleBot().Bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
                }
                await new TeleBot().Bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Document save");
                await new TeleBot().Bot.SendTextMessageAsync(Users[Users.IndexOf(person)].ID, mes[Users[Users.IndexOf(person)].Сount].Text, replyMarkup: mes[Users[Users.IndexOf(person)].Сount].replyMarkup);

                Users[Users.IndexOf(person)].Сount++;
            }
            catch { }

        }
        public async Task DownloadPhoto(CallbackQueryEventArgs e)
        {
            try
            {
                ////newuser(e)
                var person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id);

                var file = bot.GetFileAsync(e.CallbackQuery.Message.Photo.LastOrDefault().FileId);
                var fileName = @"C:\Users\Roma\Desktop\d\" + file.Result.FileId + "." + file.Result.FilePath.Split('.').Last();
                Debug.WriteLine(file.Result.FilePath);
                using (var saveImageStream = File.Open(fileName, FileMode.Create))
                {


                    await bot.DownloadFileAsync(file.Result.FilePath, saveImageStream);
                }
                await bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Image save");
                await new TeleBot().Bot.SendTextMessageAsync(Users[Users.IndexOf(person)].ID, mes[Users[Users.IndexOf(person)].Сount].Text, replyMarkup: mes[Users[Users.IndexOf(person)].Сount].replyMarkup);

                Users[Users.IndexOf(person)].Сount++;
            }
            catch { }
        }
        private void NewUser(CallbackQueryEventArgs e)
        {
            try
            {
                
                var person = new BotUser(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id);
                if (!Users.Contains(person))
                {
                    Users.Add(person);
                }
                Users[Users.IndexOf(person)].AddMessage($"{person.Nike}: {e.CallbackQuery.Message.Text}");
                //StepQuestions.StepQuestions(person);
                if(Read == true)
                {
                    var person_email = new UserEmail(e.CallbackQuery.Message.Chat.FirstName, e.CallbackQuery.Message.Chat.Id);

                    if (!userEmails.Contains(person_email))
                    {
                        userEmails.Add(person_email);
                    }
                    userEmails[userEmails.IndexOf(person_email)].AddMessage($"{person.Nike}: {e.CallbackQuery.Message.Text}");
                    MessageBox.Show("Work!!");
                }
                StepQuestions.StepQuestions(person);
            }
            catch { }
        }
        public void GenMessage(CallbackQueryEventArgs e)
        {
            string msg = $"{DateTime.Now}: {e.CallbackQuery.Message.Chat.FirstName} {e.CallbackQuery.Message.Chat.Id} {e.CallbackQuery.Message.Text}";

            File.AppendAllText("data.log", $"{msg}\n");

            Debug.WriteLine(msg);
            Application.Current.Dispatcher.Invoke(() =>
            {
                NewUser(e);

            });
        }


    }
}
