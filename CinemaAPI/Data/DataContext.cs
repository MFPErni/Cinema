using CinemaAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace CinemaAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Ticket> TicketList { get; set; }
        public DbSet<Movie> MovieList { get; set; }
        public DbSet<Director> DirectorList { get; set; }
        public DbSet<Viewer> ViewersList { get; set; }
        public DbSet<Genre> GenreList { get; set; }
    }
}
