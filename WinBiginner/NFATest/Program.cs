using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFATest
{
    class Program
    {
        static void Main(string[] args)
        {
            State p0 = new State();
            State p1 = new State();
            Accept p2 = new Accept();
            Accept p3 = new Accept();

            p0.OffStateList.Add(p1);
            p0.OnStateList.Add(p0);
            p1.OffStateList.Add(p1);
            p1.OnStateList.Add(p2);
            p2.OffStateList.Add(p3);
            p2.OnStateList.Add(p2);
            p3.OffStateList.Add(p3);
            p3.OnStateList.Add(p2);

            List<State> NFT = new List<State>();
            NFT.Add(p0);
            NFT.Add(p1);
            NFT.Add(p2);
            NFT.Add(p3);

            p0.On = true;
      
            string str1 = "10010";

            foreach (var chr in str1)
            {
                foreach (var state in NFT)
                {
                    if (state.On)
                    {
                        state.Sygnal(chr);
                    }
                }
            }
        }
    }
}
