using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    public interface IModel
    {
        void Create(object obj);
        void Delete(int id);
        void Delete(object obj);
        void DeleteAll();
        object Read(int id);
        
    }
}
