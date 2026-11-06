using SistemaVacaciones._02._Negocio.Servicios.Solicitudes;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;
using System.Threading.Tasks;

namespace SistemaVacaciones._01._Presentacion.Solicitud
{
    public class AprobarSolicitud
    {
        public static async Task AprobarAsync(VacacionesDbContext context)
        {
            var haySolicitudes = await ConsultarSolicitud.ConsultarAsync(context);
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
                await servicio.AprobarAsync(idSolicitud);
                Console.WriteLine("Solicitud aprobada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al aprobar la solicitud: {ex.Message}");
            }
        }
    }
}
