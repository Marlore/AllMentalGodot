using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Plans
{
    public class Plan
    {
        public Guid PlannedPlace;
        public DateTime PlannedDate;
        public int Duration;
        public Guid Id;
        public Plan(Guid plannedPlace, DateTime plannedDate, int duration, Guid id)
        {
            PlannedPlace = plannedPlace;
            PlannedDate = plannedDate;
            Duration = duration;
            Id = id;
        }
    }

}
