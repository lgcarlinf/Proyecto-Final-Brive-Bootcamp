using Brive.ProyectoFinal.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Brive.ProyectoFinal.Api.Context
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Busquedas> Busquedas { get; set; }
    }
}
