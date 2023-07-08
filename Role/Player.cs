﻿using RPGTest.Impacts.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace RPGTest.Role
{
    public class Player
    {
        //名称
        private string _name;
        //血量值
        private int _blood;
        //速度
        private int _speed;


        //增益列表
        private List<Buff> lstBuffs;
        //减益列表
        private List<DeBuff> lstDebuffs;

        //添加Buff
        public void AddBuff(Buff buff)
        {
            this.lstBuffs.Add(buff);
        }

        //移除Buff
        public void RemoveBuff(Buff buff)
        {
            this.lstBuffs.Remove(buff);
        }

        //添加Debuff
        public void AddDebuff(DeBuff debuff)
        {
            this.lstDebuffs.Add(debuff);
        }

        //移除Debuff
        public void RemoveDebuff(DeBuff debuff)
        {
            this.lstDebuffs.Remove(debuff);
        }
    }
}
