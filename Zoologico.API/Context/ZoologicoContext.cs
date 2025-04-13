using Microsoft.EntityFrameworkCore;
using Zoologico.API.Models;

namespace Zoologico.API.Context
{
    public class ZoologicoContext : DbContext
    {
        public ZoologicoContext(DbContextOptions<ZoologicoContext> options): base(options) { }

        public DbSet<AnimalModel> Animais { get; set; }
        public DbSet<CuidadoModel> Cuidados { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimalModel>().HasMany(x => x.Cuidados)
                .WithMany(x => x.Animais);
        }
    }
}
