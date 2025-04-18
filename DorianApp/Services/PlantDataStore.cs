using System.Collections.Generic;
using DorianApp.Models;

namespace DorianApp.Services
{
    public static class PlantDataStore
    {
        private static readonly List<Plant> _plants = new List<Plant>();

        public static void AddPlant(Plant plant)
        {
            _plants.Add(plant);
        }

        public static List<Plant> GetPlants()
        {
            return _plants;
        }
    }
}