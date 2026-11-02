using SistemaVacaciones._02._Negocio.DTOs.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._01._Presentacion.Empleado
{
    public class ListarEmpleado
    {
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
