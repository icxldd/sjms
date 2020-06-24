using System;
using System.Collections.Generic;
using System.Text;

namespace sjms.Subject
{
    public abstract class AllyControlCenter
    {
        public string AllyName { get; set; }



        protected IList<Observer.IObserver> playerList = new List<Observer.IObserver>();
        public void Join(Observer.IObserver observer)
        {
            playerList.Add(observer);
           // Console.WriteLine("通知：{0} 加入 {1} 战队", observer.OBName, this.AllyName);
        }

        public void Quit(Observer.IObserver observer)
        {
            playerList.Remove(observer);
          //  Console.WriteLine("通知：{0} 退出 {1} 战队", observer.OBName, this.AllyName);
        }

        // 声明抽象通知方法
        public abstract void NotifyObserver(string name);


    }
}
