using RPGTest.Impacts.BuffDefine;
using static RPGTest.Impacts.Base.Buff;

namespace RPGTest
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Console.WriteLine("Hello, World!");
            ShieldsBuff shieldsBuff = new ShieldsBuff();
            shieldsBuff.BufferName = "test";
            shieldsBuff.DurationRound = 2;
            //shieldsBuff.BufferType = BuffType.Shields;
            shieldsBuff.ShieldsValues = 200;
            Console.WriteLine(shieldsBuff.ToString());
        }
    }
}