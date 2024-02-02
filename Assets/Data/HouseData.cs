﻿using Data.Appartment;
using Data.StreetData;
using Engine.PlayerEngine;
using Entity.Company;
using Entity.Locations;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.HouseData
{
    public class Houses:ILocations
    {
        private int[] ApartmentCountRandom = new int[] { 16, 36, 56, 76 };
        Random random = new Random();
        public string Adress { get; set; }
        public Guid Id;
        public string HouseNumber;
        public int ApartmentCount;
        public List<Apartments> ApartmentList=  new List<Apartments> ();
        public List<Business> HouseBusiness = new List<Business> ();
        public Streets OnStreet;
        public List<Guid> PeopleInside {get; set;}

        public Houses(string street,int number, Streets _onStreet) 
        {
            OnStreet = _onStreet;
            HouseNumber = number.ToString();
            Adress = $"{number} {street}";
            Id = Guid.NewGuid();
            int rand = random.Next(0, ApartmentCountRandom.Count());
            ApartmentCount = ApartmentCountRandom[rand];
            PeopleInside = new List<Guid>();
            PlayerInfo.CurrentCity.CityHouses.Add(Id,this);
            PlayerInfo.CurrentCity.Locations.Add(Id, this);
        }
        public List<Apartments> CreateApartments( string name, int count)
        {
            List<Apartments> apartments = new List<Apartments> ();
            for (int i = 4; i < count+4; i++)
                apartments.Add(new Apartments(name, i + 1, this));
            return apartments;
        }       

       
    }
}
