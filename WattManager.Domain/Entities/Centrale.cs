
using System.Text.Json.Serialization;
namespace WattManager.Domain.Entities
{
    public class Centrale
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public double CapaciteMax { get; set; }
        public string TypeEnergie { get; set; } // Solaire, Nucléaire, Éolien

        // Clé étrangère vers l'Ingénieur qui gère la centrale (Optionnelle)
        public int? IngenieurId { get; set; }
        
        // Propriété de navigation (Objet complet lié)
        [JsonIgnore]
        public Ingenieur? Ingenieur { get; set; }
    }
}