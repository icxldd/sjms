using System;
using System.Collections.Generic;
using System.Text;

namespace sjms._Composite
{
    public abstract class AbstractFile
    {
        public abstract void Add(AbstractFile file);
        public abstract void Remove(AbstractFile file);
        public abstract AbstractFile GetChild(int index);
        public abstract void KillVirus();

    }
}
