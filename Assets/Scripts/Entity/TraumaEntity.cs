using AllMentalGodot.Assets.Entity;
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
        public void TemporaryExicutebleMethods()
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
        public override int Ticks => 10;
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
            CurrentBody.ActualBloodDrain--;
        }
    }
    public class OrganDamage : Trauma
    {
        public override string Name => organ.Name + " damage";
        public override int Ticks => 10;
        public Organ organ;
        public OrganDamage(Organ _organ) : base(_organ)
        {
            organ = _organ;
        }
        public override void Exicute()
        {
            base.Exicute();
            organ.ActualDuration--;
        }
    }

}
