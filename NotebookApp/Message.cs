using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{

    class Message : IPageable
    {
        private PageData _pd;
        private string _message;

        public PageData Page { get => _pd; set => _pd = value; }

        public void Input(IPageable p)
        {
            throw new NotImplementedException();
        }

        public IPageable Output(int id)
        {
            throw new NotImplementedException();
        }

        public void InputMessage(string m)
        {
            _message = m;
        }
    }
}
