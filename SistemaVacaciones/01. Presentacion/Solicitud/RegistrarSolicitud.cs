using SistemaVacaciones._02._Negocio.DTOs.Solicitudes;
using SistemaVacaciones._02._Negocio.Servicios.Solicitudes;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;

namespace SistemaVacaciones._01._Presentacion.Solicitud
{
    public class RegistrarSolicitud
    {
        public static void Registrar(VacacionesDbContext context)
        {
            Console.Clear();
            Console.WriteLine("=== Registrar Solicitud de Vacaciones ===");

            Console.Write("Ingrese el id del empleado: ");
            var entradaId = Console.ReadLine();
            while (!int.TryParse(entradaId, out int idEmpleado) || idEmpleado <= 0)
            {
                Console.WriteLine("El id del empleado debe ser un número entero mayor a cero.");
                Console.Write("Ingrese el id del empleado: ");
                entradaId = Console.ReadLine();
            }

            Console.Write("Ingrese la fecha de inicio (yyyy-MM-dd): ");
            var entradaFechaInicio = Console.ReadLine();
            while (!DateTime.TryParse(entradaFechaInicio, out DateTime fechaInicio))
            {
                Console.WriteLine("Formato de fecha inválido.");
                Console.Write("Ingrese la fecha de inicio (yyyy-MM-dd): ");
                entradaFechaInicio = Console.ReadLine();
            }

            Console.Write("Ingrese la fecha fin (yyyy-MM-dd): ");
            var entradaFechaFin = Console.ReadLine();
            while (!DateTime.TryParse(entradaFechaFin, out DateTime fechaFin))
            {
                Console.WriteLine("Formato de fecha inválido.");
                Console.Write("Ingrese la fecha fin (yyyy-MM-dd): ");
                entradaFechaFin = Console.ReadLine();
            }

            var solicitudDto = new RegistarSolicitudDTO
            {
                IdEmpleado = int.Parse(entradaId),
                FechaInicio = DateTime.Parse(entradaFechaInicio),
                FechaFin = DateTime.Parse(entradaFechaFin)
            };

            try
            {
                var crearSolicitud = new CrearSolicitud(context);
                crearSolicitud.Registrar(solicitudDto);
                Console.WriteLine("Solicitud registrada exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar la solicitud: {ex.Message}");
            }
        }
    }
}
