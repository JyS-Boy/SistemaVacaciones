using SistemaVacaciones._02._Negocio.Servicios.Solicitudes;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;
using System.Threading.Tasks;

namespace SistemaVacaciones._01._Presentacion.Solicitud
{
    public class RechazarSolicitud
    {
        public static async Task RechazarAsync(VacacionesDbContext context)
        {
            var haySolicitudes = await ConsultarSolicitud.ConsultarAsync(context);
            if (!haySolicitudes)
            {
                return;
            }

            Console.Write("Ingrese el id de la solicitud a rechazar: ");
            if (!int.TryParse(Console.ReadLine(), out int idSolicitud) || idSolicitud <= 0)
            {
                Console.WriteLine("El id de la solicitud debe ser un número entero mayor a cero.");
                return;
            }

            Console.Write("Ingrese el motivo de rechazo: ");
            var motivo = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(motivo))
            {
                Console.WriteLine("El motivo de rechazo es obligatorio.");
                return;
            }

            try
            {
                var servicio = new GestionarSolicitud(context);
                await servicio.RechazarAsync(idSolicitud, motivo);
                Console.WriteLine("Solicitud rechazada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al rechazar la solicitud: {ex.Message}");
            }
        }
    }
}
