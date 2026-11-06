using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SistemaVacaciones._01._Presentacion.Solicitud
{
    public class MenuSolicitud
    {
        public static async Task MostrarMenuSolicitudAsync(VacacionesDbContext context)
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
                        await RegistrarSolicitud.RegistrarAsync(context);
                        break;
                    case "2":
                        await ConsultarSolicitud.ConsultarAsync(context);
                        break;
                    case "3":
                        await AprobarSolicitud.AprobarAsync(context);
                        break;
                    case "4":
                        await RechazarSolicitud.RechazarAsync(context);
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
