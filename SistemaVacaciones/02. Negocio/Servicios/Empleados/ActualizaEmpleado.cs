using SistemaVacaciones._02._Negocio.DTOs.Empleados;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using SistemaVacaciones._03._AccesoDatos.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SistemaVacaciones._02._Negocio.Servicios.Empleados
{
    public class ActualizaEmpleado
    {
        private readonly VacacionesDbContext _context;

        public ActualizaEmpleado(VacacionesDbContext context)
        {
            _context = context;
        }

        public Empleado? ObtenerId(int id)
        {
            return _context.Set<Empleado>()
                .FirstOrDefault(e => e.IdEmpleado == id);
        }

        public bool Actualizar(ActualizarEmpleadoDTO empleadoDTO)
        {
            var empleado = ObtenerId(empleadoDTO.IdEmpleado);

            if (empleado is null)
            {
                return false;
            }

            empleado.Actualizar(empleadoDTO.Nombre, empleadoDTO.Apellido, empleadoDTO.DiasDisponibles);
            _context.SaveChanges();
            return true;
        }
    }
}
