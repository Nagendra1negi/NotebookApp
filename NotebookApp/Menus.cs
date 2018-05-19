using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    class Menus
    {
        public void ShowMenu()
        {
            Console.WriteLine(StaticData.Show(typeof(Menu)));
        }

        public Menu ReadOption(string sChoose)
        {
            if (int.TryParse(sChoose, out int iChoose))
            {
                iChoose--;//because the following array is 0 indexed
                Array cArr = Enum.GetValues(typeof(Menu));
                if (iChoose <= cArr.Length - 1)
                {
                    return (Menu)cArr.GetValue(iChoose);
                }
                else
                {
                    return Menu.Invalid;
                }
            }
            else
            {
                if (Enum.TryParse(sChoose, true, out Menu cmd))
                {
                    return cmd;
                }
                else
                {
                    return Menu.Invalid;
                }
            }

        }

        public bool ValidOption(Menu mOption)
        {
            if (mOption == Menu.Invalid)
            {
                Console.WriteLine("Invalid Option!");
                return false;
            }
            return true;
        }
    }
}
