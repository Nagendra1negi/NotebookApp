using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace NotebookApp
{
    class FileModel : IModel
    {
        string _filePagesPath = @"../Files/Pages.xml";
        string _fileIdPath = @"../Files/NextId.xml";
        string _filesDir = @"../Files";
        int _nextId = 1;

        public FileModel()
        {
            if (!Directory.Exists(_filesDir))
            {
                Directory.CreateDirectory(_filesDir);
            }
            if (!File.Exists(_filePagesPath))
            {
                XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
                xmlWriterSettings.Indent = true;
                xmlWriterSettings.NewLineOnAttributes = true;
                using (XmlWriter xmlWriter = XmlWriter.Create(_filePagesPath, xmlWriterSettings))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Document");
                    xmlWriter.WriteEndElement();
                }
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
            XDocument xdoc = XDocument.Load(_filePagesPath);
            XElement pageElement =
                new XElement("Page",
                    new XElement("Id", _nextId),
                    new XElement("Author", page.Page.author),
                    new XElement("Title", page.Page.title)
                );
            if (page is Message pm)
            {
                pageElement.Add(new XElement("Message", pm.GetMessage));
            }
            xdoc.Element("Document").Add(
                pageElement);
            xdoc.Save(_filePagesPath);
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
            File.Delete(_fileIdPath);
            File.Delete(_filePagesPath);
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
