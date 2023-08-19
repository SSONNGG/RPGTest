using RPGTest.Panel;
using RPGTest.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static RPGTest.Panel.IControllerPanel;

namespace RPGTest.Controller
{
    //用户控制器，计算战斗过程
    class PlayerController : IControllerPanel
    {
        //速度条定义
        public static double SPEED_BAR = 100.0;
        //玩家
        private List<Player> lstPlayers;
        //电脑
        private List<Player> lstComputers;

        //位置字典，用于保存当前角色在速度条中的位置
        Dictionary<Player, double> positions = new Dictionary<Player, double>();

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

            //记录角色初始位置
            foreach (var play in lstPlayers)
            {
                positions[play] = 0;
            }
            foreach (var comp in lstComputers)
            {
                positions[comp] = 0;
            }
            onRun();
        }


        public void onRun()
        {
            while (LstComputers.Count > 0 || LstPlayers.Count > 0)
            {
                List<Player> playersToRemove = new List<Player>();
                foreach (Player player in lstPlayers)
                {
                    positions[player] += player._speed;
                    if (positions[player] >= SPEED_BAR)
                    {
                        positions[player] = 0;
                        Console.WriteLine(player._name + " 已经抵达速度条末尾");
                        playersToRemove.Add(player);
                    }
                }
                foreach (Player player in playersToRemove)
                {
                    lstPlayers.Remove(player);
                    positions.Remove(player);
                }

                List<Player> computersToRemove = new List<Player>();
                foreach (Player computer in lstComputers)
                {
                    positions[computer] += computer._speed;
                    if (positions[computer] >= SPEED_BAR)
                    {
                        positions[computer] = 0;
                        Console.WriteLine(computer._name + " 已经抵达速度条末尾");
                        computersToRemove.Add(computer);
                    }
                }
                foreach (Player computer in computersToRemove)
                {
                    lstComputers.Remove(computer);
                    positions.Remove(computer);
                }

                // 输出当前在速度条上的序列
                Console.Write("Players序列: ");
                foreach (Player player in lstPlayers)
                {
                    Console.Write(player._name + ": " + positions[player] + " ");
                }
                Console.WriteLine();
                Console.Write("Computers序列: ");
                foreach (Player computer in lstComputers)
                {
                    Console.Write(computer._name + ": " + positions[computer] + " ");
                }
                Console.WriteLine();
                // 假设每次循环代表1秒钟
                Thread.Sleep(1000);

                onPause();

                //TODO:数据处理
                if (onStop() == FightRes.PLAYER_WIN)
                {
                    Console.WriteLine("Player Win!");
                    break;
                }
                else if(onStop() == FightRes.COMPUTER_WIN)
                {
                    Console.WriteLine("Computer Win!");
                    break;
                }
                else
                {
                    Console.WriteLine("=============next calculate!=============");
                }
            }

           
        }

        public void onPause()
        {
            //TODO:接收用户输入
            //TODO:执行用户决策
        }

        public FightRes onStop()
        {
            if(LstComputers.Count == 0 && LstPlayers.Count > 0)
            {
                LstComputers.Clear();
                LstPlayers.Clear();
                return FightRes.PLAYER_WIN;
            }
            else if(LstPlayers.Count == 0 && LstComputers.Count > 0)
            {
                LstComputers.Clear();
                LstPlayers.Clear();
                return FightRes.COMPUTER_WIN;
            }
            else
            {
                return FightRes.CONTINUE;
            }
        }
    }
}
