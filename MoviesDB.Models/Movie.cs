using System;
using System.ComponentModel.DataAnnotations;
using MoviesDB.Models.Attributes;

namespace MoviesDB.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Title { get; set; }

        [MaxLength(100)]
        public string DirectorName { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [FutureDate(ErrorMessage = "Date should be in the past.")]
        public DateTime ReleaseDate { get; set; }
    }
}
