namespace DorianApp.Models
{
    public class Plant
    {
        public string CommonName { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
        public string ScientificName { get; set; }

        public Plant()
        {
            CommonName = "Aucune plante trouvée";
            ImageUrl = "";
            Description = "Pas de description disponible";
            ScientificName = "Nom scientifique inconnu";
        }
    }
}