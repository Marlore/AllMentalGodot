using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Plans
{
    public class Plan
    {
        public Action PlannedAction;
        public DateTime PlannedDate;
        public int Duration;
        public Plan(Action plannedAction, DateTime plannedDate, int duration)
        {
            PlannedAction = plannedAction;
            PlannedDate = plannedDate;
            Duration = duration;
        }
    }
}
