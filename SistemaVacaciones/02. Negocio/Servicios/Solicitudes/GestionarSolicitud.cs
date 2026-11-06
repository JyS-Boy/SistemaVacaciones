using Microsoft.EntityFrameworkCore;
using SistemaVacaciones._02._Negocio.DTOs.Solicitudes;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using SistemaVacaciones._03._AccesoDatos.Entidades;
using SistemaVacaciones._04._Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaVacaciones._02._Negocio.Servicios.Solicitudes
{
    public class GestionarSolicitud
    {
        private readonly VacacionesDbContext _context;

        public GestionarSolicitud(VacacionesDbContext context)
        {
            _context = context;
        }

        public async Task<List<ListarSolicitudDTO>> ListarAsync()
        {
            return await _context.SolicitudesVacaciones
                .AsNoTracking()
                .Include(s => s.Empleado)
                .Where(s => s.Estado == EstadoSolicitud.Pendiente)
                .Select(s => new ListarSolicitudDTO
                {
                    IdSolicitud = s.IdSolicitud,
                    IdEmpleado = s.IdEmpleado,
                    NombreCompletoEmpleado = $"{s.Empleado.Nombres} {s.Empleado.Apellidos}",
                    FechaInicio = s.FechaInicio,
                    FechaFin = s.FechaFin,
                    DiasSolicitados = s.DiasSolicitados,
                    Estado = s.Estado,
                    MotivoRechazo = s.MotivoRechazo
                })
                .OrderByDescending(s => s.IdSolicitud)
                .ToListAsync();
        }

        public async Task AprobarAsync(int idSolicitud)
        {
            var solicitud = await ObtenerSolicitudConEmpleadoAsync(idSolicitud);

            if (solicitud is null)
            {
                throw new InvalidOperationException("La solicitud indicada no existe.");
            }

            if (solicitud.Estado != EstadoSolicitud.Pendiente)
            {
                throw new InvalidOperationException("Solo se pueden aprobar solicitudes pendientes.");
            }

            solicitud.Empleado.DescontarDiasDisponibles(solicitud.DiasSolicitados);
            solicitud.Aprobar();
            await _context.SaveChangesAsync();
        }

        public async Task RechazarAsync(int idSolicitud, string motivo)
        {
            var solicitud = await ObtenerSolicitudConEmpleadoAsync(idSolicitud);

            if (solicitud is null)
            {
                throw new InvalidOperationException("La solicitud indicada no existe.");
            }

            solicitud.Rechazar(motivo);
            await _context.SaveChangesAsync();
        }

        private async Task<SolicitudVacacion?> ObtenerSolicitudConEmpleadoAsync(int idSolicitud)
        {
            return await _context.SolicitudesVacaciones
                .Include(s => s.Empleado)
                .FirstOrDefaultAsync(s => s.IdSolicitud == idSolicitud);
        }
    }
}
