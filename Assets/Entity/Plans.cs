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
        public List<Guid> InvitedPeople;
        public Plan(Guid plannedPlace, DateTime plannedDate, int duration, Guid person)
        {
            PlannedPlace = plannedPlace;
            PlannedDate = plannedDate;
            Duration = duration;
            InvitedPeople.Add(person);
        }
        public void Invite(Guid person)=> InvitedPeople.Add(person);
    }

}
