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
            player01._name = "角色1";
            player01._speed = 30;

            Player player02 = new Player();
            player02._name = "角色2";
            player02._speed = 35;

            Player player03 = new Player();
            player03._name = "角色3";
            player03._speed = 40;

            List<Player> lstPlayers = new List<Player>();
            lstPlayers.Add(player01);
            lstPlayers.Add(player02);
            lstPlayers.Add(player03);

            Player computer01 = new Player();
            computer01._name = "电脑1";
            computer01._speed = 28;

            Player computer02 = new Player();
            computer02._name = "电脑2";
            computer02._speed = 32;

            Player computer03 = new Player();
            computer03._name = "电脑3";
            computer03._speed = 38;

            List<Player> lstComputers = new List<Player>();
            lstComputers.Add(computer01);
            lstComputers.Add(computer02);
            lstComputers.Add(computer03);

            PlayerController controller = new PlayerController();
            controller.onStart(lstPlayers, lstComputers);
        }
    }
}