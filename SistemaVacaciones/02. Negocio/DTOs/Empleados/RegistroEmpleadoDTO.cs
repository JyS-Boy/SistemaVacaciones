using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._02._Negocio.DTOs.Empleados
{
    public class RegistroEmpleadoDTO
    {
        public string Nombres { get; set; } = string.Empty;
        public string Apellidos { get; set; } = string.Empty;
        public int DiasDisponibles { get; set; } 
    }
}
