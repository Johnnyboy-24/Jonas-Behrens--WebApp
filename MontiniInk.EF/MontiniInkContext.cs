using System;
using Microsoft.EntityFrameworkCore;
using MontiniInk.Model;

namespace MontiniInk.EF

{
    public class MontiniInkContext : DbContext
    {
        public DbSet<User> Users {get; set;}
        public DbSet<Request> Requests {get; set;}        
        public DbSet<BlogPost> Posts {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>();
            modelBuilder.Entity<Request>();
            modelBuilder.Entity<BlogPost>();           

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connection_string= string.Format("Host={0};Username={1};Password={2};Database={3}",
            GetFromEnvironmentOrDefault("POSTGRESQL_HOST", "localhost"),
            GetFromEnvironmentOrDefault("POSTGRESQL_USER", "postgres"),
            GetFromEnvironmentOrDefault("POSTGRESQL_PASSWORD", "mysecretpassword"),
            GetFromEnvironmentOrDefault("POSTGRESQL_DATABASE", "postgres"));
            optionsBuilder.UseNpgsql(connection_string);
        }
        private string GetFromEnvironmentOrDefault(string key, string def)
        {
            string var = Environment.GetEnvironmentVariable(key);
            if (var ==null || var ==String.Empty)
                return def;
            else 
                return var;
        }
    }
}