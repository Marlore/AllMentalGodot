using Entity.BodyMarks;
using Entity.People;
using Scripts.Entity.TraumaEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AllMentalGodot.Assets.Entity
{
    public enum OrgansEnum
    {
        heart, liver, guts, kidneys, lungs, throat, brain
    }
    public abstract class BodyPath
    {
        public abstract string Name { get; }
        public int ActualDuration;
        
        public abstract int MaxDuration { get; }
        public List<Trauma> Condition = new List<Trauma>();
        public List<TraumaPattern> BodyMarks = new List<TraumaPattern>();
        public List<Organ> organs= new List<Organ>();
        public BodyPath(Person currentPerson) 
        {
            ActualDuration = MaxDuration;
        }
        public BodyPath()
        {
            ActualDuration = MaxDuration;
        }

    }
    public abstract class Organ
    {
        public abstract string Name { get; }
        private int _actualduration;
        public abstract OrgansEnum OrganType { get; }
        public Person currentPerson;
        public int ActualDuration { get { return _actualduration; } set {
                if (value <= 0)
                {
                    _actualduration = 0;
                }
                    
                else _actualduration = value;
            } }
        // сетеры гетеры
        public abstract int MaxDuration { get; }
        public abstract int DamageChance {get; }
        public Organ(Person currentPerson)
        {

            ActualDuration = MaxDuration;
            this.currentPerson = currentPerson;
        }
    }
    public class Heart : Organ
    {
        public override string Name => "Heart";
        public override int MaxDuration => 10;
        public override int DamageChance => 5;
        public override OrgansEnum OrganType => OrgansEnum.heart;
        public Heart(Person currentPerson):base(currentPerson) { }
    }
    public class Liver : Organ
    {
        public override string Name => "Liver";
        public override int MaxDuration => 50;
        public override int DamageChance => 20;
        public override OrgansEnum OrganType => OrgansEnum.liver;
        public Liver(Person currentPerson) : base(currentPerson) { }
    }
    public class Guts : Organ
    {
        public override string Name => "Guts";
        public override int MaxDuration => 60;
        public override int DamageChance => 30;
        public override OrgansEnum OrganType => OrgansEnum.guts;
        public Guts(Person currentPerson) : base(currentPerson) { }
    }
    public class Kidneys : Organ
    {
        public override string Name => "Kidneys";
        public override int MaxDuration => 40;
        public override int DamageChance => 10;
        public override OrgansEnum OrganType => OrgansEnum.kidneys;
        public Kidneys(Person currentPerson) : base(currentPerson) { }
    }
    public class Lungs : Organ
    {
        public override string Name => "Lungs";
        public override int MaxDuration => 30;
        public override int DamageChance => 25;
        public override OrgansEnum OrganType => OrgansEnum.lungs;
        public Lungs(Person currentPerson) : base(currentPerson) { }
    }
    public class Throat : Organ
    {
        public override string Name => "Throat";
        public override int MaxDuration => 15;
        public override int DamageChance => 15;
        public override OrgansEnum OrganType => OrgansEnum.throat;
        public Throat(Person currentPerson) : base(currentPerson) { }
    }
    public class Brain : Organ
    {
        public override string Name => "Brain";
        public override int MaxDuration => 45;
        public override int DamageChance => 90;
        public override OrgansEnum OrganType => OrgansEnum.brain;
        public Brain(Person currentPerson) : base(currentPerson) { }

    }

    public class Head: BodyPath 
    {
        public override string Name => "Head";
        public override int MaxDuration => 30;
        public Head(Person currentPerson) :
            base(currentPerson)
        {
            organs.Add(new Brain(currentPerson));
        }
    }
    public class Neck: BodyPath
    {
        public override string Name => "Neck";
        public override int MaxDuration =>15;
        public Neck(Person currentPerson) :
            base(currentPerson)
        {
            organs.Add(new Throat(currentPerson));
        }
    }
    public class Torso: BodyPath
    {
        public override string Name => "Torso";
        public override int MaxDuration => 60;
        public Torso(Person currentPerson) :
            base(currentPerson)
        {
            organs.Add(new Heart(currentPerson));
            organs.Add(new Liver(currentPerson));
            organs.Add(new Guts(currentPerson));
            organs.Add(new Kidneys(currentPerson));
            organs.Add(new Lungs(currentPerson));
        }

    }
    public class RightArm: BodyPath
    {
        public override string Name => "Right Arm";
        public override int MaxDuration => 40;
    }
    public class LeftArm : BodyPath
    {
        public override string Name => "Left Arm";
        public override int MaxDuration => 40;
    }
    public class RightLeg : BodyPath
    {
        public override string Name => "Right Leg";
        public override int MaxDuration => 45;
    }
    public class LeftLeg : BodyPath
    {
        public override string Name => "Left Leg";
        public override int MaxDuration => 45;
    }
    public class Body
    {
        public Person person;
        public int NormalBloodDrain =100;
        public int NormalBloodPressure =100;
        public int NormalBreath = 100;
        public int ActualBloodDrain;
        public int ActualBloodPressure;
        public int ActualBreath;
        public Head head;
        public Neck neck;
        public Torso torso;
        public RightArm rightArm = new RightArm();
        public LeftArm leftArm = new LeftArm();
        public RightLeg rightLeg = new RightLeg();
        public LeftLeg leftLeg = new LeftLeg();
        public List<BodyPath> BodyPathsList = new List<BodyPath>();
        public Body(Person _person)
        {
            ActualBloodDrain =NormalBloodDrain;
            ActualBloodPressure =NormalBloodPressure;
            ActualBreath =NormalBreath;

            person = _person;

            head = new Head(person);
            neck = new Neck(person);
            torso = new Torso(person);
            BodyPathsList.Add(head);
            BodyPathsList.Add(neck);
            BodyPathsList.Add(torso);
            BodyPathsList.Add(rightArm);
            BodyPathsList.Add(leftArm);
            BodyPathsList.Add(rightLeg);
            BodyPathsList.Add(leftLeg);
        }
        public void TemporaryHealthStatuses()
        {
            foreach (BodyPath path in BodyPathsList)
                foreach(var trauma in path.Condition)
                    trauma?.TemporaryExicutebleMethods();
            foreach(BodyPath path in BodyPathsList)
                foreach(Organ organ in path.organs)
                    if(organ.ActualDuration <= 0)
                        person.Death();
            if (ActualBloodDrain <= 0)
                person.Death();
        }
        
    }
}
