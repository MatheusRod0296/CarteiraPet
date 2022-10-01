using System;
using System.Collections.Generic;
using CarteiraPet.Domain.Enums;

namespace CarteiraPet.Domain.Models
{
    public class PetModel : BaseEntity
    {
        protected PetModel() {}

        public PetModel(string name, DateTime birthDate, Sex sex, string photo, Guid profileId)
        {
            Name = name;
            BirthDate = birthDate;
            Sex = sex;
            Photo = photo;
            ProfileId = profileId;
        }

        public string Name { get; set; }
        public DateTime BirthDate { get; set; }
        public string Age => CalculateAge();
        public Sex Sex { get; set; }
        public string Photo { get; set; }
        
        public IEnumerable<WeighingModel> Weighings { get; set; }
        public IEnumerable<VaccineModel> Vaccines { get; set; }
        public IEnumerable<NoteModel> Notes { get; set; }

        public Guid ProfileId { get; set; }
        public ProfileModel Profile { get; set; }

        private string CalculateAge()
        {
            var diff = DateTime.Now - BirthDate;
            var years = diff.Days / 365;

            if ( years > 0 ) return $"{years} Anos";

            var months = diff.Days / 30;
            if ( months > 0 ) return $"{months} Meses";

           return $"{diff.Days} Dias";
        }
    }
}
