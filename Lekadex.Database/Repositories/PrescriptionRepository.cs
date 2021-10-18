using Lekadex.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lekadex.Database
{
    public class PrescriptionRepository : BaseRepository<Prescription>, IPrescriptionRepository
    {
        protected override DbSet<Prescription> DbSet => mDbContext.Prescriptions;

        public PrescriptionRepository(LekadexAppDbContext dbContext) : base(dbContext)
        {

        }

        public IEnumerable<Prescription> GetAllPrescriptions()
        {
            return DbSet/*.Include(x => x.Medicines)*/.Select(x => x);
        }
    }
}
 