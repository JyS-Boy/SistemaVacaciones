using SistemaVacaciones._02._Negocio.DTOs.Empleados;
using SistemaVacaciones._02._Negocio.Servicios.Empleados;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;

namespace SistemaVacaciones._01._Presentacion.Empleado
{
    public class ActualizarEmpleado
    {
        public static void Actualizar(VacacionesDbContext context)
        {
            Console.Clear();
            Console.WriteLine("=== Actualizar Empleado ===");

            var listarEmpleado = new ListarEmpleado();
            var empleados = new ListaEmpleado(context).ListEmpleados();
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados para actualizar.");
                return;
            }
            listarEmpleado.MostrarEmpleados(empleados);
            Console.WriteLine();

            var servicio = new ActualizaEmpleado(context);

            Console.Write("Ingrese el id del empleado: ");
            var entradaId = Console.ReadLine();

            if (!int.TryParse(entradaId, out var idSeleccionado) || idSeleccionado <= 0)
            {
                Console.WriteLine("Empleado no existe.");
                return;
            }

            var empleado = servicio.ObtenerId(idSeleccionado);
            if (empleado is null)
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

            var actualizado = servicio.Actualizar(actualizaEmpleadoDto);

            Console.WriteLine(actualizado
                ? "Empleado actualizado exitosamente."
                : "El cliente no existe");
        }
    }
}
