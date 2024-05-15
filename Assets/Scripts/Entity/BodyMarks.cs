using AllMentalGodot.Assets.Entity;
using Scripts.Entity.TraumaEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.BodyMarks
{
    public abstract class TraumaPattern
    {
        public abstract string Name { get; }
        public List<Trauma> traumas = new List<Trauma>();
        public Body body;
        public BodyPath bodyPath;
        public Trauma CurrentTrauma;
        
        public TraumaPattern(Body _body, BodyPath _bodyPath)
        {}
    }
    public class StabWound: TraumaPattern
    {
        public override string Name => "Stab wound";
        public StabWound(Body _body, BodyPath _bodyPath):base(_body, _bodyPath)
        { 
            body = _body;
            bodyPath = _bodyPath;
            var trauma = new PenetratinWound(body, bodyPath);
            traumas.AddRange(trauma.ReturnTrauma());
        }
    }
}
