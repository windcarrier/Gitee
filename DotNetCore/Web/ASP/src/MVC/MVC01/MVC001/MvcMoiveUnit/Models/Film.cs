using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MvcMoiveUnit.Models
{
    public class Film
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }
    public class FileDBContext :DbContext
    {
        public DbSet<Film> dbSet { get; set; }
    }
}