using System.Collections.Generic;

namespace WattManager.Domain.Entities
{
    public class Ingenieur
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Specialite { get; set; }

        // Relation One-to-Many : Un ingénieur peut superviser plusieurs centrales 
        public List<Centrale> Centrales { get; set; } = new List<Centrale>();
    }
}