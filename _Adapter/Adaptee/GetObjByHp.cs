using sjms.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace sjms._Adapter.Adaptee
{
    public class GetObjByHp
    {
        public Actor GetObj(IList<Actor> hp)
        {
            return hp.FirstOrDefault(x => x.HP > 10);
        }

    }
}
