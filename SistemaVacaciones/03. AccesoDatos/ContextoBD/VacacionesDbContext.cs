using Microsoft.EntityFrameworkCore;
using SistemaVacaciones._03._AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._03._AccesoDatos.ContextoBD
{
    public class VacacionesDbContext (DbContextOptions<VacacionesDbContext> options) : DbContext(options)
    {
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<SolicitudVacacion> SolicitudesVacaciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(VacacionesDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
