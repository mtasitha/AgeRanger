using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgeRanger.Web.Models
{
    public class AgeRangerDbContext : DbContext
    {
        public AgeRangerDbContext() : base("AgeRangerEntities")
        {
        }
        
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<AgeGroup> AgeGroups { get; set; }
    }
}
