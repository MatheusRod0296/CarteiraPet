using System;
using System.Collections.Generic;
using System.Data;

namespace CarteiraPet.Domain.Models
{
    public class ProfileModel : BaseEntity
    {
        protected ProfileModel() {}
        public ProfileModel(string email, string name)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; private set; }
        public string Email { get; private set; }

        public IEnumerable<PetModel> Pets { get; set; }

        public void Update(string name)
        {
            Name = name;
        }

        public void SetId(Guid id)
        {
            Id = id;
        }

        public void teste()
        {
            var a = new ProfileModel();
        }
    }
}
