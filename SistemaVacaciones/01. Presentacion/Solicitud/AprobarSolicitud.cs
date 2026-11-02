using SistemaVacaciones._02._Negocio.Servicios.Solicitudes;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;

namespace SistemaVacaciones._01._Presentacion.Solicitud
{
    public class AprobarSolicitud
    {
        public static void Aprobar(VacacionesDbContext context)
        {
            var haySolicitudes = ConsultarSolicitud.Consultar(context);
            if (!haySolicitudes)
            {
                return;
            }

            Console.Write("Ingrese el id de la solicitud a aprobar: ");
            if (!int.TryParse(Console.ReadLine(), out int idSolicitud) || idSolicitud <= 0)
            {
                Console.WriteLine("El id de la solicitud debe ser un número entero mayor a cero.");
                return;
            }

            try
            {
                var servicio = new GestionarSolicitud(context);
                servicio.Aprobar(idSolicitud);
                Console.WriteLine("Solicitud aprobada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al aprobar la solicitud: {ex.Message}");
            }
        }
    }
}
