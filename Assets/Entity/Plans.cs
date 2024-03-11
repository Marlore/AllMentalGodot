using Data.SectionData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.People;

namespace Entity.Plans
{
    public class Plan
    {
        public Segment PlannedPlace;
        public DateTime PlannedDate;
        public int Duration;
        public Guid Id;
        public List<Person> PeopleOnDate = new List<Person>();
        public Plan(Segment plannedPlace, DateTime plannedDate, int duration, Guid id, List<Person> people)
        {
            PlannedPlace = plannedPlace;
            PlannedDate = plannedDate;
            Duration = duration;
            Id = id;
            PeopleOnDate.AddRange(people);
        }
    }

}
