using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    public class EFDbContext : DbContext
    {
        public DbSet<TargetTable> TargetTables { get; set; }
        public DbSet<SourceTable> SourceTables { get; set; }

        public EFDbContext() : base(@"Server=localhost; Integrated Security=True; Database=EfDB; MultipleActiveResultSets=true;")
        {
        }
    }

    public class TargetTable
    {
        public int Id { get; set; }

        public string Ref { get; set; }

        public string Salutation { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string TelNo { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

    }

    public class SourceTable
    {
        public int Id { get; set; }

        public string Ref { get; set; }

        public string Salutation { get; set; }

        public string Forename { get; set; }

        public string Surname { get; set; }

        public string TelNo { get; set; }

        public string Email { get; set; }

        public string Country { get; set; }

        public DateTime? DateOfBirth { get; set; }

    }
}
