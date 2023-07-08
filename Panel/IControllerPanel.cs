using RPGTest.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGTest.Panel
{
    interface IControllerPanel
    {
        /// <summary>
        /// 开始，加载数据
        /// </summary>
        /// <param name="player">玩家角色列表</param>
        /// <param name="computer">电脑角色列表</param>
        public void onStart(List<Player> player,List<Player> computer);

        /// <summary>
        /// 执行，启动战斗
        /// </summary>
        public void onRun();

        /// <summary>
        /// 暂停，玩家决策
        /// </summary>
        public void onPause();

        /// <summary>
        /// 结束，判断胜负
        /// </summary>
        /// <returns>玩家胜利返回true<br/>电脑胜利返回false</returns>
        public bool onStop();
    }
}
