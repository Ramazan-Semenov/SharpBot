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
   public class MessageClient
    {


        private ObservableCollection<BotUser> Users;
        private ObservableCollection<Questions> questions;

        private StepQuestionsClass StepQuestions;
        public MessageClient(ObservableCollection<BotUser> Users, ObservableCollection<Questions> questions)
        {
            this.Users = Users;
            this.questions = questions;
            StepQuestions = new StepQuestionsClass(Users,questions);
        }

        public void GenMessage(MessageEventArgs e)
        {
            string msg = $"{DateTime.Now}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";

            File.AppendAllText("data.log", $"{msg}\n");

            Debug.WriteLine(msg);
            Application.Current.Dispatcher.Invoke(() =>
            {

                var person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id);
                if (!Users.Contains(person))
                {
                    Users.Add(person);
                }
                Users[Users.IndexOf(person)].AddMessage($"{person.Nike}: {e.Message.Text}");
                StepQuestions.StepQuestions(person);

            });
        }
    }
}
