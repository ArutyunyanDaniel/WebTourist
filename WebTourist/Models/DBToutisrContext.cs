using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebTourist.Models
{
    public partial class DBToutisrContext : DbContext
    {
        public virtual DbSet<Attraction> Attraction { get; set; }
        public virtual DbSet<Route> Route { get; set; }
        public virtual DbSet<RouteAttraction> RouteAttraction { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-2SC6BEJ\SQLEXPRESS;Database=DBToutisr;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attraction>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Coordinate)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Route>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Coordinates).IsRequired();

                entity.Property(e => e.CoordinatesStartingPointsRoute).IsRequired();
            });

            modelBuilder.Entity<RouteAttraction>(entity =>
            {
                entity.Property(e => e.AttractionId).HasColumnName("AttractionID");

                entity.Property(e => e.RouteId).HasColumnName("RouteID");

                entity.HasOne(d => d.Attraction)
                    .WithMany(p => p.RouteAttraction)
                    .HasForeignKey(d => d.AttractionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RouteAttr__Attra__15502E78");

                entity.HasOne(d => d.Route)
                    .WithMany(p => p.RouteAttraction)
                    .HasForeignKey(d => d.RouteId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__RouteAttr__Route__145C0A3F");
            });
        }
    }
}
