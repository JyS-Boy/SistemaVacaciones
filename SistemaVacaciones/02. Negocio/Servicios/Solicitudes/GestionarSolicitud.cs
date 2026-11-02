using Microsoft.EntityFrameworkCore;
using SistemaVacaciones._02._Negocio.DTOs.Solicitudes;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using SistemaVacaciones._03._AccesoDatos.Entidades;
using SistemaVacaciones._04._Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SistemaVacaciones._02._Negocio.Servicios.Solicitudes
{
    public class GestionarSolicitud
    {
        private readonly VacacionesDbContext _context;

        public GestionarSolicitud(VacacionesDbContext context)
        {
            _context = context;
        }

        public List<ListarSolicitudDTO> Listar()
        {
            return _context.SolicitudesVacaciones
                .Include(s => s.Empleado)
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
                .ToList();
        }

        public void Aprobar(int idSolicitud)
        {
            var solicitud = ObtenerSolicitudConEmpleado(idSolicitud);

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
            _context.SaveChanges();
        }

        public void Rechazar(int idSolicitud, string motivo)
        {
            var solicitud = ObtenerSolicitudConEmpleado(idSolicitud);

            if (solicitud is null)
            {
                throw new InvalidOperationException("La solicitud indicada no existe.");
            }

            solicitud.Rechazar(motivo);
            _context.SaveChanges();
        }

        private SolicitudVacacion? ObtenerSolicitudConEmpleado(int idSolicitud)
        {
            return _context.SolicitudesVacaciones
                .Include(s => s.Empleado)
                .FirstOrDefault(s => s.IdSolicitud == idSolicitud);
        }
    }
}
