using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Locations
{

    public interface ILocations
    {
        string Adress { get; set; }
        List<Guid> PeopleInside { get; set; }
    }
       
}


