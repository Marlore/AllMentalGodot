using Engine.PlayerEngine;
using Entity.Company;
using Entity.People;
using System;
using System.Linq;

namespace Entity.Job
{
    
    public abstract class Work
    {
        public abstract string Name { get; }
        public abstract int StartHour { get; }
        public abstract int EndHour { get; }
        public abstract float Salary { get; }
        public abstract bool WorkingFromHome { get; }
        public abstract bool FreeEmployee { get; }

        public Guid Id;

        public Guid Worker;
        public Business WorkingCompany;

        public bool IsBusy { get {
                if (Worker != default(Guid))
                    return true;
                else 
                    return false;
                    }
            
        }

        public abstract int StatValue { get; }
        public Work(Business business)
        {
            WorkingCompany = business;
            Id = Guid.NewGuid();
            PlayerInfo.CurrentCity.Vacancy.Add(Id,this);
        }
        public Work()
        {}
        public virtual void WorkProccess()
        {

        }
    }
    public class SelfEmployed: Work
    {
        public override string Name => "Self Employed";
        public override int StartHour => 8;
        public override int EndHour => 18;
        public override int StatValue => 0;
        public override float Salary => 10000f;
        public override bool WorkingFromHome=> true;
        public override bool FreeEmployee => true;
        public override void WorkProccess()
        {}
        public SelfEmployed()
        {
            WorkingCompany = PlayerInfo.CurrentCity.CityLaborExchange;
        }

    }
    public class KinderGartenerYoung : Work
    {
        public override string Name => "KinderGartener";
        public override int StartHour => 9;
        public override int EndHour => 10;
        public override int StatValue => 0;
        public override float Salary => 0f;
        public override bool WorkingFromHome => true;
        public override bool FreeEmployee => true;

        private KinderGarten CurrentKinderGartener;
        public override void WorkProccess()
        {

        }
        public KinderGartenerYoung(Person person)
        {
            WorkingCompany = PlayerInfo.CurrentCity.KinderGartenList.ElementAt(0).Value;
            CurrentKinderGartener = PlayerInfo.CurrentCity.KinderGartenList.ElementAt(0).Value;
            PlayerInfo.CurrentCity.KinderGartenList.ElementAt(0).Value.Students.Add(person.Id);
        }
        ~KinderGartenerYoung()
        {
            CurrentKinderGartener.Students.Remove(Worker);
        }
    }
    public class KinderGartenerOld : Work
    {
        public override string Name => "KinderGartener";
        public override int StartHour => 9;
        public override int EndHour => 18;
        public override int StatValue => 0;
        public override float Salary => 0f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => true;

        private KinderGarten CurrentKinderGartener;
        public override void WorkProccess()
        {

        }
        public KinderGartenerOld(Person person)
        {
            WorkingCompany = PlayerInfo.CurrentCity.KinderGartenList.ElementAt(0).Value;
            CurrentKinderGartener = PlayerInfo.CurrentCity.KinderGartenList.ElementAt(0).Value;
            PlayerInfo.CurrentCity.KinderGartenList.ElementAt(0).Value.Students.Add(person.Id);
        }
        ~KinderGartenerOld()
        {
            CurrentKinderGartener.Students.Remove(Worker);
        }
    }
    public class SchoolStudent : Work
    {
        public override string Name => "School Student";
        public override int StartHour => 9;
        public override int EndHour => 15;
        public override int StatValue => 0;
        public override float Salary => 0f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => true;

        private School CurrentSchool;
        public override void WorkProccess()
        {
           
        }
        public SchoolStudent(Person person)
        {
            WorkingCompany = PlayerInfo.CurrentCity.SchoolList.ElementAt(0).Value;
            CurrentSchool = PlayerInfo.CurrentCity.SchoolList.ElementAt(0).Value;
            PlayerInfo.CurrentCity.SchoolList.ElementAt(0).Value.Students.Add(person.Id);
        }
        ~SchoolStudent()
        {
            CurrentSchool.Students.Remove(Worker);
        }
    }
    public class UniversityStudent : Work
    {
        public override string Name => "University Student";
        public override int StartHour => 8;
        public override int EndHour => 16;
        public override int StatValue => 0;
        public override float Salary => 0f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => true;
        private University CurrentUniversity;
        public override void WorkProccess()
        {
           
        }
       
        public UniversityStudent(Person person)
        {
            WorkingCompany = PlayerInfo.CurrentCity.UniversityList.ElementAt(0).Value;
            CurrentUniversity = PlayerInfo.CurrentCity.UniversityList.ElementAt(0).Value;
            PlayerInfo.CurrentCity.UniversityList.ElementAt(0).Value.Students.Add(person.Id);
        }
        ~UniversityStudent()
        {
            CurrentUniversity.Students.Remove(Worker);
        }
    }
   
    public class Retiree : Work
    {
        public override string Name => "Retiree";
        public override int StartHour => 8;
        public override int EndHour => 9;
        public override int StatValue => 0;
        public override float Salary => 25000f;
        public override bool WorkingFromHome => true;
        public override bool FreeEmployee => true;
        public override void WorkProccess()
        { }
        public Retiree()
        {
            WorkingCompany = PlayerInfo.CurrentCity.CityAministration;
        }
        ~Retiree()
        {
        }
    }
    public class Secretary : Work
    {
        public override string Name => "Secretary";
        public override int StartHour => 9;
        public override int EndHour => 19;
        public override int StatValue => 2;
        public override float Salary => 60000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }

        public Secretary(Business business)
            : base(business)
        { }
    }
    public class Teacher : Work
    {
        public override string Name => "Teacher";
        public override int StartHour => 9;
        public override int EndHour => 18;
        public override int StatValue => 2;
        public override float Salary => 45000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Teacher(Business business)
            : base(business)
        { }
    }
    public class Doctor : Work
    {
        public override string Name => "Secretary";
        public override int StartHour => 8;
        public override int EndHour => 20;
        public override int StatValue => 2;
        public override float Salary => 70000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Doctor(Business business)
            : base(business)
        { }
    }
    public class Mechanic : Work
    {
        public override string Name => "Mechanic";
        public override int StartHour => 9;
        public override int EndHour => 19;
        public override int StatValue => 3;
        public override float Salary => 60000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Mechanic(Business business)
            : base(business)
        { }
    }
    public class Сashier : Work
    {
        public override string Name => "Сashier";
        public override int StartHour => 9;
        public override int EndHour => 19;
        public override int StatValue => 3;
        public override float Salary => 55000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Сashier(Business business)
            : base(business)
        { }
    }
    public class Janitor: Work
    {
        public override string Name => "Janitor";
        public override int StartHour => 8;
        public override int EndHour =>20;
        public override int StatValue => 2;
        public override float Salary => 40000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Janitor(Business business) 
            :base(business)
        { }
    }
    public class Waiter : Work
    {
        public override string Name => "Waiter";
        public override int StartHour => 8;
        public override int EndHour => 20;
        public override int StatValue => 3;
        public override float Salary => 50000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Waiter(Business business)
            : base(business)
        { }
    }
    public class Mayor : Work
    {
        public override string Name => "Mayor";
        public override int StartHour => 8;
        public override int EndHour => 20;
        public override int StatValue => 3;
        public override float Salary => 100000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Mayor(Business business)
            : base(business)
        { }
    }
    public class Manager : Work
    {
        public override string Name => "Manager";
        public override int StartHour => 10;
        public override int EndHour => 19;
        public override int StatValue => 4;
        public override float Salary => 60000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Manager(Business business)
            : base(business)
        { }
    }
    public class Policeman : Work
    {
        public override string Name => "Policeman";
        public override int StartHour => 8;
        public override int EndHour => 20;
        public override int StatValue => 4;
        public override float Salary => 80000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Policeman(Business business)
            : base(business)
        { }
    }
    public class Accountant : Work
    {
        public override string Name => "Accountant";
        public override int StartHour => 9;
        public override int EndHour => 18;
        public override int StatValue =>6;
        public override float Salary => 75000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Accountant(Business business)
            : base(business)
        { }
    }
    public class Director : Work
    {
        public override string Name => "Director";
        public override int StartHour => 10;
        public override int EndHour => 18;
        public override int StatValue => 7;
        public override float Salary => 90000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Director(Business business)
            : base(business)
        { }
    }
    public class HeadChef : Work
    {
        public override string Name => "Head Chef";
        public override int StartHour => 10;
        public override int EndHour => 18;
        public override int StatValue =>4;
        public override float Salary => 75000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public HeadChef(Business business)
            : base(business)
        { }
    }
    public class Cook : Work
    {
        public override string Name => "Cook";
        public override int StartHour => 10;
        public override int EndHour => 18;
        public override int StatValue => 3;
        public override float Salary => 55000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Cook(Business business)
            : base(business)
        { }
    }
    public class Pharmacist : Work
    {
        public override string Name => "Pharmacist";
        public override int StartHour => 10;
        public override int EndHour => 18;
        public override int StatValue => 4;
        public override float Salary => 60000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Pharmacist(Business business)
            : base(business)
        { }
    }
    public class Coach : Work
    {
        public override string Name => "Coach";
        public override int StartHour => 8;
        public override int EndHour => 18;
        public override int StatValue => 3;
        public override float Salary => 45000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Coach(Business business)
            : base(business)
        { }
    }
    public class Barman : Work
    {
        public override string Name => "Barman";
        public override int StartHour => 8;
        public override int EndHour => 18;
        public override int StatValue => 3;
        public override float Salary => 65000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public Barman(Business business)
            : base(business)
        { }
    }
    public class NightBarman : Work
    {
        public override string Name => "Night barman";
        public override int StartHour => 18;
        public override int EndHour => 8;
        public override int StatValue => 3;
        public override float Salary => 67000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public NightBarman(Business business)
            : base(business)
        { }
    }
    public class NightСashier : Work
    {
        public override string Name => "Night cashier";
        public override int StartHour => 19;
        public override int EndHour => 8;
        public override int StatValue => 3;
        public override float Salary => 57000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override void WorkProccess()
        { }
        public NightСashier(Business business)
            : base(business)
        { }
    }
}
