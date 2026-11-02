using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._03._AccesoDatos.Entidades
{
    public class Empleado
    {
        public int IdEmpleado { get; private set; }
        public string Nombres { get; private set; } = string.Empty;
        public string Apellidos { get; private set; } = string.Empty;
        public int DiasDisponibles { get; private set; }
        public bool IsActive { get; private set; } = true;

        public List<SolicitudVacacion> Solicitudes { get; private set; } = new List<SolicitudVacacion>();

        public Empleado()
        {
            
        }

        public Empleado(string nombres, string apellidos, int diasDisponibles)
        {
            Nombres = nombres;
            Apellidos = apellidos;
            DiasDisponibles = diasDisponibles;
        }

        public void Actualizar(string nombres, string apellidos, int diasDisponibles)
        {
            Nombres = nombres;
            Apellidos = apellidos;
            DiasDisponibles = diasDisponibles;
        }

        public void Desactivar()
        {
            IsActive = false;
        }

        public void DescontarDiasDisponibles(int dias)
        {
            if (dias <= 0)
            {
                throw new ArgumentException("Los días a descontar deben ser mayores a cero.");
            }

            if (dias > DiasDisponibles)
            {
                throw new InvalidOperationException("No hay días disponibles suficientes para aprobar la solicitud.");
            }

            DiasDisponibles -= dias;
        }
    }
    
}
