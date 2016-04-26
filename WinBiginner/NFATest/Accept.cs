using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFATest
{
    class Accept:State
    {
        public new void Sygnal(char str)
        {
            On = false;
            Console.WriteLine("accepted!");
            base.Sygnal(str);
        }
    }
}
