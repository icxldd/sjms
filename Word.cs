using sjms.Domain;
using sjms.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace sjms
{
    public class Word
    {
        public Word()
        {
            roles = new List<Actor>();
            guaiwus = new List<Actor>();
            roleControl = new ConcreteAllyControlCenter("人物");
            guaiwuControl = new ConcreteAllyControlCenter("怪物");
            initList();
        }

        private void initList()
        {
            ActorController director = new ActorController();
            for (int i = 0; i < 10; i++)
            {
                ActorBuilder builder = new RoleBuilder(roleControl);
                Actor a = director.Construct(builder);
                roles.Add(a);
            }
            for (int i = 0; i < 100; i++)
            {
                ActorBuilder guaiwub = new GuaiWuBuilder(guaiwuControl);
                Actor a = director.Construct(guaiwub);
                guaiwus.Add(a);
            }
            ActorBuilder self = new RoleBuilder(roleControl);
            selfRole = director.Construct(self);
        }

        private ConcreteAllyControlCenter roleControl { get; set; }

        private ConcreteAllyControlCenter guaiwuControl { get; set; }
        private IList<Actor> roles { get; set; }
        private IList<Actor> guaiwus { get; set; }
        private Actor selfRole { get; set; }
        public Actor GetGuaiWu()
        {
            Random r = new Random();
            return guaiwus[r.Next(guaiwus.Count)];
        }

        public Actor GetSelfRole()
        {
            return selfRole;
        }


        public static Word GetInstance()
        {
            return Self.instance;
        }


        private class Self
        {
            static Self() { }

            internal static readonly Word instance = new Word();
        }

    }
}
