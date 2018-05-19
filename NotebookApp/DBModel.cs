using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class DBModel : IModel
    {
        public void Create(IPageable page)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Delete(IPageable page)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            throw new NotImplementedException();
        }

        public IPageable Read(int id)
        {
            throw new NotImplementedException();
        }

        public List<IPageable> ReadAll()
        {
            throw new NotImplementedException();
        }
    }
}
