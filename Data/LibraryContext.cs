using Microsoft.EntityFrameworkCore;
using SOPlabNEW.Models;

namespace SOPlabNEW.Data {
    public class LibraryContext : DbContext {

        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { 

        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Library> Libraries { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
