using Data.Appartment;
using Engine.Generator;
using Engine.PlayerEngine;
using Entity.Job;
using Entity.Plans;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Entity.People
{
    public enum _sex
    {
        Male, Female
    }
    public enum _orientation
    {
        Hetero, Homo
    }
    public enum _hobby
    {
        park, bar,gym
    }
    public enum _status
    {
        walk,work,sleep,talk,messingAround, hobby
    }
    public class Person
    {
        // Убраться
        Random rand = new Random();

        public bool Alive;

        public string FirstName;
        public string SecondName;

        public float Intellegence;
        public float Mental;
        public float Beuty;
        public float Healthfull;
        public float Stress;
        public float Social;
        public float Age { 
            get {
                if (Alive)
                    return (PlayerInfo.CurrentCity.CityTime - Bithday).Days / 365;
                else
                    return AgeOfDeath.Year;
            } }

        public Guid Id;

        public _orientation OrientationEnum;
        public _hobby HobbyEnum;
        public _sex SexEnum;
        public _status StatusEnum;

        public DateTime AgeOfDeath;
        public DateTime DateOfDeath{get{ return new DateTime(Bithday.Ticks+AgeOfDeath.Ticks); } }
        public string Orientation
        {
            get
            {
                if (OrientationEnum == _orientation.Hetero)
                    return "Hetero";
                else if (OrientationEnum == _orientation.Homo)
                    return "Homo";
                else return null;
            }
        }
        public string Sex { get 
            {
                if (SexEnum == _sex.Male)
                    return "Male";
                else if (SexEnum == _sex.Female)
                    return "Female";
                else return null;
            } 
        }
        public string Status { get
            { 
               switch (StatusEnum)
                {
                    case _status.hobby:
                        return "Hobby";
                    case _status.work:
                        return "Working";
                    case _status.walk:
                        return "Goes to";
                    case _status.sleep:
                        return "Sleep";
                    case _status.messingAround:
                        return "Messing around";
                    case _status.talk:
                        return "Talk";
                    default:
                        return "Messing around";
                }   

            }
        }
        public Work Job;
        public Person Mother;
        public Person Father;
        public Person Partner;
        public List<Person> Childs = new List<Person>();
        public Dictionary<Person, int> Contacts = new Dictionary<Person, int>();
        public Dictionary<Guid,Plan> Plans = new Dictionary<Guid, Plan>();

        public Apartments Apartment;
        public Guid CurrentLocation;
        public Guid HobbyPlace;
        public DateTime Bithday;
        public Action Live;
       
        private int HomeTime { get {
                int time = 0;
                if (Job != null)
                    time = Job.StartHour - 8;
                else 
                    time = 8;
                if (time < 0)
                    time = 24 - time;
                return time;
            } }


        public Person() 
        {
            Alive = true;
            Id = Guid.NewGuid();
            OrientationEnum = PersonGenerator.GenerateOrientation();
            SexEnum = PersonGenerator.GenerateSex();

            FirstName = PersonGenerator.GenerateFirstName(SexEnum);
            SecondName = PersonGenerator.GenerateLastName();

            Intellegence = rand.Next(1, 11);
            Mental = rand.Next(1, 11);
            Beuty = rand.Next(1, 11);
            Healthfull = rand.Next(1, 11);
            Social = rand.Next(1, 11);

            Bithday = PersonGenerator.GenerateBith();
            HobbyEnum =FindHobby();
            HobbyPlace = FindHobbyPlace();
            AgeOfDeath = PersonGenerator.GenerateAgeDeath();
           //Live = () => { this.TryMarry(); this.FindJob();this.Movement();this.Talk(); this.Aged(); };
            Live += this.TryMarry; Live += this.FindJob; Live += this.Movement; Live += this.Talk; Live += this.Aged; 
            if (SexEnum == _sex.Female)
                Live += this.GiveBorth;
        }
        public Person(Person mother, Person father)
        {
            Alive = true;
            Id = Guid.NewGuid();
            OrientationEnum = PersonGenerator.GenerateOrientation();
            SexEnum = PersonGenerator.GenerateSex();

            FirstName = PersonGenerator.GenerateFirstName(SexEnum);

            this.Mother = mother;
            this.Father = father;
            this.SecondName = Father.SecondName;
            this.Apartment = Mother.Apartment;
            Apartment.Residents.Add(this);

            Intellegence = PersonGenerator.GenerateNumFromTo(this.Mother.Intellegence, this.Father.Intellegence);
            Mental = PersonGenerator.GenerateNumFromTo(this.Mother.Mental, this.Father.Mental);
            Beuty = PersonGenerator.GenerateNumFromTo(this.Mother.Beuty, this.Father.Beuty);
            Healthfull = PersonGenerator.GenerateNumFromTo(this.Mother.Healthfull, this.Father.Healthfull);

            Bithday = PlayerInfo.CurrentCity.CityTime;

            HobbyEnum = FindHobby();
            HobbyPlace = FindHobbyPlace();
            AgeOfDeath = PersonGenerator.GenerateAgeDeath();

            Live += this.TryMarry; Live += this.FindJob; Live += this.Movement; Live += this.Talk; Live += this.Aged;
            if (SexEnum == _sex.Female)
                Live += this.GiveBorth;
        }

        public _hobby FindHobby()
        {
            var rand = new System.Random();
            int hobby = rand.Next(0, 3);
            return (_hobby)hobby;
        }
        public Guid FindHobbyPlace()
        {
            var rand = new System.Random();
            switch (HobbyEnum)
            {
                case _hobby.park:
                    return PlayerInfo.CurrentCity.ParkList.ElementAt(0).Key;
                case _hobby.bar:
                    return PlayerInfo.CurrentCity.BarList.ElementAt(rand.Next(0, PlayerInfo.CurrentCity.BarList.Count)).Key;
                case _hobby.gym:
                    return PlayerInfo.CurrentCity.GymList.ElementAt(rand.Next(0, PlayerInfo.CurrentCity.GymList.Count)).Key;
                default:
                    return PlayerInfo.CurrentCity.ParkList.ElementAt(0).Key;

            }
        }
        public void CallEmergency()
        {
            foreach(var person in PlayerInfo.CurrentCity.Locations[CurrentLocation].PeopleInside)
            {

            }
        }
        public void Movement()
        {
            if(PlayerInfo.CurrentCity.CityTime.Hour == Job.StartHour && Job.WorkingWeek.Contains(PlayerInfo.CurrentCity.CityTime.DayOfWeek))
                StatusEnum = _status.work;
            else if(PlayerInfo.CurrentCity.CityTime.Hour == Job.EndHour)
                StatusEnum = _status.messingAround;
            if (StatusEnum == _status.work)
            {
                if (!this.Job.WorkingFromHome)
                    this.MoveTo(this.Job.WorkingCompany.Id);
                else
                    this.MoveTo(this.Apartment.Id);
            }
            else if(StatusEnum != _status.work && PlayerInfo.CurrentCity.CityTime.Hour<= HomeTime&& Age>7)
            {
                StatusEnum = _status.hobby;
                this.MoveTo(HobbyPlace);
            }
            //else if (Plans[0]!=null)
            //{
            //    if(Plans[0].PlannedDate <= PlayerInfo.CurrentCity.CityTime && Plans[0].PlannedDate.AddMinutes(Plans[0].Duration) <= PlayerInfo.CurrentCity.CityTime)
            //    {
            //        MoveTo(Plans[0].PlannedPlace);
            //        if (PlayerInfo.CurrentCity.CityTime == Plans[0].PlannedDate.AddMinutes(Plans[0].Duration))
            //            foreach (var peopleId in Plans[0].InvitedPeople)
            //                PlayerInfo.CurrentCity.Population[peopleId].Plans.RemoveAt(0);
            //    }
            //}
            else 
            {
                StatusEnum = _status.messingAround;
                this.MoveTo(this.Apartment.Id);
            }
             
        }
        private void MoveTo(Guid location)
        {
            if (this.CurrentLocation != location && this.CurrentLocation != default(Guid))
            {
                PlayerInfo.CurrentCity.Locations[this.CurrentLocation].PeopleInside.Remove(this.Id);
                PlayerInfo.CurrentCity.Locations[location].PeopleInside.Add(this.Id);
                this.CurrentLocation = location;
            }
            else if(this.CurrentLocation == default(Guid))
            {
                this.CurrentLocation = this.Apartment.Id;
                PlayerInfo.CurrentCity.Locations[this.Apartment.Id].PeopleInside.Add(this.Id);
            }
        }
        private System.Random randomtalk = new System.Random();
        public void Talk()
        {

            Person person = null;
            if (PlayerInfo.CurrentCity.Locations[CurrentLocation].PeopleInside.Count > 1 && PlayerInfo.CurrentCity.CityTime.Minute ==30)
            {
                do
                {
                    int rand = randomtalk.Next(0, PlayerInfo.CurrentCity.Locations[CurrentLocation].PeopleInside.Count);
                    var id = PlayerInfo.CurrentCity.Locations[CurrentLocation].PeopleInside[rand];
                    person = PlayerInfo.CurrentCity.Population[id];
                }
                while (person == this);
            }     
            if (person != null)
            {
                if (Contacts.ContainsKey(person))
                {
                    int random = randomtalk.Next(0, 11);
                    if (random > Math.Abs(person.Mental - this.Mental))
                    {
                        person.Contacts[this]++;
                        Contacts[person]++;
                        AskForPlans(person);
                    }
                    else
                    {
                        person.Contacts[this]--;
                        Contacts[person]--;
                    }
                }
                else
                {
                    int random = randomtalk.Next(0, 10);
                    if(random> Math.Abs(person.Mental - this.Mental))
                    {
                        person.Contacts.Add(this, 1);
                        Contacts.Add(person, 1);
                    }
                    else
                    {
                        person.Contacts.Add(this,-1);
                        Contacts.Add(person, -1);
                    }
                }
            }
           
        }
        public void AskForPlans(Person person)
        {
            (int Day, int Month, int Year) DateOfPlans;
            int digitWeek = -1;
            Plan plan;
            
            if (this.Contacts[person]>=1 && this.Plans.Count<= (int)(this.Social / 2))
            {
                do
                {
                    digitWeek = CalculatePlanDateOfWeek(digitWeek, person);
                    DateOfPlans = CalculatePlanDate(digitWeek);
                    plan = CreatePlan(DateOfPlans,person);
                }
                while (plan == null && digitWeek != 8);
                if (plan != null)
                {
                    GD.Print(PlayerInfo.CurrentCity.CityTime);
                    this.Plans.Add(plan.Id,plan);
                    person.Plans.Add(plan.Id, plan);
                }
                

            }
        }
        private Plan CreatePlan((int Day, int Month, int Year) DateOfPlans, Person person)
        {
            // Не работает когда у кого-то есть план у кого-то нет
            int planHour = 10;
            DateTime TimesPlan = default(DateTime);
            GD.Print(person.Plans.Count + "  " + this.Plans.Count);
            if (DateOfPlans.Day == 0 && DateOfPlans.Month == 0 && DateOfPlans.Year == 0)
                return null;           
            for (int i = planHour; i < 23; i++)
            {
                TimesPlan = new DateTime(DateOfPlans.Year, DateOfPlans.Month, DateOfPlans.Day, i, 0, 0);
                if (this.Plans.Count != 0 && person.Plans.Count != 0)
                {
                    for (int j = 0; j < this.Plans.Count; j++)
                    {
                        for (int k = 0; k < person.Plans.Count; k++)
                        {
                            GD.Print(person.Plans.Count + "  " + this.Plans.Count);
                            var _plannedDate = this.Plans.ElementAt(j).Value.PlannedDate;
                            var _personPlannedDate = person.Plans.ElementAt(k).Value.PlannedDate;
                            if ((_plannedDate.Day == DateOfPlans.Day && _plannedDate.Month == DateOfPlans.Month && _plannedDate.Year == DateOfPlans.Year && i >= _plannedDate.Hour && i <= _plannedDate.AddMinutes(this.Plans.ElementAt(j).Value.Duration).Hour)
                                || (_personPlannedDate.Day == DateOfPlans.Day && _personPlannedDate.Month == DateOfPlans.Month && _personPlannedDate.Year == DateOfPlans.Year && i >= _personPlannedDate.Hour && i <= _personPlannedDate.AddMinutes(person.Plans.ElementAt(k).Value.Duration).Hour))
                            {
                                TimesPlan = default(DateTime);
                            }
                            else
                            {
                                TimesPlan = new DateTime(DateOfPlans.Year, DateOfPlans.Month, DateOfPlans.Day, i, 0, 0);
                            }
                        }
                    }
                }
                else if(person.Plans.Count != 0 && this.Plans.Count == 0)
                {
                    for (int k = 0; k < person.Plans.Count; k++)
                    {
                        GD.Print(person.Plans.Count + "  " + this.Plans.Count);
                        var _personPlannedDate = person.Plans.ElementAt(k).Value.PlannedDate;
                        if (_personPlannedDate.Day == DateOfPlans.Day && _personPlannedDate.Month == DateOfPlans.Month && _personPlannedDate.Year == DateOfPlans.Year && i >= _personPlannedDate.Hour && i <= _personPlannedDate.AddMinutes(person.Plans.ElementAt(k).Value.Duration).Hour)
                        {
                            TimesPlan = default(DateTime);
                        }
                        else
                        {
                            TimesPlan = new DateTime(DateOfPlans.Year, DateOfPlans.Month, DateOfPlans.Day, i, 0, 0);
                        }
                    }
                }
                else if(person.Plans.Count == 0 && this.Plans.Count != 0)
                {
                    for (int j = 0; j < this.Plans.Count; j++)
                    {
                        GD.Print(person.Plans.Count + "  " + this.Plans.Count);
                        var _plannedDate = this.Plans.ElementAt(j).Value.PlannedDate;
                        if (_plannedDate.Day == DateOfPlans.Day && _plannedDate.Month == DateOfPlans.Month && _plannedDate.Year == DateOfPlans.Year && i >= _plannedDate.Hour && i <= _plannedDate.AddMinutes(this.Plans.ElementAt(j).Value.Duration).Hour)                            
                        {
                            TimesPlan = default(DateTime);
                        }
                        else
                        {
                            TimesPlan = new DateTime(DateOfPlans.Year, DateOfPlans.Month, DateOfPlans.Day, i, 0, 0);
                        }
                    }
                }
                else if(person.Plans.Count == 0 && this.Plans.Count == 0)
                {
                    TimesPlan = new DateTime(DateOfPlans.Year, DateOfPlans.Month, DateOfPlans.Day, i, 0, 0);
                }
                if (TimesPlan != default(DateTime))
                    break;
            }
            if (TimesPlan == default(DateTime))
            {
                return null;
            }
            else
            {
                return new Plan(HobbyPlace, TimesPlan,Math.Max( 30 * (int)(this.Social / 2),30), Guid.NewGuid());
            }
                
        }
        private int CalculatePlanDateOfWeek(int _startedDayOfWeek, Person person) 
        {
            int digitWeek = 8;
            for (int i = _startedDayOfWeek+1; i < 7; i++)
            {
                if (!person.Job.WorkingWeek.Contains((DayOfWeek)i) && !this.Job.WorkingWeek.Contains((DayOfWeek)i))
                {
                    digitWeek = i;
                    break;
                }
                else
                    digitWeek = 8;
            }
            return digitWeek;
        }

        private (int,int,int) CalculatePlanDate(int _digitWeek)
        {
            int day, month, year;
            day = 0;
            month = 0;
            year = 0;
            if (_digitWeek < 8)
            {
                for (int i = 1; i <= 7; i++)
                {
                    if (PlayerInfo.CurrentCity.CityTime.AddDays(i).DayOfWeek == (DayOfWeek)_digitWeek)
                    {
                        day = PlayerInfo.CurrentCity.CityTime.AddDays(i).Day;
                        month = PlayerInfo.CurrentCity.CityTime.AddDays(i).Month;
                        year = PlayerInfo.CurrentCity.CityTime.AddDays(i).Year;
                        break;
                    }
                }
            }
            return (day, month, year);
        }
        public void FindJob()
        {
            if (this.Job == null)
            {
                if (Age <= 5)
                {
                    Job = new KinderGartenerYoung(this);
                    Job.Worker = this.Id;
                }
                else if (Age >= 5 && Age<7)
                {
                    Job = new KinderGartenerOld(this);
                    Job.Worker = this.Id;
                }
                else if (Age >= 7 && Age < 18)
                {
                    Job = new SchoolStudent(this);
                    Job.Worker = this.Id;
                }
                else if (Age >= 18 && Age <= 21)
                {
                    Job = new UniversityStudent(this);
                    Job.Worker = this.Id;
                }
                else if (Age > 21 && Age < 60)
                {
                    float payment = 0f;
                    Work work = new SelfEmployed();
                    foreach (var job in PlayerInfo.CurrentCity.Vacancy)
                    {
                        if (payment < job.Value.Salary && job.Value.StatValue <= Intellegence && !job.Value.IsBusy)
                        {
                            work = job.Value;
                            payment = job.Value.Salary;
                        }
                    }
                    Job = work;
                    Job.Worker = this.Id;
                }
                else if (Age >= 60)
                {
                    Job = new Retiree();
                    Job.Worker = this.Id;
                }
            }
        }

        public void TryMarry()
        {
            foreach (var partner in Contacts) 
            {
                if (partner.Value >= 10 && this.Partner == null && partner.Key.Partner == null && !Childs.Contains(partner.Key))
                    if(MarryAccept(partner.Key))
                    {
                        this.Partner = partner.Key;
                        partner.Key.Partner = this;
                        if (this.SexEnum == _sex.Male)
                        {
                            this.Partner.SecondName = this.SecondName;
                            this.Partner.Apartment.Residents.Remove(this.Partner);
                            this.Partner.Apartment = this.Apartment;
                            this.Apartment.Residents.Add(this.Partner);
                        }
                        else
                        {
                            this.SecondName = this.Partner.SecondName;
                            this.Apartment.Residents.Remove(this);
                            this.Apartment = this.Partner.Apartment;
                            this.Apartment.Residents.Add(this);
                        }
                        break;
                    }
            }
        }
        private void Aged()
        {
            if ((PlayerInfo.CurrentCity.CityTime - Bithday).Ticks >= AgeOfDeath.Ticks)
                Death(null, "Old Age");
        }
        private bool MarryAccept(Person person)
        {
            if (person.SexEnum != this.SexEnum && person.OrientationEnum == _orientation.Hetero)
                return true;
            else if (person.SexEnum == this.SexEnum && person.OrientationEnum == _orientation.Homo)
                return true;
            else return false;
        }
        public void GiveBorth()
        {
            if (SexEnum == _sex.Female&& Partner != null && Contacts[Partner] >= 20 + (Childs.Count * 5) && Age>18 && Age<50 && Partner.SexEnum == _sex.Male && Childs.Count<3 )
            {
                var child = new Person(this, this.Partner);
                Childs.Add(child);
                Partner.Childs.Add(child);
                PlayerInfo.CurrentCity.Population.Add(child.Id,child);
            }
        }
        public void Death(Person murder, string reason)
        {
            AgeOfDeath = new DateTime(PlayerInfo.CurrentCity.CityTime.Ticks- Bithday.Ticks);   
            if (murder == null) 
                PlayerInfo.CurrentCity.NecroLog.Add(new Log.Necrolog(this, reason));
            else
                PlayerInfo.CurrentCity.NecroLog.Add(new Log.Necrolog(this,murder));
            Apartment.Residents.Remove(this);
            foreach (var vacancy in Job.WorkingCompany.Vacancy)
                if (vacancy.Worker == this.Id)
                {
                    vacancy.Worker = default(Guid);
                    break;
                }
            if(Partner !=null)
                Partner.Partner=null;
            Alive = false;
            this.Live = null;
        }

        ~Person()
        {
            
        }
    }
}