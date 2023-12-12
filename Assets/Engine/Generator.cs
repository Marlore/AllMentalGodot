using Engine.PlayerEngine;
using Entity.Job;
using Entity.People;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Godot;

namespace Engine.Generator
{
    public class PersonGenerator
    {
        private static System.Random rand = new System.Random();
        
        private static string FemaleTextAsset = FileAccess.Open("res://Assets/Resources/Names/female_names.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string MaleTextAsset = FileAccess.Open("res://Assets/Resources/Names/male_names.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string SecondNameTextAsset = FileAccess.Open("res://Assets/Resources/Names/last_names.txt", FileAccess.ModeFlags.Read).GetAsText();

        private static List<string> FemaleNamesList = new List<string>(FemaleTextAsset.Split("\n"));
        private static List<string> MaleNamesList = new List<string>(MaleTextAsset.Split("\n"));
        private static List<string> SecondNamesList = new List<string>(SecondNameTextAsset.Split("\n"));
        public static _orientation GenerateOrientation()
        {
            int orientation = rand.Next(0, 10);
            if (orientation < 2)
                return _orientation.Homo;
            else 
                return _orientation.Hetero;
        }
        public static _sex GenerateSex()
        {
            int sex = rand.Next(0,10);
            if (sex < 5)
                return _sex.Male;
            else 
                return _sex.Female;
        }
        public static string GenerateFirstName(_sex sex)
        {

            if (sex == _sex.Male)
            {
                int num = rand.Next(0, MaleNamesList.Count-1);
                return MaleNamesList[num].Trim();
            }
            else if (sex == _sex.Female)
            {
                int num = rand.Next(0, FemaleNamesList.Count - 1);
                return FemaleNamesList[num].Trim();
            }
            else
                return null;
                
        }
        public static string GenerateLastName()
        {
            int num = rand.Next(0, SecondNamesList.Count - 1);
            return SecondNamesList[num].Trim();
        }
        public static int GenerateNumFromTo(int first, int second) 
        {
            if (first > second)
                return rand.Next(second, first);
            else if (second > first)
                return rand.Next(first,second);
            else if (second == first)
                return first;
            else return 0;
        }
        public static DateTime GenerateBith()
        {
            DateTime MinAge = new DateTime(15, 1, 1);
            DateTime MaxAge = new DateTime(90, 12, 28);
            int Years = rand.Next(MinAge.Year, MaxAge.Year+1);
            int Months = rand.Next(MinAge.Month, MaxAge.Month+1);
            int Days = rand.Next(MinAge.Month, MaxAge.Month+1);
            var date = new DateTime(Years, Months, Days).Ticks;
            return new DateTime(PlayerInfo.CurrentCity.CityTime.Ticks- date);
        }
        public static DateTime GenerateAgeDeath()
        {
            int Years = rand.Next(60, 95);
            int Months = rand.Next(1, 13);
            int Days = rand.Next(1, 28);
            int Hour = rand.Next(1, 24);
            int Minute = rand.Next(1, 60);
            int Seconds = rand.Next(1, 60);
            return new DateTime(Years, Months, Days, Hour, Minute, Seconds);
        }
    }
    public static class CityGenerator
    {
        private static System.Random rand = new System.Random();

        private static string StreetsNamesAsset = FileAccess.Open("res://Assets/Resources/City/StreetsNames.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string CoffeNamesAsset = FileAccess.Open("res://Assets/Resources/City/CoffeNames.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string RestaurantsNamesAsset = FileAccess.Open("res://Assets/Resources/City/RestaurantsNames.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string GroceryStoresNamesAsset = FileAccess.Open("res://Assets/Resources/City/GroceryStoreNames.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string FactoryNamesAsset = FileAccess.Open("res://Assets/Resources/City/FactoryNames.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string PharmacyNamesAsset = FileAccess.Open("res://Assets/Resources/City/PharmacyNames.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string PostOfficeNamesAsset = FileAccess.Open("res://Assets/Resources/City/PostOfficeNames.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string GymNamesAsset = FileAccess.Open("res://Assets/Resources/City/GymNames.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string HospitalNamesAsset = FileAccess.Open("res://Assets/Resources/City/HospitalNames.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string OfficeNamesAsset = FileAccess.Open("res://Assets/Resources/City/OfficeNames.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string SchoolNamesAsset = FileAccess.Open("res://Assets/Resources/City/SchoolNames.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string BarNamesAsset = FileAccess.Open("res://Assets/Resources/City/BarNames.txt", FileAccess.ModeFlags.Read).GetAsText();
        private static string ParkNamesAsset = FileAccess.Open("res://Assets/Resources/City/ParkNames.txt", FileAccess.ModeFlags.Read).GetAsText();

        public static List<string> BarNamesList = new List<string>(BarNamesAsset.Split("\n"));
        public static List<string> SchoolNamesList = new List<string>(SchoolNamesAsset.Split("\n"));
        public static List<string> OfficeNamesList = new List<string>(OfficeNamesAsset.Split("\n"));
        public static List<string> HospitalNamesList = new List<string>(HospitalNamesAsset.Split("\n"));
        public static List<string> StreetsNamesList = new List<string>(StreetsNamesAsset.Split("\n"));
        public static List<string> CoffeNamesList = new List<string>(CoffeNamesAsset.Split("\n"));
        public static List<string> RestaurantsNamesList = new List<string>(RestaurantsNamesAsset.Split("\n"));
        public static List<string> GroceryStoresNamesList = new List<string>(GroceryStoresNamesAsset.Split("\n"));
        public static List<string> FactoryNamesList = new List<string>(FactoryNamesAsset.Split("\n"));
        public static List<string> PharmacyNamesList = new List<string>(PharmacyNamesAsset.Split("\n"));
        public static List<string> PostOfficeList = new List<string>(PostOfficeNamesAsset.Split("\n"));
        public static List<string> GymNamesList = new List<string>(GymNamesAsset.Split("\n"));
        public static List<string> ParkNamesList = new List<string>(ParkNamesAsset.Split("\n"));

        public static string GenerateName(List<string> list)
        {
            int index = rand.Next(0, list.Count);
            var name = list[index];
            list.RemoveAt(index);
            name = name.Trim();
            return name;
        }
     
    }
    
}


