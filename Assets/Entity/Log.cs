using Engine.PlayerEngine;
using Entity.People;
using System;
using System.Collections.Generic;


namespace Entity.Log
{
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
