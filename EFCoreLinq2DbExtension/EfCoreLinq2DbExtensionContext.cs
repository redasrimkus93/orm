using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreLinq2DbExtension
{
    public class EfCoreLinq2DbExtensionContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileExport> ProfilesExport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                .UseSqlServer(
                    @"Server=localhost; Integrated Security=True; Database=EfCoreLinq2DbExtension; MultipleActiveResultSets=true;"
                );
    }

    public class Profile
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

    public class ProfileExport
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