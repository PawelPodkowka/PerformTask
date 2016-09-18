using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using PerformTask.Common.Model;

namespace PerformTask.API.DAL
{
    public class NodesContext : DbContext
    {
        public DbSet<NodeEnt> Nodes { get; set; }

        public NodesContext()
            : base("NodesContext")
        {
                
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NodeEnt>().HasKey(x => x.Id);
            modelBuilder.Entity<NodeEnt>().Property(x => x.AdjacentNodesAsString).IsRequired();
        }
    }
}