using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGTest.Impacts.Base
{
    /// <summary>
    /// 减益属性
    /// </summary>
    class DeBuff
    {
        enum DeBuffType
        {
            //减速
            Decelerated,
            //流血
            Bloodshed,
        }

        //Buff类型
        private DeBuffType _bufferType { get; set; }
        //Buff名称
        private string _bufferName { get; set; }
        //持续回合
        private int _durationRound { get; set; }
    }
}
