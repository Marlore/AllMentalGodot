using Data.StreetData;
using Engine.PlayerEngine;
using Entity.Locations;
using Entity.People;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Data.SectionData
{
    public abstract class Segment
    {
        public abstract string Purpose { get; }
        public string Adress;
        public Guid Id;
        public List<Guid> PeopleInside = new List<Guid>();
        public ILocations LocatedOn;
        public abstract int Lenght { get; }
        public int level;
        public Segment(ILocations location) 
        {
            level = 0;
            Id = Guid.NewGuid();
            LocatedOn = location;
            Adress = location.Adress + " " + Purpose;
            PlayerInfo.CurrentCity.CitySegments.Add(this);
        }
    }
    public class StoreRoom : Segment
    {
        public override string Purpose => "Store room";
        public override int Lenght => 3;
        public StoreRoom(ILocations location) : base(location) { }
    }
    public class OfficeSegment : Segment
    {
        public override string Purpose => "Office";
        public override int Lenght => 3;
        public OfficeSegment(ILocations location) : base(location) { }
    }
    public class Workshop : Segment
    {
        public override string Purpose => "Workshop"; 
        public override int Lenght => 3;
        public Workshop(ILocations location) : base(location) { }
    }
    public class TrainingRoom : Segment
    {
        public override string Purpose => "Training room";
        public override int Lenght => 2;
        public TrainingRoom(ILocations location) : base(location) { }
    }

    public class DirectorsOffice : Segment
    {
        public override string Purpose => "Director's Office";
        public override int Lenght => 1;
        public DirectorsOffice(ILocations location) : base(location) { }
    }

    public class RecreationRoom : Segment
    {
        public override string Purpose => "Recreation room";
        public override int Lenght => 2;
        public RecreationRoom(ILocations location) : base(location) { }
    }
    public class Kitchen : Segment
    {
        public override string Purpose => "Kitchen";
        public override int Lenght => 3;
        public Kitchen(ILocations location) : base(location) { }
    }
    public class Outdoors: Segment
    {
        public override string Purpose => "Outdoors"; 
        public override int Lenght => 6;
        public Outdoors(ILocations location):base(location) { }
    }
    public class Toilet : Segment
    {
        public override string Purpose => "Toilet";
        public override int Lenght => 1;
        public Toilet(ILocations location) : base(location) { }
    }
    public class Reception : Segment
    {
        public override string Purpose => "Reception";
        public override int Lenght => 2;
        public Reception(ILocations location) : base(location) { }
    }
    public class Hallway : Segment
    {
        public override string Purpose => $"Hall floor";
        public override int Lenght => 1;
        public Hallway(ILocations location) : base(location) =>level = 0;
        public Hallway(ILocations location, int _level) : base(location) =>level = _level;
    }
    public class ClassRoom : Segment
    {
        public override string Purpose => "ClassRoom "+ Letter;
        public List<Person> Students = new List<Person>();
        public string Letter;
        public override int Lenght => 3;
        public ClassRoom(ILocations location) : base(location) { }
    }
    public class DiningRoom : Segment
    {
        public override string Purpose => "Dining room";
        public override int Lenght => 2;
        public DiningRoom(ILocations location) : base(location) { }
    }
    public class BedRoom : Segment
    {
        public override string Purpose => "Bed room";
        public override int Lenght => 1;
        public BedRoom(ILocations location) : base(location) { }
    }
    public class OnStreet : Segment
    {
        public override string Purpose => "On street";
        public override int Lenght => 5;
        public OnStreet(ILocations location) : base(location) { }
    }
    public class LivingRoom : Segment
    {
        public override string Purpose => "Living room";
        public override int Lenght => 1;
        public LivingRoom(ILocations location) : base(location) { }
    }
    public class Payphone : Segment
    {
        public override string Purpose => "Payphone";
        public override int Lenght => 1;
        public Payphone(ILocations location) : base(location) { }
    }
    public class Stairwell : Segment
    {
        public override string Purpose => "Stairwell";
        public override int Lenght => 1;
        public Stairwell(ILocations location, int _level) : base(location) => level = _level;
    }
    public class PatientRoom : Segment
    {
        public override string Purpose => "Living room";
        public Person Patient;
        public override int Lenght => 1;
        public PatientRoom(ILocations location) : base(location) { }
    }
}
