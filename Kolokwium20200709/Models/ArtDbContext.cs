using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium20200709.Models
{
    public class ArtDbContext : DbContext
    {
        public DbSet<Painting> Paintings { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Art_Movement> Art_Movements { get; set; }

        public ArtDbContext()
        {

        }

        public ArtDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Art_Movement>().HasOne<Artist>(a => a.Founder).WithOne(ar => ar.Art_Movement).HasForeignKey<Artist>(ar => ar.IdArtMovement);
            modelBuilder.Entity<Artist>().HasMany<Painting>(a => a.PaintingsCreated).WithOne(p => p.Artist).HasForeignKey(p => p.IdArtist);
            modelBuilder.Entity<Artist>().HasMany<Painting>(a => a.PaintingsCoCreated).WithOne(p => p.CoArtist).HasForeignKey(p => p.IdCoArtist);

        }
    }
}
