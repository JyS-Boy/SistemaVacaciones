using SistemaVacaciones._02._Negocio.Servicios.Empleados;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._01._Presentacion.Empleado
{
    public class EliminarEmpleado
    {
        public static void Eliminar(VacacionesDbContext context)
        {
            Console.Clear();

            var listarEmpleado = new ListarEmpleado();
            var empleados = new ListaEmpleado(context).ListEmpleados();
            if (empleados.Count == 0)
            {
                Console.WriteLine("No hay empleados registrados para actualizar.");
                return;
            }
            listarEmpleado.MostrarEmpleados(empleados);
            Console.WriteLine();

            Console.WriteLine("=== Eliminar Empleado ===");
            Console.Write("Ingrese el ID del empleado a eliminar: ");
            if (int.TryParse(Console.ReadLine(), out int idEmpleado))
            {
                var empleado = context.Empleados.Find(idEmpleado);
                if (empleado != null && empleado.IsActive)
                {
                    empleado.Desactivar();
                    context.SaveChanges();
                    Console.WriteLine("Empleado eliminado exitosamente.");
                }
                else
                {
                    Console.WriteLine("Empleado no encontrado.");
                }
            }
            else
            {
                Console.WriteLine("ID inválido. Intente nuevamente.");
            }
        }
    }
}
