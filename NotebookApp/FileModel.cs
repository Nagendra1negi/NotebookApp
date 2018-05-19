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
        string _filePagesPath = @"../Files/Pages.txt";
        string _fileIdPath = @"../Files/NextId.txt";
        string _filesDir = @"../Files";
        int _nextId = 1;
        StreamWriter _sw;

        public FileModel()
        {
            if (!Directory.Exists(_filesDir))
            {
                Directory.CreateDirectory(_filesDir);
            }
            if (!File.Exists(_filePagesPath))
            {
                File.Create(_filePagesPath);
            }
            if (!File.Exists(_fileIdPath))
            {
                using (StreamWriter sw = File.CreateText(_fileIdPath))
                {
                    sw.WriteLine(_nextId);
                }
            }
            else
            {
                StreamReader sr = new StreamReader(_fileIdPath);
                _nextId = int.Parse(sr.ReadLine());
                sr.Close();
            }
        }

        public void Create(IPageable page)
        {
            _sw = new StreamWriter(_filePagesPath, append: true);
            _sw.WriteLine("<Page>");
            _sw.WriteLine($"<Id>{_nextId}</Id>");
            _sw.WriteLine($"<Author>{page.Page.author}</Author>");
            _sw.WriteLine($"<Title>{page.Page.title}</Title>");
            if (page is Message pm)
            {
                _sw.WriteLine($"<Message>{pm.GetMessage}</Message>");
            }
            _sw.WriteLine($"</Page>");
            _sw.Flush();
            _sw.Close();
            IncrementId();

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
        
        private void IncrementId()
        {
            _nextId += 1;
            using (StreamWriter sw = new StreamWriter(_fileIdPath))
            {
                sw.WriteLine(_nextId);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
