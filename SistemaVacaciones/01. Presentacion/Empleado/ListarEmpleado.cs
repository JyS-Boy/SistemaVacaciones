using SistemaVacaciones._02._Negocio.DTOs.Empleados;
using SistemaVacaciones._02._Negocio.Servicios.Empleados;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SistemaVacaciones._01._Presentacion.Empleado
{
    public class ListarEmpleado
    {
        public static async Task MostrarEmpleadosAsync(VacacionesDbContext context)
        {
            var empleados = await new ListaEmpleado(context).ListEmpleadosAsync();
            var listarEmpleado = new ListarEmpleado();
            listarEmpleado.MostrarEmpleados(empleados);
        }

        public void MostrarEmpleados(List<ListarClienteDTO> empleados)
        {
            Console.Clear();
            Console.WriteLine("Lista de Empleados:");
            Console.WriteLine("-------------------");
            foreach (var empleado in empleados)
            {
                Console.WriteLine($"ID: {empleado.Id}, Nombres: {empleado.Nombres}, Apellidos: {empleado.Apellidos}, Días Disponibles: {empleado.DiasDisponibles}");
            }
        }
    }
}
