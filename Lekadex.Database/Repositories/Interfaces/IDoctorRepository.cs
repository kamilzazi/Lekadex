using Lekadex.Database.Entities;
using System.Collections.Generic;

namespace Lekadex.Database
{
    public interface IDoctorRepository : IRepository<Doctor>
    {
        IEnumerable<Doctor> GetAllDoctors();
    }
}
