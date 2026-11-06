using SistemaVacaciones._02._Negocio.Servicios.Empleados;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;
using System.Threading.Tasks;

namespace SistemaVacaciones._01._Presentacion.Empleado
{
    public class EliminarEmpleado
    {
        public static async Task EliminarAsync(VacacionesDbContext context)
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

            Console.WriteLine("=== Eliminar Empleado ===");
            Console.Write("Ingrese el ID del empleado a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int idEmpleado) && idEmpleado > 0)
            {
                var servicio = new ActualizaEmpleado(context);
                var eliminado = await servicio.DesactivarAsync(idEmpleado);
                Console.WriteLine(eliminado
                    ? "Empleado eliminado exitosamente."
                    : "Empleado no encontrado.");
            }
            else
            {
                Console.WriteLine("ID inválido. Intente nuevamente.");
            }
        }
    }
}
