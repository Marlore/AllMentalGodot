using Data.Appartment;
using Data.HouseData;
using Data.StreetData;
using Entity.Company;
using Entity.Job;
using Entity.People;
using System;
using System.Collections.Generic;
using Data.CompanyFactory;
using System.Linq;
using Entity.Log;
using Entity.Locations;
using Engine.PlayerEngine;
using System.Threading;
using Godot;
using System.Text.RegularExpressions;
using Data.SectionData;

namespace Data.CityData
{
	[Serializable]
	public class City
	{
		private static System.Random random = new System.Random();

		public DateTime CityTime;

		public Dictionary<Guid,Person> Population = new Dictionary<Guid, Person>();

		public List<Streets> CityStreets = new List<Streets>();
		public List<Houses> CityHouses = new List<Houses>();
		public List<Apartments> CityApartments = new List<Apartments>();
		public List<Segment> CitySegments = new List<Segment>();

		public Dictionary<Guid, Business> CompanyList = new Dictionary<Guid, Business>();
		public Dictionary<Guid, Work> Vacancy = new Dictionary<Guid, Work>();

		public Dictionary<Guid, CoffeShop> CoffeshopList = new Dictionary<Guid, CoffeShop>();
		public Dictionary<Guid, Restaurants> RestaurantsList = new Dictionary<Guid, Restaurants>();
		public Dictionary<Guid, Pharmacy> PharmacyList = new Dictionary<Guid, Pharmacy>();
		public Dictionary<Guid, GroceryStore> GroceryStoreList = new Dictionary<Guid, GroceryStore>();
		public Dictionary<Guid, PostMart> PostmartList = new Dictionary<Guid, PostMart>();
		public Dictionary<Guid, Gym> GymList = new Dictionary<Guid, Gym>();
		public Dictionary<Guid, Office> OfficeList = new Dictionary<Guid, Office>();
		public Dictionary<Guid, Bar> BarList = new Dictionary<Guid, Bar>();      
		public Dictionary<Guid,Park> ParkList = new Dictionary<Guid, Park>();


		public Dictionary<Guid, KinderGarten> KinderGartenList = new Dictionary<Guid, KinderGarten>();
		public Dictionary<Guid, School> SchoolList = new Dictionary<Guid, School>();
		public Dictionary<Guid, Police> PoliceDepList = new Dictionary<Guid, Police>();
		public Dictionary<Guid, University> UniversityList = new Dictionary<Guid, University>();
		public Dictionary<Guid, Hospital> HospitalList = new Dictionary<Guid,Hospital>();

		public Administration CityAministration;
		public LaborExchange CityLaborExchange;

		public Dictionary<Guid,ILocations> Locations = new Dictionary<Guid, ILocations>();

		public List<Necrolog> NecroLog = new List<Necrolog>();

		public City()
		{
			CityTime = new DateTime(2018, 12, 11, 7, 0, 0);
		}
		public void CityLife()
		{
		   
			while (true)
			{
				for (int i= 0; i<Population.Keys.Count; i++)
				{
					var id = Population.Keys.ElementAt(i);
					Population.Values.ElementAt(i).Live?.Invoke();
				}
				this.CityTime = this.CityTime.AddMinutes(1); 
				Thread.Sleep(50);
			}

		}

		public void BuildCity()
		{
			for (int i = 0; i < 9; i++)
			{
				CreateStreet();
            }
		}
		public void CreateStreet()
		{
            var street = new Streets();
            street.HouseList.AddRange(street.CreateHouses(street.Adress, street.Length));
            foreach (var House in street.HouseList)
			{
                House.ApartmentList.AddRange(House.CreateApartments(House.Adress, House.ApartmentCount));
            }
            CityStreets.Add(street);
			BuildInfrostructure();
        }
		public void PopulateTheCity(int populate)
        {
            for (int i = 0; i < populate; i++)
			{
				var person = new Person();
				Population.Add(person.Id,  person);
            }

        }
        private Dictionary<business, int> infostructer = new Dictionary<business, int>()
				{
					{ Entity.Company.business.factory, 1 },
					{ Entity.Company.business.police, 1 },
					{ Entity.Company.business.hospital, 1 },
					{ Entity.Company.business.university, 1 },
					{ Entity.Company.business.school,1 },
					{ Entity.Company.business.laborExchange, 1 },
					{ Entity.Company.business.administration, 1 },
					{ Entity.Company.business.park, 1},
			   { Entity.Company.business.kindergarten,1 }
				};
        private Dictionary<business, int> business = new Dictionary<business, int>()
                {
                    { Entity.Company.business.coffeshop, 3 },
                    { Entity.Company.business.restaurants, 2 },
                    { Entity.Company.business.pharmacy, 3},
                    { Entity.Company.business.grocerystore, 5 },
                    { Entity.Company.business.postmart, 4 },
                    { Entity.Company.business.gym, 3 },
                    { Entity.Company.business.office, 4 },
                    { Entity.Company.business.bar, 2 }
                };
        public void BuildInfrostructure()
		{        
			foreach (var street in CityStreets)
			{
				if (!street.HaveInfostructer && infostructer.Any())
				{
					
					int rand = random.Next(0, infostructer.Count);
					var creator = new AbstractFactory(); 
					var key = infostructer.ElementAt(rand).Key;
					var house = street.CreateHouseForBusiness();
					street.HouseList.Add(house);
                    var company = creator.CompanyCreator(key, street.Adress, street.HouseList.Count + 1, house);
					house.Infostructer = company;
					infostructer[key]--;
					if (infostructer[key] <= 0)
						infostructer.Remove(key);

                }
				foreach(var house in street.HouseList)
				{
					for(int i =0; i<4;i++)
						if (house.HouseBusiness.Count < 4 && business.Any())
						{
							int rand = random.Next(0, business.Count);
                            var creator = new AbstractFactory();
							var key = business.ElementAt(rand).Key;
							var company = creator.CompanyCreator(key, house.Adress, house.HouseBusiness.Count + 1, house);
							house.HouseBusiness.Add(company);
							business[key]--;
							if (business[key] <= 0)
								business.Remove(key);
						}
				}
			}
		}

	}
}
