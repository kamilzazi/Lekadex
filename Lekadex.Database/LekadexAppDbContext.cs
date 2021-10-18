using Lekadex.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lekadex.Database
{
    public class LekadexAppDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Prescription> Prescriptions{ get; set; }
        public DbSet<Medicine> Medicines{ get; set; }
        public LekadexAppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
