using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class ListPage : IPageable
    {
        PageData pd;
        Bullets bulletType;
        string[] item;

        public PageData Page { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
