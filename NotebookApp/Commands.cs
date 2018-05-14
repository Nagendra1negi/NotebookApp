using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Commands
    {
        public void Show(Menu m)
        {
            Dictionary<Command, string> cDesc =
            new Dictionary<Command, string>();

            foreach(Command opt in Enum.GetValues(typeof(Command)))
            {
                //the invalid option is just for control purpose not for the user
                if (opt != Command.Invalid)
                {
                    string desc = m + " " + opt + " page";
                    cDesc.Add(opt, desc);
                }
            }

            Console.WriteLine("{0} Commands:", m);

            foreach (KeyValuePair<Command, string> opts in cDesc)
            {
                string optMsg=string.Format("{0}{1}", opts.Key.ToString().PadRight(10), opts.Value);
                Console.WriteLine(optMsg);
            }
        }

        public Command ReadOption(string sChoose)
        {
            if (int.TryParse(sChoose, out int iChoose))
            {
                iChoose--;//because the following array is 0 indexed
                Array cArr = Enum.GetValues(typeof(Command));
                if (iChoose <= cArr.Length - 1)
                {
                    return (Command)cArr.GetValue(iChoose);
                }
                else
                {
                    return Command.Invalid;
                }
            }
            else
            {
                if (Enum.TryParse(sChoose, true, out Command cmd))
                {
                    return cmd;
                }
                else
                {
                    return Command.Invalid;
                }
            }

        }

        public bool ValidOption(Command mOption)
        {
            if (mOption == Command.Invalid)
            {
                Console.WriteLine("Invalid Option!");
                return false;
            }
            return true;
        }
    }
}
