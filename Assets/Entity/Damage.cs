using Entity.ItemLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.DamageLibrary
{
    public enum DamageType
    {
        flat, sharp, slicing, temp, poison, gunshot
    }
    public abstract class Damage
    {
        public abstract string Name { get;}
        public abstract void TemporaryEffect();
    }
    public class DamageFactory
    {
        public Damage Create(Items item)
        {
            switch (item.TypeOfDamage)
            {
               

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
