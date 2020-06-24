using sjms.Inteface;
using sjms.Subject;
using System;
using System.Collections.Generic;
using System.Text;

namespace sjms.Domain
{
    public abstract class Actor : IPeopleFactory, Observer.IObserver
    {
        public int id { get; set; }
        public string Type { get; set; }
        public string FaceModelFile { get; set; }
        public int HP { get; set; }
        public int level { get; set; }
        public int A { get; set; }
        public string Name { get; set; }

        public string OBName { get => this.Name; }
        public AllyControlCenter control { get; set; }
        public Actor(AllyControlCenter control)
        {
            this.control = control;
            control.Join(this);
        }
        public int A_Call(Actor m)
        {
            m.HP -= this.A;
            m.BeAttacked();
            return m.HP;
        }

        public virtual void BeAttacked()
        {
            Console.WriteLine(this.Name + "在被攻击");
            this.control.NotifyObserver(this.Name);
        }

        public int GetSelfHP()
        {
            return this.HP;
        }

        public void Help()
        {
            Console.WriteLine(this.Name + "Help");
        }
    }

    public class roleActor : Actor
    {
        public int jiehunID { get; set; }


        public roleActor(AllyControlCenter control) : base(control)
        {

        }


    }


    public class guaiwuActor : Actor
    {
        public int mapID { get; set; }
        public guaiwuActor(AllyControlCenter control) : base(control)
        {

        }
    }


    public abstract class ActorBuilder
    {
        protected abstract Actor actor { get; set; }
        public abstract void BuildType();
        public abstract void BuildFaceModelFile();
        public abstract void BuildHP();
        public abstract void Buildlevel();
        public abstract void BuildA();
        public abstract void BuildName();

        public Actor CreateActor()
        {
            return actor;
        }
    }


    public class RoleBuilder : ActorBuilder
    {
        private static int buildIndex { get; set; } = 0;
        protected override Actor actor { get; set; }
        public RoleBuilder(AllyControlCenter control)
        {
            actor = new roleActor(control);
        }
        public override void BuildA()
        {
            actor.A = 10;
        }

        public override void BuildFaceModelFile()
        {
            actor.FaceModelFile = "c:\\111231231.model";
        }

        public override void BuildHP()
        {
            actor.HP = 100;
        }

        public override void Buildlevel()
        {
            actor.level = 1;
        }

        public override void BuildType()
        {
            actor.Type = "平民";
        }

        public override void BuildName()
        {
            actor.Name = "编号:" + buildIndex.ToString();
            buildIndex++;
        }


    }



    public class GuaiWuBuilder : ActorBuilder
    {
        private static int buildIndex { get; set; } = 0;
        protected override Actor actor { get; set; }
        public GuaiWuBuilder(AllyControlCenter control)
        {
            actor = new roleActor(control);
        }
        public override void BuildA()
        {
            actor.A = 1;
        }

        public override void BuildFaceModelFile()
        {
            actor.FaceModelFile = "c:\\guaiwu.model";
        }

        public override void BuildHP()
        {
            actor.HP = 1000;
        }

        public override void Buildlevel()
        {
            actor.level = 1;
        }

        public override void BuildType()
        {
            actor.Type = "怪物";
        }
        public override void BuildName()
        {
            actor.Name = "编号:" + buildIndex.ToString();
            buildIndex++;
        }


    }



    public class ActorController
    {

        public Actor Construct(ActorBuilder builder)
        {
            builder.BuildType();
            builder.BuildA();
            builder.BuildFaceModelFile();
            builder.BuildHP();
            builder.Buildlevel();
            builder.BuildName();

            return builder.CreateActor(); ;
        }
    }
}
