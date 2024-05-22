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
   
    public interface IBody
    {
        public string Name { get; }
        public int MaxDuration { get; }
        public int ActualDuration { get; set; }
        public int DamageChance { get; }
    }
    public abstract class Organs : IBody
    {
        public abstract string Name { get; }
        public abstract int MaxDuration { get; }
        public abstract int ActualDuration { get; set; }
        public abstract int DamageChance { get; }
        public BodyPaths InPath;
        public Organs(BodyPaths inPath)
        {
            InPath = inPath;
        }

    }
    public abstract class BodyPaths : IBody
    {
        public abstract string Name { get; }
        public abstract int MaxDuration { get; }
        public abstract int ActualDuration { get; set; }
        public abstract int DamageChance { get; }
        public List<Organs> PathOrgans = new List<Organs>();
        public Health InBody;
        public List<Trauma> ActiveStatus = new List<Trauma>();
        public BodyPaths(Health inBody)
        {
            InBody = inBody;
        }
    }
    public class HeadPath : BodyPaths
    {
        public override string Name => "Head";
        public override int MaxDuration => 30;
        public override int ActualDuration { get; set; }
        public override int DamageChance => 10;
        public HeadPath(Health inBody):base(inBody)
        {
            ActualDuration= MaxDuration;
        }
    }
    public class TorsoPath:BodyPaths
    {
        public override string Name => "Torso";
        public override int MaxDuration => 40;
        public override int ActualDuration { get; set; }
        public override int DamageChance => 20;
        public TorsoPath(Health inBody) : base(inBody)
        {
            ActualDuration = MaxDuration;
        }
    }
    public class StomachPath : BodyPaths
    {
        public override string Name => "Stomach";
        public override int MaxDuration => 40;
        public override int ActualDuration { get; set; }
        public override int DamageChance => 40;
        public StomachPath(Health inBody) : base(inBody)
        {
            ActualDuration = MaxDuration;
        }
    }
    public class LegPath : BodyPaths
    {
        public override string Name => "Leg";
        public override int MaxDuration => 40;
        public override int ActualDuration { get; set; }
        public override int DamageChance => 70;
        public LegPath(Health inBody) : base(inBody)
        {
            ActualDuration = MaxDuration;
        }
    }
    public class ArmPath : BodyPaths
    {
        public override string Name => "Arm";
        public override int MaxDuration => 40;
        public override int ActualDuration { get; set; }
        public override int DamageChance => 70;
        public ArmPath(Health inBody) : base(inBody)
        {
            ActualDuration = MaxDuration;
        }
    }
    public class BrainOrgan : Organs
    {
        public override string Name => "Brain";
        public override int MaxDuration => 10;
        private int _actualDuration;
        public override int ActualDuration
        {
            get
            {
                return _actualDuration;
            }
            set
            {
                if (value > 0)
                    _actualDuration = value;
                else
                {
                    _actualDuration = 0;
                    this.InPath.InBody.BrainDead();
                }
            }
        }
        public override int DamageChance => 15;
        public BrainOrgan(BodyPaths inPath):base(inPath)
        {
            ActualDuration = MaxDuration;
        }
    }
    public class HeartOrgan : Organs
    {
        public override string Name => "Heart";
        public override int MaxDuration => 15;
        private int _actualDuration;
        public override int ActualDuration { get 
            { 
                return _actualDuration;
            } set 
            {
                if(value>0)
                    _actualDuration = value;
                else
                {
                    _actualDuration = 0;
                    this.InPath.InBody.HeartStop();
                }
            } }
        public override int DamageChance => 15;
        public HeartOrgan(BodyPaths inPath) : base(inPath)
        {
            ActualDuration = MaxDuration;
        }
    }
    public class LungsOrgan : Organs
    {
        public override string Name => "Lungs";
        public override int MaxDuration => 40;
        public override int ActualDuration { get; set; }
        public override int DamageChance => 30;
        public LungsOrgan(BodyPaths inPath) : base(inPath)
        {
            ActualDuration = MaxDuration;
        }
    }
    public class LiverOrgan : Organs
    {
        public override string Name => "Liver";
        public override int MaxDuration => 40;
        public override int ActualDuration { get; set; }
        public override int DamageChance => 20;
        public LiverOrgan(BodyPaths inPath) : base(inPath)
        {
            ActualDuration = MaxDuration;
        }
    }
    public class KidneysOrgan : Organs
    {
        public override string Name => "Kidneys";
        public override int MaxDuration => 40;
        public override int ActualDuration { get; set; }
        public override int DamageChance => 30;
        public KidneysOrgan(BodyPaths inPath) : base(inPath)
        {
            ActualDuration = MaxDuration;
        }
    }
    public class GutsOrgan : Organs
    {
        public override string Name => "Guts";
        public override int MaxDuration => 40;
        public override int ActualDuration { get; set; }
        public override int DamageChance => 60;
        public GutsOrgan(BodyPaths inPath) : base(inPath)
        {
            ActualDuration = MaxDuration;
        }
    }
    public class Health
    {
        public int MaxBloodAmount= 100;
        private int _actualBloodAmount;
        public int ActualBloodAmount { get 
            {
                return _actualBloodAmount;
            }
            set
            {
                if (value > 0)
                    _actualBloodAmount = value;
                else if(value<=0)
                {
                    _actualBloodAmount = 0;
                    CompleteBloodLoss();
                }
            }
        }

        public int MaxBloodPressure=100;
        private int _actualBloodPressure;
        public int ActualBloodPressure
        {
            get
            {
                return _actualBloodPressure;
            }
            set
            {
                if (value > 0)
                    _actualBloodPressure = value;
                else if (value <= 0)
                {
                    _actualBloodPressure = 0;
                    StopOfBloodCirculation();
                }
            }
        }
        public int MaxRespiratoryRate = 100;
        public int ActualRespiratoryRate;

        public Person CurrentPerson;

        public HeadPath Head;
        public TorsoPath Torso;
        public StomachPath Stomach;
        public ArmPath LeftArm;
        public ArmPath RightArm;
        public LegPath LeftLeg;
        public LegPath RightLeg;

        public BrainOrgan Brain;
        public HeartOrgan Heart;
        public LungsOrgan Lungs;
        public LiverOrgan Liver;
        public KidneysOrgan Kidneys;
        public GutsOrgan Guts;

        public List<BodyPaths> BodyPathsList;
        public Health()
        {
            ActualBloodAmount = MaxBloodAmount;
            ActualBloodPressure = MaxBloodPressure;
            ActualRespiratoryRate = MaxRespiratoryRate;

            Head = new HeadPath(this);
            Brain = new BrainOrgan(Head);
            Head.PathOrgans.AddRange(new List<Organs>{Brain});

            Torso = new TorsoPath(this);
            Heart = new HeartOrgan(Torso);
            Lungs = new LungsOrgan(Torso);
            Torso.PathOrgans.AddRange(new List<Organs> { Heart,Lungs });

            Stomach = new StomachPath(this);
            Liver = new LiverOrgan(Stomach);
            Kidneys =new KidneysOrgan(Stomach);
            Guts = new GutsOrgan(Stomach);
            Stomach.PathOrgans.AddRange(new List<Organs> { Liver, Kidneys, Guts });

            LeftArm = new ArmPath(this);
            RightArm = new ArmPath(this);

            LeftLeg = new LegPath(this);
            RightLeg = new LegPath(this);

            BodyPathsList = new List<BodyPaths> { Head, Torso,Stomach,LeftArm,RightArm,LeftLeg,RightLeg };
        }
        public void UpdateHealth()
        {

            foreach (BodyPaths path in BodyPathsList)
            {
                var pathTraumas = path.ActiveStatus.ToList();
                foreach (var trauma in pathTraumas)
                    trauma.Counter();
            }

        }
        
        public void StopOfBloodCirculation()
        {
            ActualRespiratoryRate = 0;
            if(!Torso.ActiveStatus.Contains(new HeartStop(this)))
                Torso.ActiveStatus.Add(new HeartStop(this));
            foreach (BodyPaths path in BodyPathsList)
                foreach(var _organ in path.PathOrgans)
                    if(!path.ActiveStatus.OfType<OrganFailure>().Any(x=>x.organ== _organ)) 
                        path.ActiveStatus.Add(new OrganFailure(_organ));
        }
        public void CompleteBloodLoss()
        {
            ActualBloodPressure = 0;
            foreach (BodyPaths path in BodyPathsList)
                foreach (var _organ in path.PathOrgans)
                    if (!path.ActiveStatus.OfType<OrganFailure>().Any(x => x.organ == _organ))
                        path.ActiveStatus.Add(new OrganFailure(_organ));

        }
        public void HeartStop()
        {
            Torso.ActiveStatus.Add(new HeartStop(this));
        }
        public void BrainDead()
        {
            Head.ActiveStatus.Add(new BrainDead(this));          
        }

        public void KnifeHitWound()
        {
            Random HitChance = new Random();
            var ListPaths = BodyPathsList.FindAll(x => x.DamageChance < HitChance.Next(1, 101));
            if (ListPaths.Any())
            {
                var Path = ListPaths[HitChance.Next(0, ListPaths.Count())];
                var organsList = Path.PathOrgans.FindAll(x => x.DamageChance < HitChance.Next(1, 101));
                int Type = HitChance.Next(0, 2);
                if(Type == 1)
                {
                    Path.ActiveStatus.Add(new StabbingWound(Path));
                    if (organsList.Any())
                    {
                        var organ = organsList[HitChance.Next(0, organsList.Count())];
                        Path.ActiveStatus.Add(new StabbingWound(organ));
                    }
                }
                else
                {
                    Path.ActiveStatus.Add(new CuttingWound(Path));
                }
                
            }
        }

    }

}
