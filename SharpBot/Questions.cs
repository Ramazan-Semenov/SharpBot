using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpBot
{
    class Questions
    {
        private int id;
        public int ID
        {
            get => id;
            set => id = value;
        }

        private string text;
        public string Text
        {
            get => text;
            set => text = value;
        }
    }
}
