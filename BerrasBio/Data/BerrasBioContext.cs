#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BerrasBio.Models;

namespace BerrasBio.Data
{
    public class BerrasBioContext : DbContext
    {
        public BerrasBioContext()
        {
        }

        public BerrasBioContext (DbContextOptions<BerrasBioContext> options)
            : base(options)
        {
        }

        public DbSet<BerrasBio.Models.Movie> Movie { get; set; }

        public DbSet<BerrasBio.Models.Ticket> Ticket { get; set; }
        public DbSet<BerrasBio.Models.MovieTheater> MovieTheater { get; set; }
    }
}
