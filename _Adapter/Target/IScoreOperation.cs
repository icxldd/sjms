using sjms.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace sjms._Adapter.Target
{
    public interface IScoreOperation
    {
        Actor GetObjByHp(IList<Actor> hp);
        Actor GetObjByA(IList<Actor> a);
    }
}
