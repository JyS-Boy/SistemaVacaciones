using SistemaVacaciones._02._Negocio.DTOs.Empleados;
using SistemaVacaciones._02._Negocio.Servicios.Empleados;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;
using System.Threading.Tasks;

namespace SistemaVacaciones._01._Presentacion.Empleado
{
    public class ActualizarEmpleado
    {
        public static async Task ActualizarAsync(VacacionesDbContext context)
        {
            Console.Clear();

            var listarEmpleado = new ListarEmpleado();
            var empleados = await new ListaEmpleado(context).ListEmpleadosAsync();
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados para actualizar.");
                return;
            }
            listarEmpleado.MostrarEmpleados(empleados);
            Console.WriteLine();

            var servicio = new ActualizaEmpleado(context);
            Console.WriteLine("=== Actualizar Empleado ===");
            Console.Write("Ingrese el id del empleado a actualizar: ");
            var entradaId = Console.ReadLine();

            if (!int.TryParse(entradaId, out var idSeleccionado) || idSeleccionado <= 0)
            {
                Console.WriteLine("Empleado no existe.");
                return;
            }

            var empleado = await servicio.ObtenerIdAsync(idSeleccionado);
            if (empleado is null || !empleado.IsActive)
            {
                Console.WriteLine("Empleado no existe");
                return;
            }

            Console.Write("Ingrese los nombres del empleado: ");
            var nombres = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrWhiteSpace(nombres))
            {
                Console.WriteLine("Nombres y apellidos son obligatorios.");
                Console.Write("Ingrese los nombres del empleado: ");
                nombres = Console.ReadLine() ?? string.Empty;
            }

            Console.Write("Ingrese los apellidos del empleado: ");
            var apellidos = Console.ReadLine() ?? string.Empty;
            while (string.IsNullOrWhiteSpace(apellidos))
            {
                Console.WriteLine("Nombres y apellidos son obligatorios.");
                Console.Write("Ingrese los apellidos del empleado: ");
                apellidos = Console.ReadLine() ?? string.Empty;
            }

            Console.Write("Ingrese los días disponibles del empleado: ");
            var diasDisponibles  = Console.ReadLine();
            while (!int.TryParse(diasDisponibles, out int diasDisponiblesInt) || diasDisponiblesInt <= 0 || diasDisponiblesInt > 30)
            {
                Console.WriteLine("Los días disponibles deben ser un número entero mayor a cero y menor o igual a 30.");
                Console.Write("Ingrese los días disponibles del empleado: ");
                diasDisponibles = Console.ReadLine();
            }

            var actualizaEmpleadoDto = new ActualizarEmpleadoDTO
            {
                IdEmpleado = idSeleccionado,
                Nombre = nombres.Trim(),
                Apellido = apellidos.Trim(),
                DiasDisponibles = int.Parse(diasDisponibles)
            };

            var actualizado = await servicio.ActualizarAsync(actualizaEmpleadoDto);

            Console.WriteLine(actualizado
                ? "Empleado actualizado exitosamente."
                : "El cliente no existe");
        }
    }
}
