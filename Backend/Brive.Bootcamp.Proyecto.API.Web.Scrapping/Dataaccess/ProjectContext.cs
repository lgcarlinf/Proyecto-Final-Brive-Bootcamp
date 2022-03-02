using Brive.Bootcamp.Proyecto.API.Web.Scrapping.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brive.Bootcamp.Proyecto.API.Web.Scrapping.Dataaccess
{
    public class ProjectContext : DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consultas>(eb => { eb.HasKey(c => new { c.IDBUSQUEDA}); });
        }

        public DbSet<Consultas> Consultas { get; set; }
    }
}
