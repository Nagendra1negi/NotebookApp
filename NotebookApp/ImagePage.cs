using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    public struct ImageData
    {
        int lineNumber;
        string lineText;
    }

    class ImagePage : IPageable
    {
        public PageData Page { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
