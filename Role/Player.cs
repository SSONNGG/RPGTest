using RPGTest.Impacts.Base;
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
        public string Name { set; get; }

        //血量值
        private int _blood;
        public int Blood
        {
            set
            {
                if (_blood != value)
                {
                    _blood = value;
                    OnBloodChanged(EventArgs.Empty);
                }
            }
            get => _blood;
        }
        //速度
        private int _speed;
        public int Speed{ set; get; }

        //增益列表
        private List<Buff> lstBuffs;
        //减益列表
        private List<DeBuff> lstDebuffs;

        //事件监听
        public event EventHandler BloodChanged;

        protected virtual void OnBloodChanged(EventArgs e)
        {
            BloodChanged?.Invoke(this, e);
        }

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
