using sjms._Adapter.Adaptee;
using sjms._Adapter.Target;
using sjms.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace sjms._Adapter.Adapter
{
    public class OperationAdapter : IScoreOperation
    {
        private GetObjByA A;
        private GetObjByHp HP;
        public OperationAdapter()
        {
            A = new GetObjByA();
            HP = new GetObjByHp();
        }
        public Actor GetObjByA(IList<Actor> a)
        {
            return A.GetObj(a);
        }

        public Actor GetObjByHp(IList<Actor> hp)
        {
            return HP.GetObj(hp);
        }
    }
}
