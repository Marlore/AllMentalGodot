using Data.CityData;
using Data.SectionData;
using Godot;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Engine.PlayerEngine
{
    public static class PlayerInfo
    {
        public static City CurrentCity;
        public static Thread CityLive;
        public static void Init()
        {
            CurrentCity = new City();
            CurrentCity.BuildCity();
            var s = CurrentCity.CityApartments.ElementAt(0).Segments.Find(x => x is LivingRoom);
            CurrentCity.PopulateTheCity(2000);
            CityLive = new Thread(CurrentCity.CityLife);
        }
    }
}
