using SistemaVacaciones._04._Enum;
using System;

namespace SistemaVacaciones._02._Negocio.DTOs.Solicitudes
{
    public class ListarSolicitudDTO
    {
        public int IdSolicitud { get; set; }
        public int IdEmpleado { get; set; }
        public string NombreCompletoEmpleado { get; set; } = string.Empty;
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int DiasSolicitados { get; set; }
        public EstadoSolicitud Estado { get; set; }
        public string MotivoRechazo { get; set; } = string.Empty;
    }
}
