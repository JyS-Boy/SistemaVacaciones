using SistemaVacaciones._02._Negocio.DTOs.Solicitudes;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using SistemaVacaciones._03._AccesoDatos.Entidades;
using SistemaVacaciones._04._Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace SistemaVacaciones._02._Negocio.Servicios.Solicitudes
{
    public class CrearSolicitud
    {
        private readonly VacacionesDbContext _context;

        public CrearSolicitud(VacacionesDbContext context)
        {
            _context = context;
        }

        public async Task RegistrarAsync(RegistarSolicitudDTO solicitudDto)
        {
            if (solicitudDto.FechaFin.Date < solicitudDto.FechaInicio.Date)
            {
                throw new InvalidOperationException("La fecha fin no puede ser menor que la fecha inicio.");
            }

            var empleado = await _context.Empleados
                .FirstOrDefaultAsync(e => e.IdEmpleado == solicitudDto.IdEmpleado);

            if (empleado is null)
            {
                throw new InvalidOperationException("No existe el empleado indicado.");
            }

            var diasSolicitados = (solicitudDto.FechaFin.Date - solicitudDto.FechaInicio.Date).Days + 1;
            if (diasSolicitados > empleado.DiasDisponibles)
            {
                throw new InvalidOperationException("Los días solicitados superan los días disponibles del empleado.");
            }

            var solicitud = new SolicitudVacacion(
                empleado,
                empleado.IdEmpleado,
                solicitudDto.FechaInicio.Date,
                solicitudDto.FechaFin.Date,
                diasSolicitados,
                EstadoSolicitud.Pendiente,
                string.Empty);

            await _context.SolicitudesVacaciones.AddAsync(solicitud);
            await _context.SaveChangesAsync();
        }
    }
}
