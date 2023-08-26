using RPGTest.Controller;
using RPGTest.Impacts.BuffDefine;
using RPGTest.Role;
using System.Text.RegularExpressions;
using static RPGTest.Impacts.Base.Buff;

namespace RPGTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player player01 = new Player();
            player01.Name = "角色1";
            player01.Speed = 30;
            player01.Blood = 100;

            Player player02 = new Player();
            player02.Name = "角色2";
            player02.Speed = 35;
            player02.Blood = 100;

            Player player03 = new Player();
            player03.Name = "角色3";
            player03.Speed = 40;
            player03.Blood = 100;

            List<Player> lstPlayers = new List<Player>();
            lstPlayers.Add(player01);
            lstPlayers.Add(player02);
            lstPlayers.Add(player03);

            Player computer01 = new Player();
            computer01.Name = "电脑1";
            computer01.Speed = 28;
            computer01.Blood = 100;

            Player computer02 = new Player();
            computer02.Name = "电脑2";
            computer02.Speed = 32;
            computer02.Blood = 100;

            Player computer03 = new Player();
            computer03.Name = "电脑3";
            computer03.Speed = 38;
            computer03.Blood = 100;

            List<Player> lstComputers = new List<Player>();
            lstComputers.Add(computer01);
            lstComputers.Add(computer02);
            lstComputers.Add(computer03);

            PlayerController controller = new PlayerController();
            controller.onStart(lstPlayers, lstComputers);
        }
    }
}