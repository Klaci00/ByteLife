using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteLife2
{
    public class News
    {
        public static string NewsWriter { get; set; }

        public static void NewsAdder(string text)
        {
            text = text + "\n";
            NewsWriter += text;
        }

    }
}
