using System;

namespace CarteiraPet.Domain.Models
{
    public class WeighingModel: BaseEntity
    {
        public WeighingModel(decimal weight, DateTime birthDate )
        {
            Weight = weight;
            WeighingDate = DateTime.Now;
            LifeTimeByMonths = Convert.ToInt32((birthDate - WeighingDate).TotalDays / 30);
        }
        
        public decimal Weight { get; }
        public int LifeTimeByMonths { get; }
        public DateTime WeighingDate { get; }
    }
}