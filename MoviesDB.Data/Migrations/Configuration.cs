using System;
using MoviesDB.Models;

namespace MoviesDB.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MoviesDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(MoviesDbContext context)
        {
            context.Movies.AddOrUpdate(
              m => m.Title,
              new Movie { Title = "Star Wars II", DirectorName = "Lucas", ReleaseDate = new DateTime(1997, 1, 1)},
              new Movie { Title = "Pulp Fiction", DirectorName = "Tarantino", ReleaseDate = new DateTime(1994, 1, 1) },
              new Movie { Title = "Hulk", DirectorName = "Ang Lee", ReleaseDate = new DateTime(2003, 1, 1) },
              new Movie { Title = "The Shawshank Redemption", DirectorName = "Frank Darabont", ReleaseDate = new DateTime(1994, 1, 1) },
              new Movie { Title = "The Godfather", DirectorName = "Francis Ford Coppola", ReleaseDate = new DateTime(1972, 1, 1) },
              new Movie { Title = "The Godfather II", DirectorName = "Francis Ford Coppola", ReleaseDate = new DateTime(1974, 1, 1) },
              new Movie { Title = "The Dark Knight", DirectorName = "Christopher Nolan", ReleaseDate = new DateTime(2008, 1, 1) },
              new Movie { Title = "Schindler's List", DirectorName = "Steven Spielberg", ReleaseDate = new DateTime(1993, 1, 1) },
              new Movie { Title = "Inception", DirectorName = "Christopher Nolan", ReleaseDate = new DateTime(2010, 1, 1) },
              new Movie { Title = "The Pianist", DirectorName = "Roman Polanski", ReleaseDate = new DateTime(2002, 1, 1) },
              new Movie { Title = "Gladiator", DirectorName = "Ridley Scott", ReleaseDate = new DateTime(2000, 1, 1) },
              new Movie { Title = "The Shining", DirectorName = "Stanley Kubrick", ReleaseDate = new DateTime(1980, 1, 1) }
            );
        }
    }
}
