using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    public interface IModel
    {
        void Create(IPageable page);
        void Delete(int id);
        void Delete(IPageable page);
        void DeleteAll();
        IPageable Read(int id);
        List<IPageable> ReadAll();
        
    }
}
