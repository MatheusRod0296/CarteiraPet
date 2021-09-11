using System;

namespace CarteiraPet.Domain.Models
{
    public class BaseEntity
    {
        public BaseEntity()
        {
            Id = new Guid();
        }
        public Guid Id { get; }
    }
}