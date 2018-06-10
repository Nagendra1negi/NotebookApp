//#define PRINTSQL

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
            using (SqlConnection connection = new SqlConnection(
        connectionString))
            {
                int pageId;
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                SqlTransaction transaction = connection.BeginTransaction();
                command.Transaction = transaction;
                command.Connection = connection;
                try
                {
                    command.CommandText =
                        "INSERT INTO Page(Author, Title) VALUES(@Author, @Title); SELECT SCOPE_IDENTITY();";


                    command.Parameters.Add(new SqlParameter("Author", page.Page.author));
                    command.Parameters.Add(new SqlParameter("Title", page.Page.title));
#if (PRINTSQL)
                    string tmp = command.CommandText.ToString();
                    foreach (SqlParameter p in command.Parameters)
                    {
                        tmp = tmp.Replace('@' + p.ParameterName.ToString(), "'" + p.Value.ToString() + "'");
                    }
                    Console.WriteLine(tmp);
#endif
                    pageId = int.Parse(command.ExecuteScalar().ToString());


                    if (page is Message pMessage)
                    {
                        command.CommandText =
                            "INSERT INTO Message(PageId, Message) VALUES(@PageId, @Message)";
                        command.Parameters.Add(new SqlParameter("PageId", pageId));
                        command.Parameters.Add(new SqlParameter("Message", pMessage.GetMessage));
#if (PRINTSQL)
                        string tmp1 = command.CommandText.ToString();
                        foreach (SqlParameter p in command.Parameters)
                        {
                            tmp1 = tmp1.Replace('@' + p.ParameterName.ToString(), "'" + p.Value.ToString() + "'");
                        }
                        Console.WriteLine(tmp1);
#endif
                        command.ExecuteNonQuery();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Could not insert.{0}", e.Message);
                }
                transaction.Commit();
                connection.Close();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection con = new SqlConnection(
            connectionString))
            {
                con.Open();
                string query = "DELETE" +
                    " FROM Message " +
                    " where PageId = " + id
                    ;
                SqlCommand command = new SqlCommand(query, con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(IPageable page)
        {
            throw new NotImplementedException();
        }

        public void DeleteAll()
        {
            using (SqlConnection con = new SqlConnection(
            connectionString))
            {
                con.Open();
                string query = "DELETE" +
                    " FROM Message "
                    ;
                SqlCommand command = new SqlCommand(query, con);
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public IPageable Read(int id)
        {
            string author = "";
            string title = "";
            string message = "";
            using (SqlConnection con = new SqlConnection(
            connectionString))
            {
                con.Open();
                string query = "SELECT Page.Id, Page.Author, Page.Title, Message.Message" +
                    " FROM Message " +
                    " INNER JOIN Page" +
                    " ON Page.Id = Message.PageId" +
                    " WHERE Page.Id = " + id
                    ;

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        author = reader.GetString(1);
                        title = reader.GetString(2);
                        message = reader.GetString(3);
                    }
                }
                con.Close();
            }
            return new Message(id, author, title, message);
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
