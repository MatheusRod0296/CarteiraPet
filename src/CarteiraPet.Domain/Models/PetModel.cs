using System;
using System.Collections.Generic;
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
        public IEnumerable<NoteModel> Notes { get; set; }
        
        public Guid ProfileId { get; set; }
        public ProfileModel Profile { get; set; }
        
    }
}