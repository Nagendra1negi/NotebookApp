using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (page is MessagePage pm)
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
            if (File.Exists(_filePagesPath))
            {
                XDocument xDoc = XDocument.Load(_filePagesPath);
                IEnumerable<XElement> xElements = xDoc.Elements("Document").Elements("Page").Where(xEl => (int)xEl.Element("Id") == id);
                xElements.Remove();
                xDoc.Save(_filePagesPath);
                DecrementId();
            }
        }

        public void Delete(IPageable page)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            if (File.Exists(_filePagesPath))
            {
                File.Delete(_fileIdPath);
                File.Delete(_filePagesPath);
            }
        }

        public IPageable Read(int id)
        {
            if (!File.Exists(_filePagesPath))
            {
                return null;
            }

            XDocument xDoc = XDocument.Load(_filePagesPath);
            XElement xElement = xDoc.Elements("Document").Elements("Page").Where(xEl => (int)xEl.Element("Id") == id).First();
            return new MessagePage(id, xElement.Element("Author").Value, xElement.Element("Title").Value, xElement.Element("Message").Value);

        }

        public List<IPageable> ReadAll()
        {
            if (!File.Exists(_filePagesPath))
            {
                return null;
            }
            XDocument xDoc = XDocument.Load(_filePagesPath);
            IEnumerable<XElement> xElements = xDoc.Elements("Document").Elements("Page");
            List<IPageable> listPages = new List<IPageable>();
            foreach (XElement xElement in xElements)
            {
                listPages.Add(new MessagePage(int.Parse(xElement.Element("Id").Value), xElement.Element("Author").Value, xElement.Element("Title").Value, xElement.Element("Message").Value));
            }
            return listPages;
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

        private void DecrementId()
        {
            _nextId -= 1;
            using (StreamWriter sw = new StreamWriter(_fileIdPath))
            {
                sw.WriteLine(_nextId);
                sw.Flush();
                sw.Close();
            }
        }
    }
}
