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
        public void Counter()
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
                body.ActiveStatus.Add(new BloodLoss(body));
            }
        }
        public override void Exicute()
        {
            ExicuteVariation?.Invoke();
        }
        public void OrganWound()
        {
            organ.ActualDuration--;
        }
        public void BodyPathWound()
        {
        }

    }
    public class BloodLoss : Trauma
    {
        public override string Name => "Blood loss from "+ body.Name;
        public override int MaxTick => 2;
        public BodyPaths body;
        public BloodLoss(BodyPaths _body):base(_body)
        {
            this.body = _body;
        }
        public override void Exicute()
        {
            if (body.InBody.ActualBloodAmount > 0)
                body.InBody.ActualBloodAmount -= 2;
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
