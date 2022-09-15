using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bohemian_API.Models
{
    public class BohemianContext : DbContext
    {
        public BohemianContext(DbContextOptions options) : base(options)
        {
            
        }
        DbSet<Artist> Artists { get; set; }
        DbSet<Album> Albums { get; set; }
        DbSet<Genre> Genre { get; set; }
        DbSet<Song> Songs { get; set; }

    }
}
