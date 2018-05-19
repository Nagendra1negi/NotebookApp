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
            PageData pd = page.Page;
            pd.id = this.NextId();
            page.Page = pd;
            this.pages.Add(page);
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

        public List<IPageable> ReadAll()
        {
            return this.pages;
        }

        private int NextId()
        {
            if(pages.Any()) {
                return pages.Max(t => t.Page.id) + 1;
            }
            else
            {
                return 1;
            }
        }
    }
}
