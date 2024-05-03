using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ScientificResearch.Shared.Entities;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Reflection;
using System.Reflection.Emit;

namespace ScientificResearch.API.Data
{
    public class DataContext : IdentityDbContext<User>
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Publication> Publications { get; set; }

        public DbSet<Investigator> Investigators { get; set; }

        public DbSet<searchActivity> searchActivities { get; set; }

        public DbSet<specializedResource> specializedResources { get; set; }

        public DbSet<ScientificInvestigation> ScientificInvestigations { get; set; }

        public DbSet<ResearcherParticipation> ResearcherParticipations { get; set; }

        public DbSet<ResourceAllocation> ResourceAllocations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

