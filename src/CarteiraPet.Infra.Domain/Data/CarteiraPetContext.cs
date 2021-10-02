using CarteiraPet.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace CarteiraPet.Infra.Domain.Data
{
    public class CarteiraPetContext: DbContext
    {
        public CarteiraPetContext (DbContextOptions<CarteiraPetContext> options)
            : base(options)
        {
        }

        public DbSet<ProfileModel> Profile { get; set; }
        public DbSet<PetModel> Pet { get; set; }
        public DbSet<WeighingModel> Weighing { get; set; }
        public DbSet<VaccineModel> Vaccine { get; set; }
        // public DbSet<DewormingModel> Deworming { get; set; }
        public DbSet<NoteModel> Note { get; set; }

    }
}