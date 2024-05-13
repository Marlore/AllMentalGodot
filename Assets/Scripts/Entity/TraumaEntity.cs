using AllMentalGodot.Assets.Entity;
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
        public abstract int TickCount { get;}
        private protected int Tick;
        private protected BodyPath _bodyPath;
        private protected Body _currentBody;

        public Trauma(BodyPath bodypath, Body currentBody)
        {
            _currentBody = currentBody;
            _bodyPath = bodypath;
            Tick = TickCount;
        }
        public void TemporaryExicutebleMethods()
        {
            if(Tick>0)
                Tick--;
            if (Tick == 0)
            {
                Exicute();
            }
        }
        public  virtual void Exicute(){}
    }
    public class IncisedWound: Trauma 
    {
        public override string Name => "Incised wound";
        public override int TickCount => 50;
        public IncisedWound(BodyPath bodypath, Body currentBody) : base(bodypath, currentBody) 
        {
            _currentBody.ActualBloodPressure += 5;
        }
        public override void Exicute()
        {
            base.Exicute();
            _currentBody.ActualBloodDrain -= 2;
            Tick= TickCount;
        }
    }
    public class StabbingWound : Trauma
    {
        public override string Name => "Incised wound";
        public override int TickCount => 50;
        private Organ organ;
        public StabbingWound(BodyPath bodypath, Body currentBody) : base(bodypath, currentBody) 
        {
            Random rand = new Random();
            int random = rand.Next(0, 101);
            organ = bodypath.organs.Find(x => random < x.DamageChance);
            _currentBody.ActualBloodPressure += 5;
        }
        public override void Exicute()
        {
            base.Exicute();
            _currentBody.ActualBloodDrain -= 2;            
            Tick = TickCount;
            if (organ != null)
                organ.ActualDuration -= 10;
        }
    }
    public class Poisoned : Trauma
    {
        public override string Name => "Injection mark";
        public override int TickCount => 1000;
        public Poisoned(BodyPath bodypath, Body currentBody) : base(bodypath, currentBody){}
        public override void Exicute()
        {
            base.Exicute();
            _currentBody.torso.Condition.Add(new HeartStop(_currentBody.torso, _currentBody));
            Tick = -1;
        }
    }
    public class HeartStop:Trauma
    {
        public override string Name => "Heart stop";
        public override int TickCount => 5;
        public HeartStop(BodyPath bodypath, Body currentBody) : base(bodypath, currentBody) { }
        public override void Exicute()
        {
            base.Exicute();
            _currentBody.ActualBloodPressure = 0;
            foreach (var organ in _currentBody.torso.organs)
                organ.ActualDuration -= 5;
            
            Tick = TickCount;
        }
    }

}
