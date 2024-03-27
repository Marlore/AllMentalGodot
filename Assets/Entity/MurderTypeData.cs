using Entity.ItemLibrary;
using Entity.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Murder
{
    public enum ReasonType
    {
        pleasure,
        hatred, 
        jealousy,
        envies, 
        hiring
    }
    public abstract class MurderTypeData
    {
        public abstract Items Weapon { get; }
        public string ReasonToString;
        public abstract ReasonType Reason { get; }
        public Person HuntTarget;
    }
    public class Maniac : MurderTypeData
    {
        public override Items Weapon => ChooseWeapon();
        public override ReasonType Reason => ReasonType.pleasure;
        public _sex SexHunt;
        public (int from, int to) AgeHunt;

        public Items ChooseWeapon()
        {
            Random rand = new Random();
            int weaponIndex = rand.Next(0,3);
            switch (weaponIndex)
            {
                case 0:
                    return new Bat();
                case 1:
                    return new Knife();
                case 2:
                    return new Syringe();
                default: return null;

            }
        }
    }
    public class Killer : MurderTypeData
    {
        public override Items Weapon => new SilentPistol();
        public override ReasonType Reason => ReasonType.hiring;
    }
    public class Lover : MurderTypeData
    {
        public override Items Weapon => new SilentPistol();
        public override ReasonType Reason => ReasonType.jealousy;
    }
    public class Envious : MurderTypeData
    {
        public override Items Weapon => new SilentPistol();
        public override ReasonType Reason => ReasonType.envies;
    }
    public class Hater : MurderTypeData
    {
        public override Items Weapon => new SilentPistol();
        public override ReasonType Reason => ReasonType.hatred;
    }



}
