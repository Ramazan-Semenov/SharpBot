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

namespace SharpBot
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private static ObservableCollection<BotUser> Users;
        private static ObservableCollection<Questions> questions;
        private static readonly string token = "1833119055:AAFk3L81Z4lHybJo54uusZWCBX2a6D6z2hI";
        private static TelegramBotClient client;

        public MainWindow()
        {
            InitializeComponent();


            Users = new ObservableCollection<BotUser>();
            questions = new ObservableCollection<Questions>();
            userList.ItemsSource = Users;
            questions.Add(new Questions { ID = 1, Text = "111" });
            questions.Add(new Questions { ID = 2, Text = "222" });
            questions.Add(new Questions { ID = 3, Text = "333" });
            client = new TelegramBotClient(token);
            //client.StartReceiving();
            client.OnMessage += OnMessageHandler;
            //delegate (object sender, MessageEventArgs e)
            //{
            //    string msg = $"{DateTime.Now}: {e.Message.Chat.FirstName} {e.Message.Chat.Id} {e.Message.Text}";

            //    File.AppendAllText("data.log", $"{msg}\n");
            //    Debug.WriteLine(msg);


            //    this.Dispatcher.Invoke(() =>
            //    {
            //        var person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id);
            //        if (!Users.Contains(person))
            //        {
            //            Users.Add(person);
            //        }
            //        Users[Users.IndexOf(person)].AddMessage($"{person.Nike}: {e.Message.Text}");


            //    });

            //};
            //btnSendMsg.Click += delegate { SendMsg(); };
        
            client.StartReceiving();

            //txtSendMsg.KeyDown += (s, e) => { if (e.Key == Key.Return) { SendMsg(); } };
        }

        //public void SendMsg()
        //{
        //    var concreteUser = Users[Users.IndexOf(userList.SelectedItem as BotUser)];
        //    string responseMsg = $"Bot: {txtSendMsg.Text}";
        //    concreteUser.Messages.Add(responseMsg);
        //    client.SendTextMessageAsync(concreteUser.ID,txtSendMsg.Text);

        //    txtSendMsg.Text = string.Empty;
        //}
        private static void OnMessageHandler(object sender, MessageEventArgs e)
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
                    NewMethod(person);

                });




            //BotUser person = new BotUser(e.Message.Chat.FirstName, e.Message.Chat.Id);

            //if (!Users.Contains(person))
            //{
            //    Users.Add(person);
            //}
            //Console.WriteLine(msg);
            //Users[Users.IndexOf(person)].AddMessage($"{person.Nike}: {e.Message.Text}");

            //NewMethod(person);

            //Debug.WriteLine(Users[Users.IndexOf(person)].Сount);

        }
        /// <summary>
        /// Отравка сообщения
        /// </summary>
        /// <param name = "person" ></ param >
        private static void NewMethod(BotUser person)
        {
            //доделать
            try
            {
                if (questions.Count > Users[Users.IndexOf(person)].Сount)
                {

                    client.SendTextMessageAsync(Users[Users.IndexOf(person)].ID, questions[Users[Users.IndexOf(person)].Сount].Text);
                    Users[Users.IndexOf(person)].Сount++;
                }
                else
                {

                    client.SendTextMessageAsync(Users[Users.IndexOf(person)].ID, "Конец");

                }
            }catch(Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
