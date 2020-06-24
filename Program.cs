using sjms._Adapter.Adapter;
using sjms._Adapter.Target;
using sjms._Facade.Facade;
using sjms.Domain;
using System;

namespace sjms
{
    class Program
    {
        static Word w;
        static void Main(string[] args)
        {

            w = Word.GetInstance();





            testFacade();
        }
        private static void testFacade()
        {
            var self = w.GetSelfRole();
            AbstractEncryptFacade a = new NewEncryptFacade();
            AbstractEncryptFacade aa = new EncryptFacade();
            var d =  aa.DataEncrypt(self.Name);
            var dd = a.DataEncrypt(self.Name);
            Console.WriteLine(d);
            Console.WriteLine(dd);


        }
        private static void testComposite()
        {
            var self = w.GetSelfRole();
            (self as roleActor).checkPack();
        }

        private static void testAdapter()
        {
            IScoreOperation iso = new OperationAdapter();
            var name = iso.GetObjByA(w.GetRolesList()).Name;
            Console.WriteLine(name);
        }

        static void testObserver()
        {
            var self = w.GetSelfRole();
            var g = w.GetGuaiWu();
            int hpItem = g.HP;
            int newhp = (self as roleActor).A_Call(g);
            Console.WriteLine($"当前怪物{hpItem}血，攻击一下怪物hp{newhp}");

        }
    }
}
