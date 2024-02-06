using Data.HouseData;
using Data.SectionData;
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
        public List<Segment> Segments { get; set; }
        public Segment EntryExitPoint { get; set; }
        public Guid Id;
        public int Length;        
        public List<Houses> HouseList = new List<Houses>();
        public Business Infostructer;
      
        public Streets() 
        {
            var _entryExit = new OnStreet(this);
            Segments = new List<Segment>() {new Payphone(this), _entryExit };
            EntryExitPoint = _entryExit;

            Adress = CityGenerator.GenerateName(CityGenerator.StreetsNamesList);
            Id= Guid.NewGuid();
            Length = random.Next(5, 12);
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
