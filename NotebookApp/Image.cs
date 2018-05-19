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

    class Image : IPageable
    {
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
