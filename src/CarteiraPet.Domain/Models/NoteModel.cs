using System;

namespace CarteiraPet.Domain.Models
{
    public class NoteModel: BaseEntity
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
    }
}