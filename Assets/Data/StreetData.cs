using Data.HouseData;
using Engine.Generator;
using Engine.PlayerEngine;
using Entity.Company;
using Entity.Locations;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.StreetData
{
    public class Streets:ILocations
    {
        Random random = new Random();
        public string Adress { get; set; }
        public Guid Id;
        public int Length;        
        public List<Houses> HouseList = new List<Houses>();
        public Business Infostructer;
        public List<Guid> PeopleInside { get; set; }
        public Streets() 
        {
            Adress = CityGenerator.GenerateName(CityGenerator.StreetsNamesList);
            Id= Guid.NewGuid();
            Length = random.Next(5, 12);
            PeopleInside = new List<Guid>();
            PlayerInfo.CurrentCity.Locations.Add(Id, this);
        }
        public List<Houses> CreateHouses(string street, int count)
        {
            List<Houses> houses = new List<Houses>();
            for (int i = 0; i < count; i++)
                houses.Add(new Houses(street, i + 1,this));
            return houses;
        }
    }
}
