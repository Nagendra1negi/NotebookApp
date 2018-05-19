using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    public struct PageData
    {
        public string title, author;
        public int id;
    }

    public interface IPageable
    {
        void Input(IPageable p);
        IPageable Output(int id);
        PageData Page { get; set; }
    }
}
