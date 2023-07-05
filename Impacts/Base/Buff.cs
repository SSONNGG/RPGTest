using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGTest.Impacts.Base
{
    /// <summary>
    /// 增益属性
    /// </summary>
    class Buff
    {
        public enum BuffType
        {
            //护盾
            Shields,
            //加速
            Accelerated,
            //回复
            Recovery,
        }

        //Buff类型
        private BuffType _bufferType;
        //Buff名称
        private string _bufferName;
        //持续回合
        private int _durationRound;

        public BuffType BufferType { get => _bufferType; set => _bufferType = value; }
        public string BufferName { get => _bufferName; set => _bufferName = value; }
        public int DurationRound { get => _durationRound; set => _durationRound = value; }
    }
}
