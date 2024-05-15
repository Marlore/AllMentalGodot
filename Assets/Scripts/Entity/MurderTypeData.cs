using Engine.PlayerEngine;
using Entity.DamageLibrary;
using Entity.ItemLibrary;
using Entity.People;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.MurderEntity
{
    public enum ReasonType
    {
        pleasure,
        hatred, 
        jealousy,
        envies, 
        hiring
    }
    public class MurderOrder
    {
        public Person Сustomer;
        public Person Victim;
        public MurderOrder(Person сustomer, Person victim)
        {
            Сustomer = сustomer;
            Victim = victim;
        }
        public void MakeOrder() => PlayerInfo.CurrentCity.BlackMarketOrders.Add(this);

    }
    public abstract class MurderTypeData
    {
        public abstract DamageType WeaponType { get; }
        public abstract string ReasonToString { get; }
        public Items Weapon;
        public abstract ReasonType Reason { get; }
        public Person HuntTarget;
        public Person Murder;
        public abstract void FindVictim();
        public MurderTypeData(Person murder) 
        {
            Murder = murder;
            PlayerInfo.CurrentCity.CityMurders.Add(this);
            Murder.Inventory.Add(new Knife());
            Murder.Inventory.Add(new Statue());
            Murder.Live += MurderLive;
        }
        public void MurderLive()
        {
            if(Weapon == null)
                FindWeapon();
            if (HuntTarget == null)
                FindVictim();
            if (Weapon != null && HuntTarget != null)
                ChaseVictim();
        }
        public void FindWeapon()
        {
            var weapon = Murder.Inventory.Find(x => x.TypeOfDamage.Contains(WeaponType));
            if (weapon == null)
            {
                weapon = Murder.CurrentLocation.ItemsInLocation.Find(x => x.TypeOfDamage.Contains(WeaponType));
                if (weapon != null)
                {
                    Murder.CurrentLocation.ItemsInLocation.Remove(weapon);
                    Murder.Inventory.Add(weapon);
                }
            }
            Weapon = weapon;
        }
        public void ChaseVictim()
        {
            if(Weapon!=null)
            {
                Murder.Destination = HuntTarget.CurrentLocation;
                if (Murder.CurrentLocation.PeopleInside.Count == 2 && Murder.CurrentLocation.PeopleInside.Contains(HuntTarget.Id)) {
                    HuntTarget.Death();
                    HuntTarget = null;
                }
            }


        }
           
    }
    public class Maniac : MurderTypeData
    {
        public override DamageType WeaponType => ChooseWeapon();
        public override ReasonType Reason => ReasonType.pleasure;
        public override string ReasonToString => "I did it out of pleasure";
        public _sex SexHunt;
        public (int from, int to) AgeHunt;
        public Maniac(Person murder)
            : base(murder)
        {
            Random rand = new Random();
            AgeHunt.from = rand.Next(7, 61);
            AgeHunt.to = AgeHunt.from + 5;
            int sex = rand.Next(0,2);
            if(sex == 0)
                SexHunt = _sex.Male;
            else if(sex == 1) 
                SexHunt = _sex.Female;
        }

        public override void FindVictim()
        {
            if (HuntTarget == null)
            {
                foreach(var potentialVictim in Murder.CurrentLocation.PeopleInside)
                {
                    var victim = PlayerInfo.CurrentCity.Population[potentialVictim];
                    if (victim != Murder && victim.SexEnum == SexHunt && victim.Age>= AgeHunt.from && victim.Age <=AgeHunt.to)
                        HuntTarget=victim;
                }
            }

        }
        public DamageType ChooseWeapon()
        {
            Random rand = new Random();
            int weaponIndex = rand.Next(0,3);
            switch (weaponIndex)
            {
                case 0:
                    return DamageType.flat;
                case 1:
                    return DamageType.slicing;
                case 2:
                    return DamageType.sharp;
                default: return DamageType.flat;

            }
        }
    }
    public class Killer : MurderTypeData
    {
        public override DamageType WeaponType => ChooseWeapon();
        public override string ReasonToString => "This is my job.";
        public override ReasonType Reason => ReasonType.hiring;
        public Killer(Person murder)
              : base(murder)
        {

        }
        public override void FindVictim()
        {
            if (HuntTarget == null)
            {
                HuntTarget= PlayerInfo.CurrentCity.BlackMarketOrders.Find(x => x.Victim != Murder).Victim;
            }

        }
        public DamageType ChooseWeapon()
        {
            Random rand = new Random();
            int weaponIndex = rand.Next(0, 2);
            switch (weaponIndex)
            {
                case 0:
                    return DamageType.poison;
                case 1:
                    return DamageType.gunshot;
                default: return DamageType.gunshot;

            }
        }
    }
    public class Lover : MurderTypeData
    {
        public override DamageType WeaponType => ChooseWeapon();
        public override string ReasonToString => "I loved.";
        public override ReasonType Reason => ReasonType.jealousy;
        public Lover(Person murder)
             : base(murder)
        {

        }
        public override void FindVictim()
        {
            if (HuntTarget == null && Murder.Partner.Contacts.MaxBy(x => x.Value).Key != Murder)
            {
                HuntTarget= Murder.Partner.Contacts.MaxBy(x => x.Value).Key;
            }
        }
        public DamageType ChooseWeapon()
        {
            Random rand = new Random();
            int weaponIndex = rand.Next(0, 4);
            switch (weaponIndex)
            {
                case 0:
                    return DamageType.poison;
                case 1:
                    return DamageType.gunshot;
                case 2:
                    return DamageType.sharp;
                case 3:
                    return DamageType.slicing;
                default: return DamageType.gunshot;

            }
        }
    }
    //public class Envious : MurderTypeData
    //{
    //    public override Items Weapon => new SilentPistol();
    //    public override ReasonType Reason => ReasonType.envies;
    //}
    //public class Hater : MurderTypeData
    //{
    //    public override Items Weapon => new SilentPistol();
    //    public override ReasonType Reason => ReasonType.hatred;
    //}



}
