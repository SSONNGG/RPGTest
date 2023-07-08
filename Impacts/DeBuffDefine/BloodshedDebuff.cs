using RPGTest.Impacts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static RPGTest.Impacts.Base.Buff;

namespace RPGTest.Impacts.DeBuffDefine
{
    class BloodshedDebuff :DeBuff
    {
        //伤害值
        private double _bloodshedValues;

        public double BloodshedValues { get => _bloodshedValues; set => _bloodshedValues = value; }

        //默认构造函数
        public BloodshedDebuff()
        {
           BufferType = DEBUFF_TYPE.Bloodshed;
        }

        public override string ToString()
        {
            return "name = " + BufferName + ", Type:" + BufferType + ", DurationRound:" + DurationRound + ", BloodshedValues:" + BloodshedValues;
        }

        /// <summary>
        /// 更新伤害值
        /// </summary>
        /// <param name="value">更新的数值（可正可负）。<br/>正：数值增加，负：数值减少</param>
        /// <returns>更新后的数值</returns>
        public double UpdateValues(double value)
        {
            return _bloodshedValues + value <= 0 ? 0 : _bloodshedValues + value;
        }
    }
}
