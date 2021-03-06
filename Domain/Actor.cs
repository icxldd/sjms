﻿using sjms._Composite;
using sjms.Inteface;
using sjms.Strategy;
using sjms.Subject;
using System;
using System.Collections.Generic;
using System.Text;
/*
    1.单例
    2.工厂
    3.建造者
    4.观察者
 */
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

        private int mp;

        public IMP Discount { get; set; }
        public int MP
        {
            get
            {
                return Discount.CalculateMP(mp);
            }
            set
            {
                mp = value;
            }
        }


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


        public abstract void BKey();

        public virtual void BeAttacked()
        {
            //     Console.WriteLine(this.Name + "在被攻击");
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

        public Folder beibao { get; set; }


        public roleActor(AllyControlCenter control) : base(control)
        {
            beibao = new Folder("背包");
            ResFile a = new ResFile("a");
            ResFile b = new ResFile("b");
            ResFile c = new ResFile("c");
            beibao.Add(a);
            beibao.Add(b);
            beibao.Add(c);
        }
        public void checkPack()
        {
            beibao.KillVirus();
        }

        public override void BKey()
        {
            Console.WriteLine("renwu B Key");
        }
    }


    public class guaiwuActor : Actor
    {
        public int mapID { get; set; }
        public guaiwuActor(AllyControlCenter control) : base(control)
        {

        }
        public override void BKey()
        {
            Console.WriteLine("guaiwu B Key");
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
