using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._02._Negocio.DTOs.Empleados
{
    public class ActualizarEmpleadoDTO
    {
        public int IdEmpleado { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string Apellido { get; set; } = string.Empty;
        public int DiasDisponibles { get; set; }
    }
}
