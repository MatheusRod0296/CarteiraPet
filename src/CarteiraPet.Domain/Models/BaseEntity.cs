using System;

namespace CarteiraPet.Domain.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; protected set; }
    }
}
