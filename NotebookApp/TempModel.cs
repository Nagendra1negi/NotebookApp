using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class TempModel : IModel
    {
        List<IPageable> pages = new List<IPageable>();

        public void Create(IPageable page)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            pages.RemoveAt(id);
        }

        public void Delete(IPageable page)
        {
            pages.Remove(page);
        }

        public void DeleteAll()
        {
            pages.Clear();
        }

        public IPageable Read(int id)
        {
            return pages[id];
        }
    }
}
