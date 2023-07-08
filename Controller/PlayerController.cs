using RPGTest.Panel;
using RPGTest.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGTest.Controller
{
    //用户控制器，计算战斗过程
    class PlayerController : IControllerPanel
    {
        private List<Player> lstPlayers;    //玩家

        private List<Player> lstComputers;  //电脑

        public List<Player> LstPlayers 
        { 
            get => lstPlayers;
            set => lstPlayers = value;
        }

        public List<Player> LstComputers
        { 
            get => lstComputers;
            set => lstComputers = value;
        }

        
        public void onStart(List<Player> player, List<Player> computer)
        {
            //加载角色数据
            LstComputers = computer;
            LstPlayers = player;
        }


        public void onRun()
        {
            while (LstComputers.Count < 0 || LstPlayers.Count < 0)
            {
                //执行速度条
                onPause();
            }
            
            if(onStop())
            {
                Console.WriteLine("Player Win!");
            }else
            {
                Console.WriteLine("Computer Win!");
            }
        }

        public void onPause()
        {
            //接收用户输入
            //执行用户决策
        }

        public bool onStop()
        {
            if(LstComputers.Count <= 0 && lstPlayers.Count > 0)
            {
                LstComputers.Clear();
                lstPlayers.Clear();
                return true;
            }
            else
            {
                LstComputers.Clear();
                lstPlayers.Clear();
                return false;
            }
        }
    }
}
