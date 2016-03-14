using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMoq
{
    class Program
    {
        static void Main(string[] args)
        {
            Messenger msg = new Messenger(new Transport("1.1.1.1"));
            string result = msg.Send("test");
        }
    }
}
