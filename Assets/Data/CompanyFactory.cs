using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Company;
using Entity.Job;
using static Entity.Company.Hospital;

namespace Data.CompanyFactory
{
    public class AbstractFactory
    {
        public Business CompanyCreator(Entity.Company.business bus, string adress, int room)
        {
            switch (bus)
            {
                case Entity.Company.business.coffeshop:
                    return new CoffeShop(adress, room);
                case Entity.Company.business.restaurants:
                    return new Restaurants(adress,room);
                case Entity.Company.business.pharmacy:
                    return new Pharmacy(adress, room);
                case Entity.Company.business.grocerystore:
                    return new GroceryStore(adress, room);
                case Entity.Company.business.factory:
                    return new Factory(adress,room);
                case Entity.Company.business.postmart:
                    return new PostMart(adress,room);
                case Entity.Company.business.gym:
                    return new Gym(adress, room);
                case Entity.Company.business.office:
                    return new Office(adress, room);
                case Entity.Company.business.bar:
                    return new Bar(adress, room);
                case Entity.Company.business.school:
                    return new School(adress, room);
                case Entity.Company.business.university:
                    return new University(adress, room);
                case Entity.Company.business.hospital:
                    return new Hospital(adress, room);
                case Entity.Company.business.police:
                    return new Police(adress, room);
                case Entity.Company.business.laborExchange:
                    return new LaborExchange(adress, room);
                case Entity.Company.business.administration:
                    return new Administration(adress, room);
                case Entity.Company.business.park:
                    return new Park(adress, room);
                case Entity.Company.business.kindergarten:
                    return new KinderGarten(adress, room);
                default:
                    return null;

            }
           
        }
    }
}
