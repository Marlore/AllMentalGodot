using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AllMentalGodot.Assets.Entity
{
    public enum DamageType
    {
        flat, sharp, slicing, temp
    }
    public abstract class Damage
    {
        public abstract string Name { get;}
        public abstract void TemporaryEffect();
    }
    public class DamageFactory
    {
        public Damage Create(DamageType damageType, int seriousness)
        {
            switch (damageType)
            {
                case DamageType.flat:
                    return FlatDamageResult(seriousness);                    
                case DamageType.sharp:
                    return SharpDamageResult(seriousness);
                case DamageType.slicing:
                    return SlicingDamageResult(seriousness);
                case DamageType.temp:
                    return TempDamageResult(seriousness);
                default:
                    return null;

            }
        }
        public Damage FlatDamageResult(int seriousness)
        {
            return new Bruise();
        }
        public Damage SharpDamageResult(int seriousness)
        {
            return new Bruise();
        }
        public Damage SlicingDamageResult(int seriousness)
        {
            return new Bruise();
        }
        public Damage TempDamageResult(int seriousness)
        {
            return new Bruise();
        }
    }
    public class Bruise: Damage
    {
        public override string Name=> "Bruise";

        public override void TemporaryEffect() {
        }
    }
    public class Hematoma : Damage
    {
        public override string Name => "Hematoma";

        public override void TemporaryEffect()
        {
        }
    }
    public class BoneFracture : Damage
    {
        public override string Name => "Bone fracture";

        public override void TemporaryEffect()
        {
        }
    }
    public class Scratch : Damage
    {
        public override string Name => "Scratch";

        public override void TemporaryEffect()
        {
        }
    }

}
