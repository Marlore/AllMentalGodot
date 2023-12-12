using Engine.PlayerEngine;
using Entity.Locations;
using Entity.People;
using System;
using System.Collections.Generic;
using System.Linq;

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
        public List<Person> Residents;
        public List<Guid> PeopleInside { get; set; }
        public Apartments(string adress, int number)
        {
            Floor = (int)(number / 4f);
            int room = (Floor * 1000) + number;
            Id = Guid.NewGuid();
            var rnd = new System.Random(Id.GetHashCode());
            PhoneNumber = rnd.Next(1000000,9999999).ToString();
            Residents = new List<Person>();
            RoomNumber = room.ToString();
            Adress = $"{adress} {room}";
            PeopleInside = new List<Guid>();
            PlayerInfo.CurrentCity.CityApartments.Add(Id,this);
            PlayerInfo.CurrentCity.Locations.Add(Id,this);
        }
    }
}
