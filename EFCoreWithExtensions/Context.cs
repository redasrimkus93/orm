using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreWithExtensions
{
    public class Context : DbContext
    {
        public DbSet<Profiles> Profiles { get; set; }
        public DbSet<TargetTable> ProfilesExport { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                .UseSqlServer(
                    @"Server=localhost; Integrated Security=True; Database=Linq2DB; MultipleActiveResultSets=true;Column Encryption Setting=enabled;");
    }

    public class Profiles
    {
        public int Id { get; set; }

        public string Ref { get; set; }

        public string Surname { get; set; }
    }

    public class TargetTable
    {
        public int Id { get; set; }

        public string Ref { get; set; }

        public string Surname { get; set; }
    }


}
