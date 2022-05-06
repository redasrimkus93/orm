using Microsoft.EntityFrameworkCore;

namespace EFCoreExtensionsPaid
{
    public class EFCoreExtensionsPaidContext : DbContext
    {

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Copy> Copy { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
                .UseSqlServer(
                    @"Server=localhost; Integrated Security=True; Database=EfCorePaidExtensionDB; MultipleActiveResultSets=true;"
                );
    }

    public class Book
    {

        public int BookId { get; set; }
        public string Name { get; set; }

        public int AuthorId { get; set; }
        public virtual Author Author { get; set; }

        public virtual IList<Copy> Copies { get; set; }
    }

    public class Author
    {
        public int AuthorId { get; set; }
        public string FullName { get; set; }
    }

    public class Copy
    {
        public int CopyId { get; set; }
        public virtual Book Book { get; set; }
        public decimal Price { get; set; }
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
}