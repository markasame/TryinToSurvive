using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TryinToSurvive
{
    public class userDataContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data source = Datafile.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>()
                .HasDiscriminator<string>("RecipeType")
                .HasValue<Recipe>("Recipe") // Default type for the base class
                .HasValue<Alergic>("Alergic"); // Type for the derived class

            base.OnModelCreating(modelBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipe { get; set; }
    }

}

