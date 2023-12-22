﻿using Engine.PlayerEngine;
using Entity.Company;
using Entity.People;
using System;
using System.Collections.Generic;
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
        public abstract List<DayOfWeek> WorkingWeek { get;}
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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday,DayOfWeek.Friday };
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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };

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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { };
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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
        public override void WorkProccess()
        { }
        public Teacher(Business business)
            : base(business)
        { }
    }
    public class DoctorFirstShift : Work
    {
        public override string Name => "Secretary";
        public override int StartHour => 8;
        public override int EndHour => 20;
        public override int StatValue => 2;
        public override float Salary => 70000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Sunday};
        public override void WorkProccess()
        { }
        public DoctorFirstShift(Business business)
            : base(business)
        { }
    }
    public class DoctorSecondShift : Work
    {
        public override string Name => "Secretary";
        public override int StartHour => 8;
        public override int EndHour => 20;
        public override int StatValue => 2;
        public override float Salary => 65000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Tuesday,  DayOfWeek.Thursday, DayOfWeek.Saturday };
        public override void WorkProccess()
        { }
        public DoctorSecondShift(Business business)
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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
        public override void WorkProccess()
        { }
        public Mechanic(Business business)
            : base(business)
        { }
    }
    public class СashierFirstShift : Work
    {
        public override string Name => "Сashier";
        public override int StartHour => 9;
        public override int EndHour => 19;
        public override int StatValue => 3;
        public override float Salary => 55000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Sunday };
        public override void WorkProccess()
        { }
        public СashierFirstShift(Business business)
            : base(business)
        { }
    }
    public class СashierSecondShift : Work
    {
        public override string Name => "Сashier";
        public override int StartHour => 9;
        public override int EndHour => 19;
        public override int StatValue => 3;
        public override float Salary => 51000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() {DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday };
        public override void WorkProccess()
        { }
        public СashierSecondShift(Business business)
            : base(business)
        { }
    }
    public class JanitorFirstShift: Work
    {
        public override string Name => "Janitor";
        public override int StartHour => 8;
        public override int EndHour =>20;
        public override int StatValue => 2;
        public override float Salary => 40000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Sunday };
        public override void WorkProccess()
        { }
        public JanitorFirstShift(Business business) 
            :base(business)
        { }
    }
    public class JanitorSecondShift : Work
    {
        public override string Name => "Janitor";
        public override int StartHour => 8;
        public override int EndHour => 20;
        public override int StatValue => 2;
        public override float Salary => 37000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday };
        public override void WorkProccess()
        { }
        public JanitorSecondShift(Business business)
            : base(business)
        { }
    }
    public class WaiterFirstShift : Work
    {
        public override string Name => "Waiter";
        public override int StartHour => 8;
        public override int EndHour => 20;
        public override int StatValue => 3;
        public override float Salary => 50000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Sunday };
        public override void WorkProccess()
        { }
        public WaiterFirstShift(Business business)
            : base(business)
        { }
    }

    public class WaiterSecondShift : Work
    {
        public override string Name => "Waiter";
        public override int StartHour => 8;
        public override int EndHour => 20;
        public override int StatValue => 3;
        public override float Salary => 47000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday };
        public override void WorkProccess()
        { }
        public WaiterSecondShift(Business business)
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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
        public override void WorkProccess()
        { }
        public Manager(Business business)
            : base(business)
        { }
    }
    public class PolicemanFirstShift : Work
    {
        public override string Name => "Policeman";
        public override int StartHour => 8;
        public override int EndHour => 20;
        public override int StatValue => 4;
        public override float Salary => 80000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Sunday };
        public override void WorkProccess()
        { }
        public PolicemanFirstShift(Business business)
            : base(business)
        { }
    }
    public class PolicemanSecondShift : Work
    {
        public override string Name => "Policeman";
        public override int StartHour => 8;
        public override int EndHour => 20;
        public override int StatValue => 4;
        public override float Salary => 77000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday };
        public override void WorkProccess()
        { }
        public PolicemanSecondShift(Business business)
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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday };
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
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Tuesday, DayOfWeek.Wednesday, DayOfWeek.Thursday, DayOfWeek.Friday, DayOfWeek.Saturday };
        public override void WorkProccess()
        { }
        public HeadChef(Business business)
            : base(business)
        { }
    }
    public class CookFirstShift : Work
    {
        public override string Name => "Cook";
        public override int StartHour => 10;
        public override int EndHour => 18;
        public override int StatValue => 3;
        public override float Salary => 55000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Sunday };
        public override void WorkProccess()
        { }
        public CookFirstShift(Business business)
            : base(business)
        { }
    }
    public class CookSecondShift : Work
    {
        public override string Name => "Cook";
        public override int StartHour => 10;
        public override int EndHour => 18;
        public override int StatValue => 3;
        public override float Salary => 51000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday };
        public override void WorkProccess()
        { }
        public CookSecondShift(Business business)
            : base(business)
        { }
    }
    public class PharmacistFirstShift : Work
    {
        public override string Name => "Pharmacist";
        public override int StartHour => 10;
        public override int EndHour => 18;
        public override int StatValue => 4;
        public override float Salary => 60000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Sunday };
        public override void WorkProccess()
        { }
        public PharmacistFirstShift(Business business)
            : base(business)
        { }
    }
    public class PharmacistSecondShift : Work
    {
        public override string Name => "Pharmacist";
        public override int StartHour => 10;
        public override int EndHour => 18;
        public override int StatValue => 4;
        public override float Salary => 56000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday };
        public override void WorkProccess()
        { }
        public PharmacistSecondShift(Business business)
            : base(business)
        { }
    }
    public class CoachFirstShift : Work
    {
        public override string Name => "Coach";
        public override int StartHour => 8;
        public override int EndHour => 18;
        public override int StatValue => 3;
        public override float Salary => 45000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Sunday };
        public override void WorkProccess()
        { }
        public CoachFirstShift(Business business)
            : base(business)
        { }
    }
    public class CoachSecondShift : Work
    {
        public override string Name => "Coach";
        public override int StartHour => 8;
        public override int EndHour => 18;
        public override int StatValue => 3;
        public override float Salary => 42000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday };
        public override void WorkProccess()
        { }
        public CoachSecondShift(Business business)
            : base(business)
        { }
    }
    public class BarmanFirstShift : Work
    {
        public override string Name => "Barman";
        public override int StartHour => 12;
        public override int EndHour => 0;
        public override int StatValue => 3;
        public override float Salary => 65000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Sunday };
        public override void WorkProccess()
        { }
        public BarmanFirstShift(Business business)
            : base(business)
        { }
    }
    public class BarmanSecondShift : Work
    {
        public override string Name => "Barman";
        public override int StartHour => 12;
        public override int EndHour => 0;
        public override int StatValue => 3;
        public override float Salary => 62000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday };
        public override void WorkProccess()
        { }
        public BarmanSecondShift(Business business)
            : base(business)
        { }
    }
    public class NightBarmanFirstShift : Work
    {
        public override string Name => "Night barman";
        public override int StartHour => 0;
        public override int EndHour => 12;
        public override int StatValue => 3;
        public override float Salary => 67000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Sunday };
        public override void WorkProccess()
        { }
        public NightBarmanFirstShift(Business business)
            : base(business)
        { }
    }
    public class NightBarmanSecondShift : Work
    {
        public override string Name => "Night barman";
        public override int StartHour => 0;
        public override int EndHour => 12;
        public override int StatValue => 3;
        public override float Salary => 65000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday };
        public override void WorkProccess()
        { }
        public NightBarmanSecondShift(Business business)
            : base(business)
        { }
    }
    public class NightСashierFirstShift : Work
    {
        public override string Name => "Night cashier";
        public override int StartHour => 19;
        public override int EndHour => 8;
        public override int StatValue => 3;
        public override float Salary => 57000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Monday, DayOfWeek.Wednesday, DayOfWeek.Friday, DayOfWeek.Sunday };
        public override void WorkProccess()
        { }
        public NightСashierFirstShift(Business business)
            : base(business)
        { }
    }
    public class NightСashierSecondShift : Work
    {
        public override string Name => "Night cashier";
        public override int StartHour => 19;
        public override int EndHour => 8;
        public override int StatValue => 3;
        public override float Salary => 54000f;
        public override bool WorkingFromHome => false;
        public override bool FreeEmployee => false;
        public override List<DayOfWeek> WorkingWeek => new List<DayOfWeek>() { DayOfWeek.Tuesday, DayOfWeek.Thursday, DayOfWeek.Saturday };
        public override void WorkProccess()
        { }
        public NightСashierSecondShift(Business business)
            : base(business)
        { }
    }
}
