using DenouncesBeasts.Frontend.Models;
using Microsoft.EntityFrameworkCore;

namespace DenouncesBeasts.Frontend.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Denounce> Denounces { get; set; }
    }
}
