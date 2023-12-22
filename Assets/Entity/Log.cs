using Engine.PlayerEngine;
using Entity.People;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Entity.Log
{
    public class Records
    {
        public string Record;
        
        public Records(Person caller, Person deadbody, Guid location, bool nameSaid) 
        {
            if(nameSaid)
                    Record = $"{caller.FirstName} {caller.SecondName} {caller.Bithday} saw a dead body at {PlayerInfo.CurrentCity.CityTime} on {PlayerInfo.CurrentCity.Locations[location]}.";
            else
                Record = $"Unknown {caller.Sex} saw a dead body at {PlayerInfo.CurrentCity.CityTime} on {PlayerInfo.CurrentCity.Locations[location]}.";
            PlayerInfo.CurrentCity.PoliceDepList.ElementAt(0).Value.RecordsList.Add(this);
            PlayerInfo.CurrentCity.HospitalList.ElementAt(0).Value.RecordsList.Add(this);
        }
        public Records(Person partner1, Person partner2)
        {
            Record = $"{partner1.FirstName} {partner1.SecondName} {partner1.Bithday} and {partner2.FirstName} {partner2.SecondName} {partner2.Bithday} get married.";
            PlayerInfo.CurrentCity.CityAministration.RecordsList.Add(this);
        }

    }
    public class Necrolog
    {
        public string FullName;
        public string Sex;
        public List<(string,DateTime)> Children = new List<(string,DateTime)> ();
        public DateTime DeathDay;
        public DateTime BithDay;

        public string PartnerName;
        public DateTime PartnerBithDay;

        public string Apartment;

        public string WorkPosition;
        public string WorkCompany;
        public string WorkAdress;

        public bool IsMurder;
        public Person Murder;

        public string Reason;
        public Necrolog(Person person, string reason)
        {
            FullName = person.FirstName + " " + person.SecondName;
            Sex = person.Sex;
            DeathDay = PlayerInfo.CurrentCity.CityTime;
            BithDay = person.Bithday;
            Apartment = person.Apartment.Adress;
            foreach (var child in person.Childs)
                Children.Add((child.FirstName + " " + child.SecondName, child.Bithday));
            if (person.Partner != null)
            {
                PartnerName = person.Partner.FirstName + " " + person.Partner.SecondName;
                PartnerBithDay = person.Partner.Bithday;
            }
            WorkPosition = person.Job.Name;
            WorkCompany = person.Job.WorkingCompany.Name;
            if (person.Job.WorkingFromHome)
                WorkAdress = "By place of residence";
            else
                WorkAdress = person.Job.WorkingCompany.Adress;
            IsMurder = false;
            Reason = reason;
        }
        public Necrolog(Person person, Person murder) 
        {
            FullName = person.FirstName + " " + person.SecondName;
            Sex = person.Sex;
            DeathDay = PlayerInfo.CurrentCity.CityTime;
            BithDay = person.Bithday;
            Apartment = person.Apartment.Adress;

            foreach (var child in person.Childs)
                Children.Add((child.FirstName + " " + child.SecondName, child.Bithday));
            if (person.Partner != null)
            {
                PartnerName = person.Partner.FirstName + " " + person.Partner.SecondName;
                PartnerBithDay = person.Partner.Bithday;
            }
            WorkPosition = person.Job.Name;
            WorkCompany = person.Job.WorkingCompany.Name;
            if (person.Job.WorkingFromHome)
                WorkAdress = "By place of residence";
            else
                WorkAdress = person.Job.WorkingCompany.Adress;
            Murder = murder;
            IsMurder = true;
            Reason = "Murder";
        }
    }
}
