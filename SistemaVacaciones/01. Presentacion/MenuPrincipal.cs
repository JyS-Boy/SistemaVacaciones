using SistemaVacaciones._01._Presentacion.Empleado;
using SistemaVacaciones._01._Presentacion.Solicitud;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._01._Presentacion
{
    public class MenuPrincipal
    {
        public static void MostrarMenu(VacacionesDbContext context)
        {
            
            bool salir = true;
            while (salir)
            {
                Console.Clear();
                Console.WriteLine("=== Menú Principal ===");
                Console.WriteLine("1. Gestionar Empleados");
                Console.WriteLine("2. Gestionar Solicitudes de Vacaciones");
                Console.WriteLine("3. Salir");
                Console.Write("Seleccione una opción: ");
                string? opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        MenuEmpleado.MostrarMenuEmpleado(context);
                        break;
                    case "2":
                        MenuSolicitud.MostrarMenuSolicitud(context);
                        break;
                    case "3":
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
