using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class ConsoleControler : IControler
    {
        public void ReadCommand(IModel model)
        {
            Menus menu = new Menus();
            menu.ShowMenu();
            string input = Console.ReadLine();
            string[] cmds = input.Split();

            if (cmds.Length == 1)
            {
                Menu mOption = menu.ReadOption(cmds[0]);
                if (menu.ValidOption(mOption))
                {
                    Commands cOptions = new Commands();
                    cOptions.Show(mOption);
                }
                ReadCommand(model);
            }
            else if (cmds.Length == 2)
            {
                Menu mOption = menu.ReadOption(cmds[0]);
                if (menu.ValidOption(mOption))
                {
                    Commands cOptions = new Commands();
                    Command cOption = cOptions.ReadOption(cmds[1]);
                    if (cOptions.ValidOption(cOption))
                    {
                        ActionManager(mOption, cOption, model);
                    }
                    else
                        ReadCommand(model);

                }
            }
        }

        public void UpdateView()
        {
            throw new NotImplementedException();
        }

        private void ActionManager(Menu m, Command c, IModel model)
        {
            switch(m)
            {
                case Menu.New:
                    switch (c)
                    {
                        case Command.Message:
                            CreateAcquireData(new Message(), model);
                            break;
                        default:
                            Console.WriteLine("Invalid Operation!");
                            ReadCommand(model);
                            break;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid Operation!");
                    ReadCommand(model);
                    break;
            }
        }

        /* action to select wich IModel to use and create the data according to that selection*/
        private void CreateAcquireData(IPageable page, IModel model)
        {
            /*acquire data */
            PageData pd = new PageData();
            Console.WriteLine("Author:");
            pd.author = Console.ReadLine();
            Console.WriteLine("Title:");
            pd.title = Console.ReadLine();
            page.Page = pd;
            if(page is Message messagePage)
            {
                Console.WriteLine("What is your message to the world?");
                messagePage.InputMessage(Console.ReadLine());
                Create(page, model);
                
            }

        }

        /*select in wich mode should we save the data */
        private void Create(IPageable page, IModel model)
        {
            model.Create(page);
            Console.WriteLine("Page successfuly created!");
            ShowPages(model);
        }

        public void ShowPages(IModel model)
        {
            /* user choosed temp mode */
            if (model is TempModel tmodel)
            {
                foreach(IPageable page in model.ReadAll())
                {
                    Console.WriteLine($"Pages:\nId:{page.Page.id}, {page.Page.title} done by {page.Page.author}.");
                }
            }
        }

        public IModel GetMode()
        {
            Console.WriteLine("Which Mode do you want?");
            Console.WriteLine(StaticData.Show(typeof(Mode)));
            Mode cMode = StaticData.ReadMode(Console.ReadLine());
            switch (cMode)
            {
                case Mode.Database:
                    return new DBModel();
                case Mode.File:
                    return new FileModel();
                case Mode.Temp:
                    return new TempModel();
                default:
                    return null;
            }
        }
    }
}
