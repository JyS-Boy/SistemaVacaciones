using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;
using System.Threading.Tasks;

namespace SistemaVacaciones._01._Presentacion.Empleado
{
    public class MenuEmpleado
    {
        public static async Task MostrarMenuEmpleadoAsync(VacacionesDbContext context)
        {
            Console.Clear();
            bool salir = true;
            while (salir)
            {
                
                Console.WriteLine("=== Menú Empleado ===");
                Console.WriteLine("1. Registrar Empleado");
                Console.WriteLine("2. Listar Empleado");
                Console.WriteLine("3. Actualizar Empleado");
                Console.WriteLine("4. Eliminar Empleado");
                Console.WriteLine("5. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");
                string? opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        await RegistrarEmpleado.RegistraEmpleadoAsync(context);
                        break;
                    case "2":
                        await ListarEmpleado.MostrarEmpleadosAsync(context);
                        break;
                    case "3":
                        await ActualizarEmpleado.ActualizarAsync(context);
                        break;
                    case "4":
                        await EliminarEmpleado.EliminarAsync(context);
                        break;
                    case "5":
                        salir = false;
                        break;
                    default:
                        Console.WriteLine("Opción inválida. Intente nuevamente.");
                        break;
                }
                Console.WriteLine();
            }
        }
    }
}
