using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    interface IControler
    {
        void ReadCommand(IModel m);
        void UpdateView();
        void ShowPages(IModel m);
    }
}
