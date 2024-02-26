using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DataAccess
{
    public class ParserDbContext : DbContext
    {
        public ParserDbContext()
        {
            Database.EnsureCreated();
            //Database.EnsureDeleted();
        }

        //public virtual DbSet<User> Data { get; set; }
        //public virtual DbSet<GasMeter> GasMeter { get; set; }
        public virtual DbSet<FullLineUser> FullLineUsers { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=ParserDB;Username=postgres;Password=postgres");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
