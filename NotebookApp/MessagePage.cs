using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{

    class MessagePage : IPageable
    {
        private PageData _pd;
        private string _message;

        public MessagePage()
        {

        }

        public MessagePage(int id, string author, string title, string message)
        {
            _message = message;
            _pd.id = id;
            _pd.author = author;
            _pd.title = title;
        }

        public PageData Page { get => _pd; set => _pd = value; }
        public string GetMessage { get => _message; }

        public void InputMessage(string m)
        {
            _message = m;
        }
    }
}
