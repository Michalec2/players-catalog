using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using players_catalog.Data.Models;

namespace players_catalog.Data
{
    public class DataContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Coach> Coaches { get; set; }
        
        public DbSet<Player> Players { get; set; }
        
        public DbSet<Team> Teams { get; set; }
        
        public DbSet<User> Users { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relacja one-to-many (Team -> Players)
            modelBuilder.Entity<Team>()
                .HasMany(t => t.Players)
                .WithOne(p => p.Team)
                .HasForeignKey(p => p.TeamId);

            // Relacja one-to-many (Coach -> Teams)
            modelBuilder.Entity<Coach>()
                .HasMany(c => c.Teams)
                .WithOne(t => t.Coach)
                .HasForeignKey(t => t.CoachId);
        }
    }
}