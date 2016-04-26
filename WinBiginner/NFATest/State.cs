using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFATest
{
  

    class State
    {
        public State()
        {
            OnStateList = new List<State>();
            OffStateList = new List<State>();
            On = false;
        }
        public List<State> OnStateList { get; set; }
        public List<State> OffStateList { get; set; }

        public void Sygnal(char str)
        {
            On = false;
            switch (str)
            {
                case '0':
                    foreach (var state in OffStateList)
                    {
                        state.On = true;
                    }
                    break;
                case '1':
                    foreach (var state in OnStateList)
                    {
                        state.On = true;
                    }
                    break;
                default:
                    throw new Exception();
            }
        }

        public bool On { get; set; }
    }
}
