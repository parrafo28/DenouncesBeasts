
using DenouncesBeasts.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DenouncesBeasts.Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Denounce> Denounces { get; set; }
        public DbSet<Denounzer> Denounzers { get; set; } 

    }
}
