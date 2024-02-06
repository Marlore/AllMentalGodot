using Data.HouseData;
using Data.SectionData;
using Engine.PlayerEngine;
using Entity.Locations;
using Entity.People;
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Collections.Specialized.BitVector32;

namespace Data.Appartment
{
    public class Apartments:ILocations
    {
        public bool Busy { get 
            {
                if (Residents?.Any()!=true) 
                    return false;
                else 
                    return true;
            } }
        public string Adress { get; set; }
        public Guid Id;
        public string RoomNumber;
        public int Floor;
        public string PhoneNumber;
        public Houses InHouse;
        public List<Person> Residents = new List<Person>();
        public List<Segment> Segments { get; set; }
        public Segment EntryExitPoint { get; set; }
        public Apartments(string adress, int number, Houses _inHouse)
        {
            InHouse = _inHouse;
            Floor = (int)(number / 4f);
            int room = (Floor * 1000) + number;
            Id = Guid.NewGuid();
            var rnd = new System.Random(Id.GetHashCode());
            PhoneNumber = rnd.Next(1000000,9999999).ToString();
            RoomNumber = room.ToString();
            Adress = $"{adress} {room}";

            PlayerInfo.CurrentCity.CityApartments.Add(Id,this);
            PlayerInfo.CurrentCity.Locations.Add(Id,this);

            var _entryExit = new Hallway(this);
            Segments = new List<Segment>() { new Kitchen(this), new BedRoom(this), new LivingRoom(this),new Toilet(this) , _entryExit};            
            EntryExitPoint = _entryExit;
        }
    }
   
}
