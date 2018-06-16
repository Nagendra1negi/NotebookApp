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
        PageData Page { get; set; }
    }
}
