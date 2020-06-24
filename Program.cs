using sjms.Domain;
using System;

namespace sjms
{
    class Program
    {
        static void Main(string[] args)
        {

            Word w = Word.GetInstance();

            var self = w.GetSelfRole();

            var g = w.GetGuaiWu();
            int hpItem = g.HP;
            int newhp = (self as roleActor).A_Call(g);




            Console.WriteLine($"当前怪物{hpItem}血，攻击一下怪物hp{newhp}");

        }
    }
}
