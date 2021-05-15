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
    class StepQuestionsClass:TeleBot
    {
        private  ObservableCollection<BotUser> Users;
        private  ObservableCollection<Questions> questions;
        private ObservableCollection<mes> mes;
        private BotButtons Buttons=new BotButtons();
        string gg = @"Добро пожаловать в КубГТУ! Абитуриентам мы особо рады, поможем определиться с выбором, расскажем про все этапы подачи документов.
И самое главное, не нужно никуда ехать, документы на рассмотрение можно прислать сюда, а далее после проверки, специалист приемной комиссии свяжемся с Вами для согласования дальнейших действий 😇 Всё просто)";
        public StepQuestionsClass(ObservableCollection<BotUser> Users, ObservableCollection<Questions> questions)
        {
            this.Users = Users;
            this.questions = questions;
            mes = new ObservableCollection<mes>();
            mes.Add(new mes { text=gg});
            mes.Add(new mes { text = "В чём вопрос?", replyMarkup = (IReplyMarkup)new BotButtons().rrrrr() });

            mes.Add(new mes { text = "Конец",replyMarkup=new ReplyKeyboardRemove() });
        }

        /// <summary>
        /// переход к следующему сообщению
        /// </summary>
        /// <param name = "person" > Клиент, котором</ param >
        public  void StepQuestions(BotUser person)
        {
            try
            {


                new TeleBot().Bot.SendTextMessageAsync(Users[Users.IndexOf(person)].ID, mes[Users[Users.IndexOf(person)].Сount].text, replyMarkup: mes[Users[Users.IndexOf(person)].Сount].replyMarkup);
                   Users[Users.IndexOf(person)].Сount++;
                // Bot.DeleteWebhookAsync();
                //if (mes.Count > Users[Users.IndexOf(person)].Сount)
                //{
                //    if (Users[Users.IndexOf(person)].Сount==2)
                //    {

                //    //    new TeleBot().Bot.ed

                //        new TeleBot().Bot.SendTextMessageAsync(Users[Users.IndexOf(person)].ID, mes[Users[Users.IndexOf(person)].Сount].text/*, replyMarkup: Buttons.GetButtons()*/);
                //        Users[Users.IndexOf(person)].Сount++;
                //    }
                //    else
                //    {
                //       // var ff = new ReplyKeyboardRemove();


                //        new TeleBot().Bot.SendTextMessageAsync(Users[Users.IndexOf(person)].ID, questions[Users[Users.IndexOf(person)].Сount].Text);
                //        Users[Users.IndexOf(person)].Сount++;

                //    }

                //}
                //else
                //{

                //    new TeleBot().Bot.SendTextMessageAsync(new mes().chatId,new mes().text="sd");
                //}
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                File.AppendAllText("data.log", $"{e.Message}\n");
            }
        }

    }
}
