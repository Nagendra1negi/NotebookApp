using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class TempModel : IModel
    {
        List<object> objs = new List<object>();

        public void Create(object obj)
        {
            objs.Add(obj);
        }

        public void Delete(int id)
        {
            objs.RemoveAt(id);
        }

        public void Delete(object obj)
        {
            objs.Remove(obj);
        }

        public void DeleteAll()
        {
            objs.Clear();
        }

        public object Read(int id)
        {
            return objs[id];
        }
    }
}
