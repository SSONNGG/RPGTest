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
            foreach (var play in lstPlayers)
            {
                //记录角色初始位置
                positions[play] = 0;
                //为每个 Player 对象的 BloodChanged 事件添加事件处理程序
                play.BloodChanged += Player_BloodChanged;
            }
            foreach (var comp in lstComputers)
            {
                positions[comp] = 0;
                //为每个 Player 对象的 BloodChanged 事件添加事件处理程序
                comp.BloodChanged += Player_BloodChanged;
            }
            onRun();
        }


        public void onRun()
        {
            while (LstComputers.Count > 0 || LstPlayers.Count > 0)
            {
                // 计算每个角色到达速度条末端所需的时间，并找到最短时间
                double minTime = double.MaxValue;
                foreach (Player player in lstPlayers)
                {
                    double time = (SPEED_BAR - positions[player]) / player.Speed;
                    minTime = Math.Min(minTime, time);
                }
                foreach (Player computer in lstComputers)
                {
                    double time = (SPEED_BAR - positions[computer]) / computer.Speed;
                    minTime = Math.Min(minTime, time);
                }

                // 更新所有角色的位置
                for (int i = lstPlayers.Count - 1; i >= 0; i--)
                {
                    Player player = lstPlayers[i];
                    positions[player] += player.Speed * minTime;
                    if (positions[player] >= SPEED_BAR)
                    {
                        positions[player] %= SPEED_BAR;
                        onPause(player); // 决策
                    }
                }
                for (int i = lstComputers.Count - 1; i >= 0; i--)
                {
                    Player computer = lstComputers[i];
                    positions[computer] += computer.Speed * minTime;
                    if (positions[computer] >= SPEED_BAR)
                    {
                        positions[computer] %= SPEED_BAR;
                        onPause(computer); // 决策
                    }
                }

                // 输出当前所有角色的状态
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Players速度序列: ");
                foreach (Player rolePlayer in lstPlayers)
                {
                    Console.WriteLine(rolePlayer.Name + ": " + positions[rolePlayer] + "，生命值:" + rolePlayer.Blood);
                }
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Computers速度序列: ");
                foreach (Player roleComputer in lstComputers)
                {
                    Console.WriteLine(roleComputer.Name + ": " + positions[roleComputer] + "，生命值:" + roleComputer.Blood);
                }
                Console.WriteLine("-------------------------------------");
                // =========================================迭代1
                //// 更新所有角色的位置
                //foreach (Player player in lstPlayers)
                //{
                //    positions[player] += player.Speed;
                //}
                //foreach (Player computer in lstComputers)
                //{
                //    positions[computer] += computer.Speed;
                //}

                //// 检查哪些角色到达了速度条末端
                //for (int i = lstPlayers.Count - 1; i >= 0; i--)
                //{
                //    Player player = lstPlayers[i];
                //    if (positions[player] >= SPEED_BAR)
                //    {
                //        positions[player] %= SPEED_BAR;
                //        onPause(player); // 决策
                //    }
                //}
                //for (int i = lstComputers.Count - 1; i >= 0; i--)
                //{
                //    Player computer = lstComputers[i];
                //    if (positions[computer] >= SPEED_BAR)
                //    {
                //        positions[computer] %= SPEED_BAR;
                //        onPause(computer); // 决策
                //    }
                //}

                //// 输出当前所有角色的状态
                //Console.WriteLine("-------------------------------------");
                //Console.WriteLine("Players速度序列: ");
                //foreach (Player rolePlayer in lstPlayers)
                //{
                //    Console.WriteLine(rolePlayer.Name + ": " + positions[rolePlayer] + "，生命值:" + rolePlayer.Blood);
                //}
                //Console.WriteLine("-------------------------------------");
                //Console.WriteLine("-------------------------------------");
                //Console.WriteLine("Computers速度序列: ");
                //foreach (Player roleComputer in lstComputers)
                //{
                //    Console.WriteLine(roleComputer.Name + ": " + positions[roleComputer] + "，生命值:" + roleComputer.Blood);
                //}
                //Console.WriteLine("-------------------------------------");

                // =========================================原版
                ////List<Player> playersToRemove = new List<Player>();
                //for (int i =lstPlayers.Count -1;i>=0;i--)
                //{
                //    Player player = lstPlayers[i];
                //    positions[player] += player.Speed;
                //    if (positions[player] >= SPEED_BAR)
                //    {
                //        positions[player] %= SPEED_BAR;
                //        onPause(player);//决策

                //        // 输出当前角色状态
                //        Console.WriteLine("-------------------------------------");
                //        Console.WriteLine("行动后Players速度序列: ");
                //        foreach (Player rolePlayer in lstPlayers)
                //        {
                //            Console.WriteLine(rolePlayer.Name + ": " + positions[rolePlayer] + "，生命值:" + rolePlayer.Blood);
                //        }
                //        Console.WriteLine("-------------------------------------");
                //        Console.WriteLine("-------------------------------------");
                //        Console.WriteLine("行动后Computers速度序列: ");
                //        foreach (Player roleComputer in lstComputers)
                //        {
                //            Console.WriteLine(roleComputer.Name + ": " + positions[roleComputer] + "，生命值:" + roleComputer.Blood);
                //        }
                //        Console.WriteLine("-------------------------------------");
                //    }
                //}

                ////foreach (Player player in playersToRemove)
                ////{
                ////    lstPlayers.Remove(player);
                ////    positions.Remove(player);
                ////}

                ////List<Player> computersToRemove = new List<Player>();
                //for (int i = lstComputers.Count -1;i>=0;i--)
                //{
                //    Player computer = lstComputers[i];
                //    positions[computer] += computer.Speed;
                //    if (positions[computer] >= SPEED_BAR)
                //    {
                //        positions[computer] %= SPEED_BAR;
                //        onPause(computer);//决策

                //        // 输出当前角色状态
                //        Console.WriteLine("-------------------------------------");
                //        Console.WriteLine("行动后Players速度序列: ");
                //        foreach (Player rolePlayer in lstPlayers)
                //        {
                //            Console.WriteLine(rolePlayer.Name + ": " + positions[rolePlayer] + "，生命值:" + rolePlayer.Blood);
                //        }
                //        Console.WriteLine("-------------------------------------");
                //        Console.WriteLine("-------------------------------------");
                //        Console.WriteLine("行动后Computers速度序列: ");
                //        foreach (Player roleComputer in lstComputers)
                //        {
                //            Console.WriteLine(roleComputer.Name + ": " + positions[roleComputer] + "，生命值:" + roleComputer.Blood);
                //        }
                //        Console.WriteLine("-------------------------------------");
                //    }
                //}
                ////foreach (Player computer in computersToRemove)
                ////{
                ////    lstComputers.Remove(computer);
                ////    positions.Remove(computer);
                ////}

                //// 输出当前角色状态
                //Console.WriteLine("-------------------------------------");
                //Console.WriteLine("Players速度序列: ");
                //foreach (Player player in lstPlayers)
                //{
                //    Console.WriteLine(player.Name + ": " + positions[player] + "，生命值:" + player.Blood);
                //}
                //Console.WriteLine("-------------------------------------");
                //Console.WriteLine("-------------------------------------");
                //Console.WriteLine("Computers速度序列: ");
                //foreach (Player computer in lstComputers)
                //{
                //    Console.WriteLine(computer.Name + ": " + positions[computer] + "，生命值:" + computer.Blood);
                //}
                //Console.WriteLine("-------------------------------------");
                //// 假设每次循环代表1秒钟
                Thread.Sleep(1000);

                onStop();
            }
        }

        public void onPause(Player player)
        {
            //TODO:接收用户输入
            Console.WriteLine("===============行动回合===============");
            Console.WriteLine("当前行动角色："+player.Name+"，行动前血量："+player.Blood);
            //血量操作
            player.Blood -= 20;
            Console.WriteLine("当前行动角色：" + player.Name + "，行动后血量：" + player.Blood);
            Console.WriteLine("===============回合结束===============");
            //TODO:执行用户决策
        }

        public void onStop()
        {
            if(lstComputers.Count == 0 && lstPlayers.Count > 0)
            {
                lstComputers.Clear();
                lstPlayers.Clear();
                Console.WriteLine("Player Win!");
            }
            else if(lstPlayers.Count == 0 && lstComputers.Count > 0)
            {
                lstComputers.Clear();
                lstPlayers.Clear();
                Console.WriteLine("Computer Win!");
            }
            //else
            //{
            //    Console.WriteLine("=============next calculate!=============");
            //}
        }

        private void Player_BloodChanged(object sender, EventArgs e)
        {
            Player player = sender as Player;
            if (player != null && player.Blood <= 0)
            {
                //玩家血量降为 0，从List中移出
                if(lstPlayers.Contains(player))
                {
                    lstPlayers.Remove(player);
                }else
                {
                    lstComputers.Remove(player);
                }
            }
        }
    }
}
