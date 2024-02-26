using Data.Appartment;
using Data.SectionData;
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
        public int NumberOfFloors;
        public bool FullHouseBusiness;
        public List<Segment> Segments { get; set; }
        public Segment EntryExitPoint { get; set; }
        public Business Infostructer;

        public Houses(string street,int number, Streets _onStreet) 
        {
            FullHouseBusiness= false;
            OnStreet = _onStreet;
            HouseNumber = number.ToString();
            Adress = $"{number} {street}";
            Id = Guid.NewGuid();
            int rand = random.Next(0, ApartmentCountRandom.Count());
            ApartmentCount = ApartmentCountRandom[rand];
            NumberOfFloors = ApartmentCount / 4+1;
            PlayerInfo.CurrentCity.CityHouses.Add(this);
            PlayerInfo.CurrentCity.Locations.Add(Id, this);
            
            Segments = new List<Segment> ();
            for(int i =0; i< NumberOfFloors; i++)
            {
                var hall = new Hallway(this, i);
                if(i==0)
                    EntryExitPoint = hall;
                Segments.Add(hall);
                Segments.Add(new Stairwell(this, i));
            }

        }
        public Houses(string street, int number, Streets _onStreet, bool _fullHouseBusiness)
        {
            FullHouseBusiness = _fullHouseBusiness;
            OnStreet = _onStreet;
            HouseNumber = number.ToString();
            Adress = $"{number} {street}";
            Id = Guid.NewGuid();
            NumberOfFloors = 1;
            PlayerInfo.CurrentCity.CityHouses.Add(this);
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
