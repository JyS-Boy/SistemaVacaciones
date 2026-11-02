using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVacaciones._03._AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._03._AccesoDatos.Configuraciones
{
    public class EmpleadoConfiguracion : IEntityTypeConfiguration<Empleado>
    {
        public void Configure(EntityTypeBuilder<Empleado> builder)
        {
            builder.ToTable("Empleados");
            builder.HasKey(e => e.IdEmpleado);
            builder.Property(e => e.Nombres).IsRequired().HasMaxLength(100);
            builder.Property(e => e.Apellidos).IsRequired().HasMaxLength(100);
            builder.Property(e => e.DiasDisponibles).IsRequired();
            builder.HasMany(e => e.Solicitudes)
                .WithOne(s => s.Empleado)
                .HasForeignKey(s => s.IdEmpleado)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
