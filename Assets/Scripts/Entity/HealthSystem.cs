using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace AllMentalGodot.Assets.Entity
{
    public abstract class BodyPath
    {
        public abstract string Name { get; }
        public int ActualDuration { get; } 
        public abstract int MaxDuration { get; }
        public Action Condition;
        public BodyPath() 
        {
            ActualDuration = MaxDuration;
        }   
    }
    public abstract class Organ
    {
        public abstract string Name { get; }
        public int ActualDuration { get; }
        public abstract int MaxDuration { get; }
        public abstract int DamageChance {get; }
        public Organ()
        {
            ActualDuration = MaxDuration;
        }
    }
    public class Heart : Organ
    {
        public override string Name => "Heart";
        public override int MaxDuration => 10;
        public override int DamageChance => 5;
    }
    public class Liver : Organ
    {
        public override string Name => "Liver";
        public override int MaxDuration => 50;
        public override int DamageChance => 20;
    }
    public class Guts : Organ
    {
        public override string Name => "Guts";
        public override int MaxDuration => 60;
        public override int DamageChance => 30;
    }
    public class Kidneys : Organ
    {
        public override string Name => "Kidneys";
        public override int MaxDuration => 40;
        public override int DamageChance => 10;
    }
    public class Lungs : Organ
    {
        public override string Name => "Lungs";
        public override int MaxDuration => 30;
        public override int DamageChance => 25;
    }
    public class Throat : Organ
    {
        public override string Name => "Throat";
        public override int MaxDuration => 15;
        public override int DamageChance => 15;
    }
    public class Brain : Organ
    {
        public override string Name => "Brain";
        public override int MaxDuration => 45;
        public override int DamageChance => 90;
    }

    public class Head: BodyPath 
    {
        public override string Name => "Head";
        public override int MaxDuration => 30;
        public List<Organ> organs = new List<Organ>();
        public Head():
            base()
        {
            organs.Add(new Brain());
        }
    }
    public class Neck: BodyPath
    {
        public override string Name => "Neck";
        public override int MaxDuration =>15;
        public List<Organ> organs = new List<Organ>();
        public Neck() :
            base()
        {
            organs.Add(new Throat());
        }
    }
    public class Torso: BodyPath
    {
        public override string Name => "Torso";
        public override int MaxDuration => 60;
        public List<Organ> organs = new List<Organ>();
        public Torso() :
            base()
        {
            organs.Add(new Heart());
            organs.Add(new Liver());
            organs.Add(new Guts());
            organs.Add(new Kidneys());
            organs.Add(new Lungs());
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
        public Head head = new Head();
        public Neck neck = new Neck();
        public Torso torso= new Torso();
        public RightArm rightArm = new RightArm();
        public LeftArm leftArm = new LeftArm();
        public RightLeg rightLeg = new RightLeg();
        public LeftLeg leftLeg = new LeftLeg();
        public List<BodyPath> BodyPathsList = new List<BodyPath>();
        public Body()
        {
            BodyPathsList.Add(head);
            BodyPathsList.Add(neck);
            BodyPathsList.Add(torso);
            BodyPathsList.Add(rightArm);
            BodyPathsList.Add(leftArm);
            BodyPathsList.Add(rightLeg);
            BodyPathsList.Add(leftLeg);
        }
    }
}
