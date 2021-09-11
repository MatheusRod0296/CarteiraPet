using System;
using System.Reflection.Metadata;

namespace CarteiraPet.Domain.Models
{
    public abstract class MedicationModel: BaseEntity
    {
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public string VeterinarianName { get; set; }
        public string Address { get; set; }
    }
}