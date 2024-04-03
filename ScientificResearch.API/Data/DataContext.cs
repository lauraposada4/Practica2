using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Emit;

namespace ScientificResearch.API.Data
{
    public class DataContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Publication> Publications { get; set; }

        public DbSet<Investigador> Investigadors { get; set; }

        public DbSet<searchActivity> searchActivities { get; set; }

        public DbSet<specializedResource> specializedResources { get; set; }

        public DbSet<ScientificInvestigation> ScientificInvestigations { get; set; }
  

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

