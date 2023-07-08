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
        public enum DEBUFF_TYPE
        {
            //减速
            Decelerated,
            //流血
            Bloodshed,
        }

        //Buff类型
        public DEBUFF_TYPE BufferType { get; set; }
        //Buff名称
        public string BufferName { get; set; }
        //持续回合
        public int DurationRound { get; set; }


        /// <summary>
        /// 更新回合数
        /// </summary>
        /// <param name="round">更新的回合值（可正可负），正：回合数增加，负：回合数减少</param>
        /// <return>更新后的回合数</return>
        public int UpdateRound(int round)
        {
            if (_durationRound > 0)
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
