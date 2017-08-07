using MoviesDB.Models;

namespace MoviesDB.Data
{
    using System.Data.Entity;

    public class MoviesDbContext : DbContext
    {
        public MoviesDbContext()
            : base("name=MoviesDbContext")
        {
        }

        public virtual DbSet<Movie> Movies { get; set; }
    }
}