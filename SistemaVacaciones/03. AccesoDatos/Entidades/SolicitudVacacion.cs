using SistemaVacaciones._04._Enum;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._03._AccesoDatos.Entidades
{
    public class SolicitudVacacion
    {
        public int IdSolicitud { get; private set; }
        public Empleado Empleado { get; private set; }
        public int IdEmpleado { get; private set; }
        public DateTime FechaInicio { get; private set; }
        public DateTime FechaFin { get; private set; }
        public int DiasSolicitados { get; private set; }
        public EstadoSolicitud Estado { get; private set; }
        public string MotivoRechazo { get; private set; } = string.Empty;

        public SolicitudVacacion()
        {

        }

        public SolicitudVacacion(Empleado empleado,int idEmpleado, DateTime fechaInicio, DateTime fechaFin, int diasSolicitados, EstadoSolicitud estado, string motivoRechazo)
        {
            if (empleado is null)
            {
                throw new ArgumentNullException(nameof(empleado));
            }

            if (fechaFin.Date < fechaInicio.Date)
            {
                throw new ArgumentException("La fecha fin no puede ser menor a la fecha inicio.");
            }

            if (diasSolicitados <= 0)
            {
                throw new ArgumentException("Los días solicitados deben ser mayores a cero.");
            }

            Empleado = empleado;
            IdEmpleado = idEmpleado;
            FechaInicio = fechaInicio.Date;
            FechaFin = fechaFin.Date;
            DiasSolicitados = diasSolicitados;
            Estado = estado;
            MotivoRechazo = motivoRechazo;
        }
    }
}
