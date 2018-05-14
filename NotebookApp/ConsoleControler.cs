using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class ConsoleControler : IControler
    {
        public void ReadCommand()
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
                else
                    ReadCommand();
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
                        ActionManager(mOption, cOption);
                    }
                    else
                        ReadCommand();

                }
            }
        }

        public void UpdateView()
        {
            throw new NotImplementedException();
        }

        private void ActionManager(Menu m, Command c)
        {
            switch(m)
            {
                case Menu.New:
                    switch (c)
                    {
                        case Command.Message:
                            IModel 
                    }
            }
        }
    }
}
