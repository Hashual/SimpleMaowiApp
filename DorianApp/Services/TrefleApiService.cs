using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using DorianApp.Models;
using System.Collections.Generic;

namespace DorianApp.Services
{
    public class TrefleApiService
    {
        private readonly HttpClient _httpClient;
        private const string BaseUrl = "https://trefle.io/api/v1/";
        private const string Token = "NCkhMpB123O3ENt8FKBAYPchNjO3ZTiHPK7OFug-xcE";

        public TrefleApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Plant>> GetPlantsAsync()
        {
            var url = $"{BaseUrl}plants/?token={Token}";
            var response = await _httpClient.GetAsync(url);
            var plants = new List<Plant>();

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var data = JObject.Parse(json);
                var plantData = data["data"];

                if (plantData != null)
                {
                    foreach (var plant in plantData)
                    {
                        plants.Add(new Plant
                        {
                            CommonName = plant["common_name"]?.ToString() ?? "Aucune plante trouvée",
                            ImageUrl = plant["image_url"]?.ToString() ?? "",
                            Description = plant["bibliography"]?.ToString() ??
                                        plant["scientific_name"]?.ToString() ??
                                        "Pas de description disponible"
                        });
                    }
                }
            }

            if (plants.Count == 0)
            {
                plants.Add(new Plant { CommonName = "Erreur lors de la récupération" });
            }

            return plants;
        }
    }
}