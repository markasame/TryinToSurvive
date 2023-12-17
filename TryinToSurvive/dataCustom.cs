using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TryinToSurvive
{
    public class dataCustom
    {
        public string Text1;
        public string Text2;
        public dataCustom(string text1, string text2)
        {
            Text1 = text1;
            Text2 = text2;
        }
        public string DisplayLabel => $"{Text1}    {Text2}";
    }

}
