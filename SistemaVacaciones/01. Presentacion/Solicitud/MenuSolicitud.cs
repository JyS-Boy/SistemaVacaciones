using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._01._Presentacion.Solicitud
{
    public class MenuSolicitud
    {
        public static void MostrarMenuSolicitud(VacacionesDbContext context)
        {
            Console.Clear();
            bool salir = true;
            while (salir)
            {
                Console.WriteLine("=== Menú Solicitud de Vacaciones ===");
                Console.WriteLine("1. Registrar Solicitud");
                Console.WriteLine("2. Consultar Solicitud");
                Console.WriteLine("3. Aprobar Solicitud");
                Console.WriteLine("4. Rechazar Solicitud");
                Console.WriteLine("5. Volver al Menú Principal");
                Console.Write("Seleccione una opción: ");
                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        RegistrarSolicitud.Registrar(context);
                        break;
                    case "2":
                        // Lógica para consultar solicitud
                        break;
                    case "3":
                        // Lógica para actualizar solicitud
                        break;
                    case "4":
                        // Lógica para eliminar solicitud
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
