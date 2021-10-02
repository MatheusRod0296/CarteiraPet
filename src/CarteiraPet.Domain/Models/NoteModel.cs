using System;

namespace CarteiraPet.Domain.Models
{
    public class NoteModel: BaseEntity
    {
        public NoteModel(): base()
        {
            
        }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        
        public Guid PetId { get; set; }
        public PetModel Pet { get; set; }
    }
}