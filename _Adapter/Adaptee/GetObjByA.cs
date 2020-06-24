using sjms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sjms._Adapter.Adaptee
{
    public class GetObjByA
    {
        public Actor GetObj(IList<Actor> a)
        {
            return a.FirstOrDefault(x => x.A > 0);
        }


    }
}
