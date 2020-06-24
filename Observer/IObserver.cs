using sjms.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace sjms.Observer
{
    public interface IObserver
    {
        string OBName { get;}
        AllyControlCenter control { get; set; }


        void BeAttacked();
        void Help();




    }
}
