using Lekadex.Database.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Lekadex.Database
{
    public class DoctorRepository : BaseRepository<Doctor>, IDoctorRepository
    {
        protected override DbSet<Doctor> DbSet => mDbContext.Doctors;

        public DoctorRepository(LekadexAppDbContext dbContext) : base(dbContext)
        {

        }
        public IEnumerable<Doctor> GetAllDoctors()
        {
            return DbSet/*.Include(x => x.Prescriptions).ThenInclude(x => x.Medicines)*/.Select(x => x);
            //return DbSet.Select(x => x); // sprawdzic czy to jednak nie będzie działać
        }
    }
}
