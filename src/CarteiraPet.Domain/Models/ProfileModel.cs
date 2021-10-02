using System.Collections.Generic;

namespace CarteiraPet.Domain.Models
{
    public class ProfileModel : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        
        public IEnumerable<PetModel> Pets { get; set; }
    }
}
    