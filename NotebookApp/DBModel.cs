#define PRINTSQL

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class DBModel : IModel
    {
        string connectionString;

        public DBModel()
        {
            connectionString =
                ConfigurationManager.ConnectionStrings
                ["NotebookApp.Properties.Settings.PagesConnectionString"]
                .ConnectionString;
        }

        public void Create(IPageable page)
        {
            using (SqlConnection con = new SqlConnection(
        connectionString))
            {
                int pageId;
                con.Open();
                try
                {
                    using (SqlCommand command = new SqlCommand(
                        "INSERT INTO Page(Author, Title) VALUES(@Author, @Title); SELECT SCOPE_IDENTITY();", con))
                    {
                        command.Parameters.Add(new SqlParameter("Author", page.Page.author));
                        command.Parameters.Add(new SqlParameter("Title", page.Page.title));
#if(PRINTSQL)
                        string tmp = command.CommandText.ToString();
                        foreach (SqlParameter p in command.Parameters)
                        {
                            tmp = tmp.Replace('@' + p.ParameterName.ToString(), "'" + p.Value.ToString() + "'");
                        }
                        Console.WriteLine(tmp);
#endif
                        pageId = int.Parse(command.ExecuteScalar().ToString());
                    }

                    if (page is Message pMessage)
                    {
                        using (SqlCommand command = new SqlCommand(
                            "INSERT INTO Message(PageId, Message) VALUES(@PageId, @Message)", con))
                        {
                            command.Parameters.Add(new SqlParameter("PageId", pageId));
                            command.Parameters.Add(new SqlParameter("Message", pMessage.GetMessage));
#if (PRINTSQL)
                            string tmp = command.CommandText.ToString();
                            foreach (SqlParameter p in command.Parameters)
                            {
                                tmp = tmp.Replace('@' + p.ParameterName.ToString(), "'" + p.Value.ToString() + "'");
                            }
                            Console.WriteLine(tmp);
#endif
                            command.ExecuteNonQuery();
                        }
                    }
                }
                catch
                {
                    Console.WriteLine("Could not insert.");
                }
                con.Close();
            }
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
            List<Message> mList = new List<Message>();
            List<IPageable> list = new List<IPageable>();

            using (SqlConnection con = new SqlConnection(
            connectionString))
            {
                con.Open();
                string query = "SELECT Page.Id, Page.Author, Page.Title, Message.Message" +
                    " FROM Message " +
                    " INNER JOIN Page" +
                    " ON Page.Id = Message.PageId"
                    ;

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        int id = reader.GetInt32(0);
                        string author = reader.GetString(1);
                        string title = reader.GetString(2);
                        string message = reader.GetString(3);
                        mList.Add(new Message(id, author, title, message));
                    }
                }
                con.Close();
            }
            list = list.Concat(mList).ToList();
            return list;
        }
    }
}
