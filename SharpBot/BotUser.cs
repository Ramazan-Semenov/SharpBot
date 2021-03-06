using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace SharpBot
{
    public class BotUser : INotifyPropertyChanged, IEquatable<BotUser>
    {

        public BotUser(string NikeName, long ChatId)
        {
            id = ChatId;
            nike = NikeName;

            Messages = new ObservableCollection<string>();
        }

        private int count = 0;

        public int Сount
        {
            get => count;
            set => count = value;
        }
        private long id;

        public long ID
        {
            get => this.id;
            set  
            {
                this.id = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.ID)));
            }


        }

        private string nike;

        public event PropertyChangedEventHandler PropertyChanged;

        public string Nike
        {
            get => nike;
            set
            {
                nike = value;

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Nike)));

            }
        }

        public bool Equals(BotUser other)
        {
            return other.ID == id;
        }

        public ObservableCollection<string> Messages { get; set; }

        public void AddMessage(string Text)
        {
            Messages.Add(Text);
        }
    }
}
