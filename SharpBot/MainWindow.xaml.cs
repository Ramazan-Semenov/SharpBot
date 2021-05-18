using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace SharpBot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static ObservableCollection<BotUser> Users;
        private static ObservableCollection<UserEmail>  userEmails;
        static bool ff = false;

        private static ObservableCollection<Questions> questions;
        private static ObservableCollection<Questions> command_1;


        string gg = @"Добро пожаловать в КубГТУ! Абитуриентам мы особо рады, поможем определиться с выбором, расскажем про все этапы подачи документов.
И самое главное, не нужно никуда ехать, документы на рассмотрение можно прислать сюда, а далее после проверки, специалист приемной комиссии свяжемся с Вами для согласования дальнейших действий 😇 Всё просто)";

        TeleBot bot = new TeleBot();
        public MainWindow()
        {            
            InitializeComponent();
            Users = new ObservableCollection<BotUser>();
            questions = new ObservableCollection<Questions>();
            userEmails = new ObservableCollection<UserEmail>();
            userList.ItemsSource = userEmails;
            questions.Add(new Questions { ID = 1, Text = "fffff" });
            questions.Add(new Questions { ID = 2, Text = "222" });
            questions.Add(new Questions { ID = 3, Text = "333" });
            questions.Add(new Questions {ID=4, Text = gg+"\nВ чём вопрос?", replyMarkup =  (IReplyMarkup)new BotButtons().InlineKeyboardMarkupButtons() });
            questions.Add(new Questions { ID = 5, Text = "rrrr", replyMarkup = new ReplyKeyboardRemove() });
            questions.Add(new Questions { ID = 5, Text = "rrrr", replyMarkup = new ReplyKeyboardRemove() });
            questions.Add(new Questions { ID = 5, Text = "ggg", replyMarkup = new ReplyKeyboardRemove() });

            questions.Add(new Questions {ID=5, Text = "Конец", replyMarkup = new ReplyKeyboardRemove() });


            bot.Bot.OnMessage += OnMessageHandler;
            bot.Bot.OnCallbackQuery += OnInlineQueryHandler;
            bot.Bot.StartReceiving();

            
        }
        private async void OnInlineQueryHandler(object sender, CallbackQueryEventArgs e)
        {
            if (e.CallbackQuery.Data == "Command_1")
            {
                ff = true;
                questions = new ObservableCollection<Questions>();
                command_1 = new ObservableCollection<Questions>();


                command_1.Add(new Questions { ID = 1, Text = "фио" });
                command_1.Add(new Questions { ID = 2, Text = "номер телефона" });
                command_1.Add(new Questions { ID = 3, Text = "направление" ,replyMarkup= new BotButtons().send ()});
                questions = command_1;
                new MessageClient(Users, questions,read: ff, userEmails).GenMessage(e);


            }
            else if (e.CallbackQuery.Data == "send")
            {
                await bot.Bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Отправлено");
            }
            else if (e.CallbackQuery.Data == "Command_3")
            {
                questions = new ObservableCollection<Questions>();
                new MessageClient(Users, questions).GenMessage(e);
                //   await bot.Bot.SendTextMessageAsync(e.CallbackQuery.Message.Chat.Id, "Command_2");
            }

        }

        /// <summary>
        /// Событие на получение сообщений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Получения клиента и его данных из сообщения</param>
        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {

            //MessageBox.Show(e.Message.Type.ToString());
            if (e.Message.Type == MessageType.Text)
            {
                new MessageClient(Users,questions, ff, userEmails).GenMessage(e);

            }
            else if (e.Message.Type == MessageType.Photo)
            {
              await new MessageClient(Users,questions).DownloadPhoto(e);
            }
            else if (e.Message.Type == MessageType.Document)
            {
                await new MessageClient(Users, questions).DownloadDocument(e);
            }


        }
    }
}
