using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._02._Negocio.DTOs.Solicitudes
{
    public class RegistarSolicitudDTO
    {
        public int IdEmpleado { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
    }
}
