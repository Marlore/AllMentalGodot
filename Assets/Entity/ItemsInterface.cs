using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.DamageLibrary;

namespace Entity.ItemLibrary
{
    public abstract class Items
    {
        public abstract string Name { get; }
        public List<Guid> FingerPrints = new List<Guid>();
        public abstract List<DamageType> TypeOfDamage { get; }
        public abstract int NoiseRate { get; }
        public abstract int Severity { get; }
    }
    public class Knife : Items
    {
        public override string Name => "Knife";
        public override List<DamageType> TypeOfDamage => new List<DamageType>() {DamageType.sharp, DamageType.slicing };
        public override int NoiseRate => 0;
        public override int Severity => 1;
    }
    public class Statue : Items
    {
        public override string Name => "Statue";
        public override List<DamageType> TypeOfDamage => new List<DamageType>() { DamageType.flat };
        public override int NoiseRate => 1;
        public override int Severity => 2;
    }
    public class Pistol : Items
    {
        public override string Name => "Pistol";
        public override List<DamageType> TypeOfDamage => new List<DamageType>() { DamageType.gunshot };
        public override int NoiseRate => 4;
        public override int Severity => 1;
    }
    public class SilentPistol : Items
    {
        public override string Name => "Silent pistol";
        public override List<DamageType> TypeOfDamage => new List<DamageType>() { DamageType.gunshot };
        public override int NoiseRate => 1;
        public override int Severity => 1;
    }
    public class Bat : Items
    {
        public override string Name => "Bat";
        public override List<DamageType> TypeOfDamage => new List<DamageType>() { DamageType.flat};
        public override int NoiseRate => 1;
        public override int Severity => 2;
    }
    public class ShotGun : Items
    {
        public override string Name => "ShotGun";
        public override List<DamageType> TypeOfDamage => new List<DamageType>() { DamageType.gunshot };
        public override int NoiseRate => 5;
        public override int Severity => 3;
    }
    public class FryingPan : Items
    {
        public override string Name => "Frying Pan";
        public override List<DamageType> TypeOfDamage => new List<DamageType>() { DamageType.flat };
        public override int NoiseRate => 1;
        public override int Severity => 1;
    }
    public class Wrench : Items
    {
        public override string Name => "Wrench";
        public override List<DamageType> TypeOfDamage => new List<DamageType>() { DamageType.flat };
        public override int NoiseRate => 1;
        public override int Severity => 1;
    }

}
