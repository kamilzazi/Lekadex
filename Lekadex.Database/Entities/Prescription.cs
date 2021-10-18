using Lekadex.Database.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lekadex.Database.Entities
{
    public class Prescription : BaseEntity
    {
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [NotMapped]
        public virtual IEnumerable<Medicine> Medicines { get; set; }
    }
}
