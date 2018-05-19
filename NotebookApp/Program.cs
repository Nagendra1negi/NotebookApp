using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Welcome();
            ConsoleControler cc = new ConsoleControler();
            /*depended on the save mode choosen by the user*/
            IModel dataModel = null;
            if (true)
            {
                dataModel = new TempModel();
            }
            cc.ReadCommand(dataModel);


        }

        public static void Welcome()
        {
            Console.WriteLine("Welcome to Notebook App (Created by Ricardo Costa, based on Thomas Brown work)");
        }

        
    }
}
