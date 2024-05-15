using AllMentalGodot.Assets.Entity;
using Entity.People;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.Entity.TraumaEntity
{
    public abstract class Trauma
    { 
        public abstract string Name { get; }
        public abstract int Ticks { get; }
        public int ActualTick;
        public Body CurrentBody;
        public BodyPath CurrentBodyPath;
        private protected List<Trauma> RelatedInjuries= new List<Trauma>();
        public Trauma(Body _currentBody, BodyPath _currentBodyPath) 
        {
            CurrentBody = _currentBody;
            CurrentBodyPath = _currentBodyPath;
            ActualTick = Ticks;
        }
        public Trauma(Organ _organ) { }
        public Trauma(Person person){}
        public virtual void TemporaryExicutebleMethods()
        {
            if (ActualTick > 0)
                ActualTick--;
            if( ActualTick == 0)
            {
                Exicute();
                ActualTick = Ticks;
            }
        }
        public virtual void Exicute()
        {}
        public List<Trauma> ReturnTrauma()
        {
            RelatedInjuries.Add(this);
            return RelatedInjuries;
        }
    }
    public class PenetratinWound : Trauma
    {
        public override string Name => "Penetrating wound";
        public override int Ticks => 5;
        public PenetratinWound(Body _currentBody, BodyPath _currentBodyPath) :base(_currentBody, _currentBodyPath)
        {
            Random rand = new Random();
            int randomorgan = rand.Next(0,101);
            CurrentBody.ActualBloodPressure += 10;
            CurrentBodyPath.ActualDuration -= 20;
            var currentorgan =CurrentBodyPath.organs.Find(x => x.DamageChance >= randomorgan);
            if (currentorgan != null)
                RelatedInjuries.Add(new OrganDamage(currentorgan));
        }
        public override void Exicute()
        {
            base.Exicute();
            CurrentBody.ActualBloodDrain-=2;
        }
    }
    public class Laceration: Trauma
    {
        public override string Name => "Penetrating wound";
        public override int Ticks => 5;
        public Laceration(Body _currentBody, BodyPath _currentBodyPath) : base(_currentBody, _currentBodyPath)
        {
            CurrentBody.ActualBloodPressure += 10;
            CurrentBodyPath.ActualDuration -= 20;
        }
        public override void Exicute()
        {
            base.Exicute();
            CurrentBody.ActualBloodDrain -= 4;
        }
    }
    public class OrganDamage : Trauma
    {
        public override string Name => organ.Name + " damage";
        public override int Ticks => 5;
        public Organ organ;
        public OrganDamage(Organ _organ) : base(_organ)
        {
            organ = _organ;
        }
        public override void Exicute()
        {
            base.Exicute();
            if(organ.ActualDuration>0)
                organ.ActualDuration--;
        }
    }
    public class BrainDead : Trauma
    {
        public override string Name => organ.Name + "Brain dead";
        public override int Ticks => 0;
        public Organ organ;
        public BrainDead(Person person) : base(person) => person.Death();
        public override void TemporaryExicutebleMethods()
        {
            if (ActualTick > 0)
                ActualTick--;
            if (ActualTick == 0)
            {
                Exicute();
                ActualTick = -1;
            }
        }

    }
    public class HeartStop:Trauma
    {
        public override string Name => organ.Name + "Heart stop";
        public override int Ticks => 0;
        public Organ organ;
        public HeartStop(Person person) : base(person) 
        {
            person.Health.ActualBloodPressure = 0;
        }
        public override void TemporaryExicutebleMethods()
        {
            if (ActualTick > 0)
                ActualTick--;
            if (ActualTick == 0)
            {
                Exicute();
                ActualTick = -1;
            }
        }
    }
    public class InternalOrgansFailure: Trauma
    {
        public override string Name => organ.Name + "Multiple organ failure";
        public override int Ticks => 1;
        public Organ organ;
        public InternalOrgansFailure(Person person) : base(person)
        {
            foreach (var organ in person.Health.torso.organs)
                person.Health.torso.Condition.Add(new OrganDamage(organ));
            foreach (var organ in person.Health.head.organs)
                person.Health.head.Condition.Add(new OrganDamage(organ));
        }
    }


    public class OrganDamageFactory
    {
        public Trauma GetOrganFailure(OrgansEnum organ, Person person)
        {
            switch (organ)
            {
                case OrgansEnum.brain:
                    return new BrainDead(person);
                case OrgansEnum.heart:
                    return new HeartStop(person);
                case OrgansEnum.liver:
                    return new BrainDead(person);
                case OrgansEnum.throat:
                    return new BrainDead(person);
                case OrgansEnum.guts:
                    return new BrainDead(person);
                case OrgansEnum.kidneys: 
                    return new BrainDead(person);
                case OrgansEnum.lungs: 
                    return new BrainDead(person);
                default:
                    return null;
            }
        }
    }
    

}
