using Data.CityData;
using System;
using System.Collections;
using System.Collections.Generic;
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
            CurrentCity.PopulateTheCity(2000);
            CityLive = new Thread(CurrentCity.CityLife);
        }
    }
}
