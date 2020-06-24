using System;
using System.Collections.Generic;
using System.Text;

namespace sjms._Composite
{
    public class Folder : AbstractFile
    {
        private IList<AbstractFile> fileList = new List<AbstractFile>();
        private string name;

        public Folder(string name)
        {
            this.name = name;
        }

        public override void Add(AbstractFile file)
        {
            fileList.Add(file);
        }

        public override void Remove(AbstractFile file)
        {
            fileList.Remove(file);
        }

        public override AbstractFile GetChild(int index)
        {
            return fileList[index];
        }

        public override void KillVirus()
        {
            foreach (var item in fileList)
            {
                item.KillVirus();
            }
        }
    }
}
