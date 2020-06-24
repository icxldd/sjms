using System;
using System.Collections.Generic;
using System.Text;

namespace sjms._Composite
{

    public class ResFile : AbstractFile
    {
        private string name;

        public ResFile(string name)
        {
            this.name = name;
        }

        public override void Add(AbstractFile file)
        {
            Console.WriteLine("对不起，系统不支持该方法！");
        }

        public override void Remove(AbstractFile file)
        {
            Console.WriteLine("对不起，系统不支持该方法！");
        }

        public override AbstractFile GetChild(int index)
        {
            Console.WriteLine("对不起，系统不支持该方法！");
            return null;
        }

        public override void KillVirus()
        {
            // 此处模拟杀毒操作
            Console.WriteLine(name);
        }

    }
}
