using Entity.ItemLibrary;
using Entity.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Murder
{
    public enum ReasonType
    {
        pleasure,
        hatred, 
        jealousy,
        envies, 
        hiring
    }
    public abstract class MurderTypeData
    {
        public abstract Items Weapon { get; }
        public string ReasonToString;
        public abstract ReasonType Reason { get; }
        public abstract _sex HuntedSex { get; }
        public abstract (int from,int to) HuntedAge {  get; }
    }

}
