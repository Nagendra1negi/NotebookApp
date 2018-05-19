using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class FileModel : IModel
    {
        string _path = @"../Files/Pages.txt";
        StreamWriter _sw;
        List<int>;

        public FileModel()
        {
            if (!File.Exists(_path))
            {
                _sw = new StreamWriter(File.Create(_path));
            }
        }

        public void Create(IPageable page)
        {
            _sw.WriteLine($"Id:{}");
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
