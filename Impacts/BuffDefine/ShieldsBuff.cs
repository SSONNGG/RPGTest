using RPGTest.Impacts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RPGTest.Impacts.BuffDefine
{
    class ShieldsBuff : Buff
    {
        //护盾值
        private double _shieldsValues;

        public double ShieldsValues { get => _shieldsValues; set => _shieldsValues = value; }

        //默认构造函数
        public ShieldsBuff()
        {
            BufferType = BUFF_TYPE.Shields;
        }

        public override string ToString()
        {
            return "name = " + BufferName + ", Type:" + BufferType + ", DurationRound:" + DurationRound + ", ShieldsNums:" + _shieldsValues;
        }

        /// <summary>
        /// 更新护盾值
        /// </summary>
        /// <param name="value">更新的数值（可正可负）。<br/>正：数值增加，负：数值减少</param>
        /// <returns>更新后的数值</returns>
        public double UpdateValues(double value)
        {
            return _shieldsValues + value <= 0 ? 0 : _shieldsValues + value;
        }
    }
}
