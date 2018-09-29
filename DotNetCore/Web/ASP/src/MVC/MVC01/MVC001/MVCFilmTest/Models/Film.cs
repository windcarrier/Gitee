using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCFilmTest.Models
{
    public class Film
    {
        public int ID { get; set; }
        public string Name { get; set; }
        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode =true)]
        public DateTime DateTime { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
    public class FilmDBContext : DbContext
    {
        public DbSet<Film> FilmdbSet { get; set; }
    }
}