using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore
{
    public class EFCoreDbContex : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<ProfileExport> ProfilesExport { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                .UseSqlServer(
                    @"Server=localhost; Integrated Security=True; Database=EFCoreBulkExtensions; MultipleActiveResultSets=true;"
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