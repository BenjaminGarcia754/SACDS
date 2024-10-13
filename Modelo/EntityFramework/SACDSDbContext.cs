using Microsoft.EntityFrameworkCore;
using SACDS.Modelo.EntityFramework;

namespace SACDS.Modelo.EntityFramework
{
    public class SADCDSDbContext : DbContext
    {
        public DbSet<Cita> Citas { get; set; }
        public DbSet<DonacionUrgente> DonacionUrgentes { get; set; }
        public DbSet<Donador> donadors { get; set; }
        public DbSet<TipoDonacion> tipoDonacions { get; set; }

        public SADCDSDbContext(DbContextOptions<SADCDSDbContext> options) : base(options)
        {

        }

        public SADCDSDbContext()
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}
