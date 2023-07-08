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
    public class Buff
    {
        public enum BUFF_TYPE
        {
            //护盾
            Shields,
            //加速
            Accelerated,
            //恢复
            Recovery,
        }

        //Buff类型
        private BUFF_TYPE _bufferType;
        //Buff名称
        private string _bufferName;
        //持续回合
        private int _durationRound;

        public BUFF_TYPE BufferType { get => _bufferType; set => _bufferType = value; }
        public string BufferName { get => _bufferName; set => _bufferName = value; }
        public int DurationRound { get => _durationRound; set => _durationRound = value; }


        /// <summary>
        /// 更新回合数
        /// </summary>
        /// <param name="round">更新的回合值（可正可负），正：回合数增加，负：回合数减少</param>
        /// <return>更新后的回合数</return>
        public int UpdateRound(int round)
        {
            if(_durationRound > 0)
            {
                //如果当前回合-更新的回合数小于0，直接返回0
                if (_durationRound + round < 0)
                {
                    return 0;
                }
                else
                {
                    return _durationRound + round;
                }
            }
            else//如果回合数小于0，直接返回0
            {
                return 0;
            }
        }   

        /// <summary>
        /// 更新当前Buff名称
        /// </summary>
        /// <param name="name">要更新的名称</param>
        /// <returns>更新后的名称</returns>
        public string UpdateName(string name)
        {
            return name;
        }
    }
}
