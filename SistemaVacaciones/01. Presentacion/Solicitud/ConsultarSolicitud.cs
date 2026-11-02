using SistemaVacaciones._02._Negocio.Servicios.Solicitudes;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;

namespace SistemaVacaciones._01._Presentacion.Solicitud
{
    public class ConsultarSolicitud
    {
        public static bool Consultar(VacacionesDbContext context)
        {
            Console.Clear();
            Console.WriteLine("=== Consultar Solicitudes de Vacaciones ===");

            var solicitudes = new GestionarSolicitud(context).Listar();
            if (solicitudes.Count == 0)
            {
                Console.WriteLine("No hay solicitudes registradas.");
                return false;
            }

            foreach (var solicitud in solicitudes)
            {
                Console.WriteLine($"Id Solicitud: {solicitud.IdSolicitud} | Empleado: {solicitud.NombreCompletoEmpleado} (Id: {solicitud.IdEmpleado})");
                Console.WriteLine($"Fecha Inicio: {solicitud.FechaInicio:yyyy-MM-dd} | Fecha Fin: {solicitud.FechaFin:yyyy-MM-dd} | Días: {solicitud.DiasSolicitados}");
                Console.WriteLine($"Estado: {solicitud.Estado} | Motivo Rechazo: {(string.IsNullOrWhiteSpace(solicitud.MotivoRechazo) ? "N/A" : solicitud.MotivoRechazo)}");
                Console.WriteLine(new string('-', 100));
            }

            return true;
        }
    }
}
