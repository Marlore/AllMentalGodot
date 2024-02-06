using Entity.Locations;
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
        public List<Guid> PeopleInside = new List<Guid>();
        public ILocations LocatedOn;
        public Segment(ILocations location) 
        {
            LocatedOn = location;
            Adress = location.Adress + " " + Purpose;
        }
    }
    public class StoreRoom : Segment
    {
        public override string Purpose => "Store room";
        public StoreRoom(ILocations location) : base(location) { }
    }
    public class OfficeSegment : Segment
    {
        public override string Purpose => "Office";
        public OfficeSegment(ILocations location) : base(location) { }
    }
    public class Workshop : Segment
    {
        public override string Purpose => "Workshop";
        public Workshop(ILocations location) : base(location) { }
    }
    public class TrainingRoom : Segment
    {
        public override string Purpose => "Training room";
        public TrainingRoom(ILocations location) : base(location) { }
    }

    public class DirectorsOffice : Segment
    {
        public override string Purpose => "Director's Office";
        public DirectorsOffice(ILocations location) : base(location) { }
    }

    public class RecreationRoom : Segment
    {
        public override string Purpose => "Recreation room";
        public RecreationRoom(ILocations location) : base(location) { }
    }
    public class Kitchen : Segment
    {
        public override string Purpose => "Kitchen";
        public Kitchen(ILocations location) : base(location) { }
    }
    public class Outdoors: Segment
    {
        public override string Purpose => "Outdoors";
        public Outdoors(ILocations location):base(location) { }
    }
    public class Toilet : Segment
    {
        public override string Purpose => "Toilet";
        public Toilet(ILocations location) : base(location) { }
    }
    public class Reception : Segment
    {
        public override string Purpose => "Reception";
        public Reception(ILocations location) : base(location) { }
    }
    public class Hallway : Segment
    {
        public override string Purpose => "Hall";
        public int level;
        public Hallway(ILocations location) : base(location) =>level = 0;
        public Hallway(ILocations location, int _level) : base(location) =>level = _level;
    }
    public class ClassRoom : Segment
    {
        public override string Purpose => "ClassRoom";
        public ClassRoom(ILocations location) : base(location) { }
    }
    public class DiningRoom : Segment
    {
        public override string Purpose => "Dining room";
        public DiningRoom(ILocations location) : base(location) { }
    }
    public class BedRoom : Segment
    {
        public override string Purpose => "Bed room";
        public BedRoom(ILocations location) : base(location) { }
    }
    public class OnStreet : Segment
    {
        public override string Purpose => "On street";
        public OnStreet(ILocations location) : base(location) { }
    }
    public class LivingRoom : Segment
    {
        public override string Purpose => "Living room";
        public LivingRoom(ILocations location) : base(location) { }
    }
    public class Payphone : Segment
    {
        public override string Purpose => "Payphone";
        public Payphone(ILocations location) : base(location) { }
    }
    public class Stairwell : Segment
    {
        public override string Purpose => "Stairwell";
        public int level;
        public Stairwell(ILocations location, int _level) : base(location) => level = _level;
    }
}
