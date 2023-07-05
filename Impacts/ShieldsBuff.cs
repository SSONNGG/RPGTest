using RPGTest.Impacts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RPGTest.Impacts
{
    class ShieldsBuff : Buff
    {
        //护盾值
        private int _shieldsNums;

        public int ShieldsNums { get => _shieldsNums; set => _shieldsNums = value; }

        public ShieldsBuff()
        {
            BufferType = BuffType.Shields;
        }

        public override string ToString()
        {
            return "name = " + BufferName + ", Type:" + BufferType + ", DurationRound:" + DurationRound + ", ShieldsNums:" + ShieldsNums;
        }
    }
}
