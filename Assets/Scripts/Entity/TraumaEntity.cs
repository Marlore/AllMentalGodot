using AllMentalGodot.Assets.Entity;
using Entity.People;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Scripts.Entity.TraumaEntity
{
    public abstract class Trauma
    {
        public abstract string Name { get; }
        public abstract int MaxTick { get; }
        public int ActualTick;
        public IBody Path;
        public Trauma(IBody path) 
        {
            ActualTick = MaxTick;
            this.Path = path;
        }
        public Trauma(Health health)
        {
            ActualTick = MaxTick;
        }

        public virtual void Counter()
        {
            if (Path.ActualDuration <= 0)
                Stop();
            if(ActualTick>0)
                ActualTick--;
            else if(ActualTick==0)
            {
                ActualTick = MaxTick; 
                Exicute();
            }
        }
        public void Stop() => ActualTick = -1;
        public abstract void Exicute();
    }
    public class StabbingWound : Trauma
    {
        public override string Name => Path.Name+ " stabbing wound";
        public override int MaxTick => 4;
        public Action ExicuteVariation;
        public Organs organ;
        public BodyPaths body;
        public StabbingWound(IBody path) : base(path) 
        {
            if (typeof(Organs).IsAssignableFrom(Path.GetType()))
            {
                ExicuteVariation += OrganWound;
                organ = (Organs)Path;
            }
            else if (typeof(BodyPaths).IsAssignableFrom(Path.GetType()))
            {
                ExicuteVariation += BodyPathWound;
                body = (BodyPaths)Path;
                body.ActualDuration -= 10;
                body.ActiveStatus.Add(new BloodLoss(body,5));
            }
        }
        public override void Exicute()
        {
            ExicuteVariation?.Invoke();
        }
        public void OrganWound()
        {
            organ.ActualDuration-=5;
        }
        public void BodyPathWound()
        {
        }

    }
    public class CuttingWound : Trauma
    {
        public override string Name => Path.Name + " stabbing wound";
        public override int MaxTick => 4;
        public BodyPaths body;
        public CuttingWound(BodyPaths _body):base(_body)
        {
            this.body = _body;
            body.ActualDuration -= 20;
            body.ActiveStatus.Add(new BloodLoss(body, 2));
        }
        public override void Exicute()
        {}
    }
    public class BloodLoss : Trauma
    {
        public override string Name => "Blood loss from "+ body.Name;
        public override int MaxTick => 2;
        public BodyPaths body;
        public int Tight;
        public BloodLoss(BodyPaths _body, int tight):base(_body)
        {
            this.body = _body;
            Tight = tight;
        }
        public override void Exicute()
        {
            if (body.InBody.ActualBloodAmount > 0)
                body.InBody.ActualBloodAmount -= Tight;
        }
    }
    public class BrainDead : Trauma
    {
        public override string Name => "Brain dead";
        public override int MaxTick => 1;
        public Health health;
        public BrainDead(Health _health) : base(_health)
        {
            health = _health;
        }
        public override void Counter()
        {
            if (ActualTick > 0)
                ActualTick--;
            else if (ActualTick == 0)
            {
                ActualTick = MaxTick;
                Exicute();
            }
        }
        public override void Exicute()
        {
            if (health.ActualBloodPressure > 0)
                health.ActualBloodPressure = 0;
            if (health.ActualRespiratoryRate != 0)
                health.ActualRespiratoryRate = 0;
            Stop();
        }
    }
    public class HeartStop:Trauma
    {
        public override string Name => "Heart stop";
        public override int MaxTick => 1;
        public Health health;
        public HeartStop(Health _health) : base(_health)
        {
            health = _health;
        }
        public override void Counter()
        {
            if (ActualTick > 0)
                ActualTick--;
            else if (ActualTick == 0)
            {
                ActualTick = MaxTick;
                Exicute();
            }
        }
        public override void Exicute()
        {
            if(health.ActualBloodPressure>0)
                health.ActualBloodPressure = 0;
            Stop();
        }
       
    }
    public class OrganFailure : Trauma
    {
        public override string Name =>organ.Name + " failure";
        public override int MaxTick => 2;
        public Organs organ;
        public OrganFailure(Organs _organ) : base(_organ)
        {
            this.organ = _organ;
            Path = organ;
        }
        public override void Exicute() 
        {
            organ.ActualDuration-=10;
        }
    }

}
