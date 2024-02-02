using Data.Appartment;
using Engine.Generator;
using Engine.PlayerEngine;
using Entity.Job;
using Entity.Locations;
using Entity.Log;
using System;
using System.Collections.Generic;

namespace Entity.Company
{
    public enum business
    {
        coffeshop, restaurants, pharmacy, grocerystore, factory, postmart, gym, office, bar,school, university, hospital, police, laborExchange, administration, park, kindergarten
    }
    public abstract class Business:ILocations
    {
        public string Name;
        public abstract string Description { get; }
        public string Adress { get; set; }
        public Guid Id;
        public List<Work> Vacancy= new List<Work>();
        public List<Guid> PeopleInside { get; set; }
        public List<Room> Rooms = new List<Room>();
        public Business(string adress, int room) 
        {
            Id = Guid.NewGuid();
            Adress = $"{adress} 000{room}";
            PeopleInside = new List<Guid>();
            PlayerInfo.CurrentCity.CompanyList.Add(Id,this);
            PlayerInfo.CurrentCity.Locations.Add(Id, this);
        }
    }
    public class Park: Business
    {
        public override string Description => "Labor Exchange";
        public Park(string adress, int room)
            : base(adress, room)
        {
            
            base.Adress = $"{room} {adress}";
            Rooms.Add(new Room(base.Adress, "Gatehouse"));
            Name = CityGenerator.GenerateName(CityGenerator.ParkNamesList);
            Vacancy.Add(new JanitorFirstShift(this));
            Vacancy.Add(new JanitorSecondShift(this));
            Vacancy.Add(new JanitorFirstShift(this));
            Vacancy.Add(new JanitorSecondShift(this));
            PlayerInfo.CurrentCity.ParkList.Add(this.Id, this);
        }
    }
    public class LaborExchange : Business
    {
        public override string Description => "Labor Exchange";
        public LaborExchange(string adress, int room)
            : base(adress, room)
        {
            base.Adress = $"{room} {adress}";
            Rooms.Add(new Room(base.Adress, "Office"));
            Rooms.Add(new Room(base.Adress, "Director's Office"));
            Rooms.Add(new Room(base.Adress, "Reception"));
            Name = "Labor Exchange";
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            PlayerInfo.CurrentCity.CityLaborExchange = this;
        }
    }
    public class Administration : Business
    {
        public override string Description => "Administration";
        public List<Records> RecordsList = new List<Records>();
        public Administration(string adress, int room)
            : base(adress, room)
        {
            base.Adress = $"{room} {adress}";
            Name = "City Hall";
            Vacancy.Add(new Mayor(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            PlayerInfo.CurrentCity.CityAministration = this;
        }
    }
    public class CoffeShop: Business
    {
        public override string Description => "Coffe Shop";
        public CoffeShop(string adress, int room)
            : base(adress, room)
        {
            Name = CityGenerator.GenerateName(CityGenerator.CoffeNamesList);
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new СashierFirstShift(this));
            Vacancy.Add(new СashierFirstShift(this));
            Vacancy.Add(new СashierSecondShift(this));
            Vacancy.Add(new СashierSecondShift(this));
            PlayerInfo.CurrentCity.CoffeshopList.Add(this.Id, this);
        }
    }
    public class Restaurants : Business
    {
        public override string Description => "Restaurants";
        public Restaurants(string adress, int room)
            : base(adress, room)
        {
            Name = CityGenerator.GenerateName(CityGenerator.RestaurantsNamesList);
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new СashierFirstShift(this));
            Vacancy.Add(new СashierFirstShift(this));
            Vacancy.Add(new СashierSecondShift(this));
            Vacancy.Add(new СashierSecondShift(this));
            Vacancy.Add(new WaiterFirstShift(this));
            Vacancy.Add(new WaiterFirstShift(this));
            Vacancy.Add(new WaiterSecondShift(this));
            Vacancy.Add(new WaiterSecondShift(this));
            Vacancy.Add(new HeadChef(this));
            Vacancy.Add(new CookFirstShift(this));
            Vacancy.Add(new CookFirstShift(this));
            Vacancy.Add(new CookSecondShift(this));
            Vacancy.Add(new CookSecondShift(this));
            Vacancy.Add(new JanitorFirstShift(this));
            Vacancy.Add(new JanitorSecondShift(this));
            PlayerInfo.CurrentCity.RestaurantsList.Add(this.Id, this);
        }
    }
    public class Pharmacy : Business
    {
        public override string Description => "Pharmacy";
        public Pharmacy(string adress, int room)
            : base(adress, room)
        {
            Name = CityGenerator.GenerateName(CityGenerator.PharmacyNamesList);
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new PharmacistFirstShift(this));
            Vacancy.Add(new PharmacistFirstShift(this));
            Vacancy.Add(new JanitorFirstShift(this));
            PlayerInfo.CurrentCity.PharmacyList.Add(this.Id, this);
        }
    }
    public class GroceryStore : Business
    {
       
        public override string Description => "Grocery Store";
        public GroceryStore(string adress, int room)
            : base(adress, room)
        {
            Name = CityGenerator.GenerateName(CityGenerator.GroceryStoresNamesList);
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new СashierFirstShift(this));
            Vacancy.Add(new СashierFirstShift(this));
            Vacancy.Add(new СashierSecondShift(this));
            Vacancy.Add(new СashierSecondShift(this));
            Vacancy.Add(new NightСashierFirstShift(this));
            Vacancy.Add(new NightСashierFirstShift(this));
            Vacancy.Add(new NightСashierSecondShift(this));
            Vacancy.Add(new NightСashierSecondShift(this));
            Vacancy.Add(new JanitorFirstShift(this));
            Vacancy.Add(new JanitorSecondShift(this));
            PlayerInfo.CurrentCity.GroceryStoreList.Add(this.Id, this);
        }
    }
    public class Factory : Business
    {
        
        public override string Description => "Factory";
        public Factory(string adress, int room)
            : base(adress, room)
        {
            Name = CityGenerator.GenerateName(CityGenerator.FactoryNamesList);
            base.Adress = $"{room} {adress}";
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new Mechanic(this));
            Vacancy.Add(new Mechanic(this));
            Vacancy.Add(new Mechanic(this));
            Vacancy.Add(new Mechanic(this));
            Vacancy.Add(new Mechanic(this));
            Vacancy.Add(new Mechanic(this));
            Vacancy.Add(new JanitorFirstShift(this));
            Vacancy.Add(new JanitorFirstShift(this));
            Vacancy.Add(new JanitorSecondShift(this));
            Vacancy.Add(new JanitorSecondShift(this));
        }
    }
    public class PostMart : Business
    {
        public override string Description => "Postmart";
        public PostMart(string adress, int room)
            : base(adress, room)
        {
            Name = CityGenerator.GenerateName(CityGenerator.PostOfficeList);
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new СashierFirstShift(this));
            Vacancy.Add(new СashierFirstShift(this));
            Vacancy.Add(new СashierSecondShift(this));
            Vacancy.Add(new СashierSecondShift(this));
            PlayerInfo.CurrentCity.PostmartList.Add(this.Id, this);
        }
    }
    public class Gym : Business
    {
        public override string Description => "Gym";
        public Gym(string adress, int room)
            : base(adress, room)
        {
            Name =CityGenerator.GenerateName(CityGenerator.GymNamesList);
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new СashierFirstShift(this));
            Vacancy.Add(new СashierSecondShift(this));
            Vacancy.Add(new CoachFirstShift(this));
            Vacancy.Add(new CoachFirstShift(this));
            Vacancy.Add(new CoachSecondShift(this));
            Vacancy.Add(new CoachSecondShift(this));
            PlayerInfo.CurrentCity.GymList.Add(this.Id, this);
        }
    }
    public class Office : Business
    {
        public override string Description => "Office";
        public Office(string adress, int room)
            : base(adress, room)
        {
            Name = CityGenerator.GenerateName(CityGenerator.OfficeNamesList);
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            PlayerInfo.CurrentCity.OfficeList.Add(this.Id, this);
        }
    }
    public class Bar : Business
    {
       
        public override string Description => "Bar";
        public Bar(string adress, int room)
            : base(adress, room)
        {
            Name = CityGenerator.GenerateName(CityGenerator.BarNamesList);
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new BarmanFirstShift(this));
            Vacancy.Add(new BarmanSecondShift(this));
            Vacancy.Add(new NightBarmanFirstShift(this));
            Vacancy.Add(new NightBarmanSecondShift(this));
            Vacancy.Add(new JanitorFirstShift(this));
            Vacancy.Add(new JanitorSecondShift(this));
            PlayerInfo.CurrentCity.BarList.Add(this.Id, this);
        }
        ~Bar(){

        }
    }
    public class KinderGarten : Business
    {
        public override string Description => "Kindergarten";
        public List<Guid> Students = new List<Guid>();
        public KinderGarten(string adress, int room)
            : base(adress, room)
        {
            Name = CityGenerator.GenerateName(CityGenerator.SchoolNamesList);
            base.Adress = $"{room} {adress}";
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            PlayerInfo.CurrentCity.KinderGartenList.Add(Id, this);
        }
    }
    public class School : Business
    {
        public override string Description => "School";
        public List<Guid> Students = new List<Guid>();
        public School(string adress, int room)
            : base(adress, room)
        {
            Name = CityGenerator.GenerateName(CityGenerator.SchoolNamesList);
            base.Adress = $"{room} {adress}";
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            PlayerInfo.CurrentCity.SchoolList.Add(Id, this);
        }
    }
    public class University : Business
    {
        public override string Description => "University";
        public List<Guid> Students = new List<Guid>();
        public University(string adress, int room)
            : base(adress, room)
        {
            Name = "Central University";
            base.Adress = $"{room} {adress}";
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            PlayerInfo.CurrentCity.UniversityList.Add(Id, this);
        }
    }
    public class Hospital : Business
    {
        public override string Description => "Hospital";
        public List<Guid> Patient = new List<Guid>();
        public List<Records> RecordsList = new List<Records>();
        public Hospital(string adress, int room)
            : base(adress, room)
        {
            Name = CityGenerator.GenerateName(CityGenerator.HospitalNamesList);
            base.Adress = $"{room} {adress}";
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            Vacancy.Add(new Teacher(this));
            PlayerInfo.CurrentCity.HospitalList.Add(Id, this);
        }
      
    }
    public class Police : Business
    {
        public override string Description => "Police Department";
        public List<Records> RecordsList = new List<Records>();
        public List<Guid> Client = new List<Guid>();
        public Police(string adress, int room)
            : base(adress, room)
        {
            Name = "Police Department";
            base.Adress = $"{room} {adress}";
            Vacancy.Add(new Director(this));
            Vacancy.Add(new Secretary(this));
            Vacancy.Add(new Manager(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new Accountant(this));
            Vacancy.Add(new PolicemanFirstShift(this));
            Vacancy.Add(new PolicemanFirstShift(this));
            Vacancy.Add(new PolicemanFirstShift(this));
            Vacancy.Add(new PolicemanFirstShift(this));
            Vacancy.Add(new PolicemanSecondShift(this));
            Vacancy.Add(new PolicemanSecondShift(this));
            Vacancy.Add(new PolicemanSecondShift(this));
            Vacancy.Add(new PolicemanSecondShift(this));
            PlayerInfo.CurrentCity.PoliceDepList.Add(Id, this);
        }
    }
}
