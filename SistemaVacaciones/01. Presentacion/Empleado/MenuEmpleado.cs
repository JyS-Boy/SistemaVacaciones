using SistemaVacaciones._02._Negocio.Servicios.Empleados;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._01._Presentacion.Empleado
{
    public class MenuEmpleado
    {
        public static void MostrarMenuEmpleado(VacacionesDbContext context)
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
                        RegistrarEmpleado.RegistraEmpleado(context);
                        break;
                    case "2":
                        var listarEmpleado = new ListarEmpleado();
                        var empleados = new ListaEmpleado(context).ListEmpleados();
                        listarEmpleado.MostrarEmpleados(empleados);
                        break;
                    case "3":
                        ActualizarEmpleado.Actualizar(context);
                        break;
                    case "4":
                        //EliminarEmpleado.Eliminar(context);
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
