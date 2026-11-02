using SistemaVacaciones._02._Negocio.DTOs.Empleados;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using SistemaVacaciones._03._AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._02._Negocio.Servicios.Empleados
{
    public class ListaEmpleado
    {
        private readonly VacacionesDbContext _context;

        public ListaEmpleado(VacacionesDbContext context)
        {
            _context = context;
        }
        public List<ListarClienteDTO> ListEmpleados()
        {
            var empleados = _context.Set<Empleado>()
                .Where(e => e.IsActive)
                .Select(e => new ListarClienteDTO
                {
                    Id = e.IdEmpleado,
                    Nombres = e.Nombres,
                    Apellidos = e.Apellidos,
                    DiasDisponibles = e.DiasDisponibles
                })
                .ToList();
            return empleados;
        }
    }
}
