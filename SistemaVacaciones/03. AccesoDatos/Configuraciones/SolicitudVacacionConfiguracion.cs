using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SistemaVacaciones._03._AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._03._AccesoDatos.Configuraciones
{
    public class SolicitudVacacionConfiguracion : IEntityTypeConfiguration<SolicitudVacacion>
    {
        public void Configure(EntityTypeBuilder<SolicitudVacacion> builder)
        {
            builder.ToTable("SolicitudesVacaciones");
            builder.HasKey(s => s.IdSolicitud);
            builder.Property(s => s.FechaInicio).IsRequired();
            builder.Property(s => s.FechaFin).IsRequired();
            builder.Property(s => s.DiasSolicitados).IsRequired();
            builder.Property(s => s.Estado).IsRequired().HasMaxLength(50);
            builder.Property(s => s.MotivoRechazo).HasMaxLength(500);
            builder.HasOne(s => s.Empleado)
                .WithMany(e => e.Solicitudes)
                .HasForeignKey(s => s.IdEmpleado)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
