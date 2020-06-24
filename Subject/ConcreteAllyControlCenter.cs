using System;
using System.Collections.Generic;
using System.Text;

namespace sjms.Subject
{
    public class ConcreteAllyControlCenter : AllyControlCenter
    {
        public ConcreteAllyControlCenter(string allyName)
        {
           // Console.WriteLine($"------------------------{allyName}军团-------------------------------");
            this.AllyName = allyName;

        }
        public override void NotifyObserver(string playerName)
        {
            foreach (var player in playerList)
            {
                if (!player.OBName.Equals(playerName, StringComparison.OrdinalIgnoreCase))
                {
                    player.Help();
                }
            }
        }

    }
}
