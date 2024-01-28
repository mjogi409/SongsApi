using Microsoft.EntityFrameworkCore;
using RelationshipLearning.Models;

namespace RelationshipLearning
{
    public class MydbContext : DbContext
    {
        public MydbContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Songsdb");
        }


        //public DbSet<Users> Users { get; set; }
        public DbSet<Playlists> Playlists { get; set; }
        public DbSet<Artists> Artists { get; set; }
        public DbSet<Songs> Songs { get; set; }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Songs>()
                .HasOne(_ => _.Artist)
                .WithMany(_ => _.Songs);

            modelBuilder.Entity<Artists>()
                .HasMany(_ => _.Songs)
                .WithOne(_ => _.Artist);

            modelBuilder.Entity<Songs>()
                .HasOne(_ => _.Playlist)
                .WithMany(_ => _.Songs);

            modelBuilder.Entity<Playlists>()
                .HasMany(_ => _.Songs)
                .WithOne(_ => _.Playlist);


        }
    }
}
