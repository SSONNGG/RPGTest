using RPGTest.Impacts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RPGTest.Role
{
    public class Player
    {
        //名称
        private string _name { get; set; }
        //血量值
        private int _blood { get; set; }
        //速度
        private int _speed { get; set; }

        //增益列表
        private List<Buff> lstBuffs { get; set; }
        //减益列表
        private List<DeBuff> lstDebuffs { get; set; }
    }
}
