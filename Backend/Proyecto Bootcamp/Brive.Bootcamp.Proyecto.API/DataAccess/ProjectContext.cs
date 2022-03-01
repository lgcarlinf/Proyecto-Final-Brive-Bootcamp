using Brive.Bootcamp.ProyectoAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Bootcamp.ProyectoAPI.DataAccess
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>(e=> { e.HasKey(p => p.Email);});
        }

        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
