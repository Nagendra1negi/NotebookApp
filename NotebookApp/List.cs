using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class List : IPageable
    {
        PageData pd;
        Bullets bulletType;
        string[] item;

        public PageData Page { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Input(IPageable p)
        {
            throw new NotImplementedException();
        }

        public IPageable Output(int id)
        {
            throw new NotImplementedException();
        }
    }
}
