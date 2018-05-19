using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotebookApp
{
    public enum Menu { Show, Delete, New, Logger, Invalid }
    public enum Command { Message, List, Image, Invalid }
    public enum Bullets { Dashed, Numbered, Star}
    public enum Mode { Temp, File, Database, Invalid}

    class StaticData
    {
        public static string Show(Type t)
        {
            StringBuilder inline = new StringBuilder();
            //the invalid option is just for control purpose not for the user
            string[] options = Enum.GetNames(t).Where(opt => opt != "Invalid").ToArray();
            for (int i = 0; i < options.Length; i++)
            {
                if (i != 0)
                {
                    //puts 'or' before the last menu option
                    string separator = (i == options.Length - 1 ? " or " : ", ");
                    inline.Append(separator);
                }
                inline.Append(options[i]);

            }
            return $"Please enter {inline}";
        }

        public static Mode ReadMode(string strChoose)
        {
            if (int.TryParse(strChoose, out int intChoose))
            {
                intChoose--;//because the following array is 0 indexed
                Array cArr = Enum.GetValues(typeof(Menu));
                if (intChoose <= cArr.Length - 1)
                {
                    return (Mode)cArr.GetValue(intChoose);
                }
                else
                {
                    return Mode.Invalid;
                }
            }
            else
            {
                if (Enum.TryParse(strChoose, true, out Mode cmd))
                {
                    return cmd;
                }
                else
                {
                    return Mode.Invalid;
                }
            }

        }
    }
   
}
