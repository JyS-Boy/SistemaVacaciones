using System;
using System.Threading.Tasks;
using SistemaVacaciones._02._Negocio.DTOs.Empleados;
using SistemaVacaciones._02._Negocio.Servicios.Empleados;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;

namespace SistemaVacaciones._01._Presentacion.Empleado
{
    public class RegistrarEmpleado
    {
        public static async Task RegistraEmpleadoAsync(VacacionesDbContext context)
        {
            Console.Clear();
            Console.WriteLine("=== Registrar Empleado ===");
            Console.Write("Ingrese los nombres del empleado: ");
            string nombres = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrWhiteSpace(nombres))
            {
                Console.WriteLine("Nombres obligatorios.");
                Console.Write("Ingrese los nombres del empleado: ");
                nombres = Console.ReadLine() ?? string.Empty;
            }

            Console.Write("Ingrese los apellidos del empleado: ");
            string apellidos = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrWhiteSpace(apellidos))
            {
                Console.WriteLine("Apellidos obligatorios.");
                Console.Write("Ingrese los apellidos del empleado: ");
                apellidos = Console.ReadLine() ?? string.Empty;
            }

            Console.Write("Ingrese los días disponibles del empleado: ");
            var diasDisponibles = Console.ReadLine();
            while (!int.TryParse(diasDisponibles, out int diasDisponiblesInt) || diasDisponiblesInt <= 0 || diasDisponiblesInt > 30)
            {
                Console.WriteLine("Los días disponibles deben ser un número entero mayor a cero y menor o igual a 30.");
                Console.Write("Ingrese los días disponibles del empleado: ");
                diasDisponibles = Console.ReadLine();
            }

            var empleadoDTO = new RegistroEmpleadoDTO
            {
                Nombres = nombres.Trim(),
                Apellidos = apellidos.Trim(),
                DiasDisponibles = int.Parse(diasDisponibles)
            };
            try
            {
                var servicioCrearEmpleado = new CrearEmpleado(context);
                await servicioCrearEmpleado.RegistrarAsync(empleadoDTO);
                Console.WriteLine("Empleado registrado exitosamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al registrar el empleado: {ex.Message}");
            }
        }
    }
}
