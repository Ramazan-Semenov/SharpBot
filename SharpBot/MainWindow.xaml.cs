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
        private static ObservableCollection<Questions> questions;
        TeleBot bot = new TeleBot();
        public MainWindow()
        {            InitializeComponent();


            Users = new ObservableCollection<BotUser>();
            questions = new ObservableCollection<Questions>();
            userList.ItemsSource = Users;
            questions.Add(new Questions { ID = 1, Text = "111" });
            questions.Add(new Questions { ID = 2, Text = "222" });
            questions.Add(new Questions { ID = 3, Text = "333" });
            bot.Bot.OnMessage += OnMessageHandler;
            bot.Bot.OnInlineQuery += OnInlineQueryHandler;
            bot.Bot.StartReceiving();

            
        }
        private void OnInlineQueryHandler(object sender, InlineQueryEventArgs e)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Событие на получение сообщений
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e">Получения клиента и его данных из сообщения</param>
        private static async void OnMessageHandler(object sender, MessageEventArgs e)
        {
           
            if (e.Message.Type == MessageType.Text)
            {
                new MessageClient(Users,questions).GenMessage(e);

            }
            else if (e.Message.Type == MessageType.Photo)
            {
                await new BotDownloandFile().DownloadPhoto(e);
            }
            else if (e.Message.Type == MessageType.Document)
            {
                await new BotDownloandFile().DownloadDocument(e);
            }


        }
    }
}
