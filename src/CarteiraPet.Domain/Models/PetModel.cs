using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using CarteiraPet.Domain.Enums;

namespace CarteiraPet.Domain.Models
{
    public class PetModel: BaseEntity
    {
        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public decimal Age { get; set; }
        public Sex Sex { get; set; }
        public IEnumerable<WeighingModel> Weighings { get; set; }
        public IEnumerable<VaccineModel> Vaccines { get; set; }
        public IEnumerable<DewormingModel> Dewormings { get; set; }
        public IEnumerable<MedicationModel> NextMedications { get; set; }
        public IEnumerable<NoteModel> Notes { get; set; }
        
    }
}