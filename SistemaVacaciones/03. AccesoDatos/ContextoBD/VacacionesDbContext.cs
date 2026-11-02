using Microsoft.EntityFrameworkCore;
using SistemaVacaciones._03._AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._03._AccesoDatos.ContextoBD
{
    public class VacacionesDbContext : DbContext
    {
        public VacacionesDbContext()
        {
            
        }
        public VacacionesDbContext(DbContextOptions<VacacionesDbContext> options) : base(options)
        {
        }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<SolicitudVacacion> SolicitudesVacaciones { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1500; Database = BdVacaciones; User Id=sa; Password=Password2026; encrypt=false;");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VacacionesDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
