using Microsoft.EntityFrameworkCore;
using WattManager.Domain.Entities;

namespace WattManager.Infrastructure.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Déclaration de nos tables SQL
        public DbSet<Centrale> Centrales { get; set; }
        public DbSet<Ingenieur> Ingenieurs { get; set; }

        // Fluent API : Configuration des règles de la base de données
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuration de la table Ingenieurs
            modelBuilder.Entity<Ingenieur>(entity =>
            {
                entity.ToTable("ingenieurs"); 
                entity.HasKey(e => e.Id);     
                entity.Property(e => e.Nom).IsRequired().HasMaxLength(50); 
            });

            // Configuration de la table Centrales
            modelBuilder.Entity<Centrale>(entity =>
            {
                entity.ToTable("centrales");
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Nom).IsRequired().HasMaxLength(100);

                // Configuration de la relation One-to-Many
                entity.HasOne(c => c.Ingenieur)          
                    .WithMany(i => i.Centrales)         
                    .HasForeignKey(c => c.IngenieurId)  
                    .OnDelete(DeleteBehavior.SetNull);  
            });
        }
    }
}