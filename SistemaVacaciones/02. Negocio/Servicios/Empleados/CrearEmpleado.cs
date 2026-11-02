using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using SistemaVacaciones._03._AccesoDatos.Entidades;
using SistemaVacaciones._02._Negocio.DTOs.Empleados;
using System;
using System.Collections.Generic;
using System.Text;

namespace SistemaVacaciones._02._Negocio.Servicios.Empleados
{
    public class CrearEmpleado
    {
        private readonly VacacionesDbContext _context;

        public CrearEmpleado(VacacionesDbContext context)
        {
            _context = context;
        }

        public void Registrar(RegistroEmpleadoDTO empleadoDTO)
        {
            var empleado = new Empleado(
                empleadoDTO.Nombres,
                empleadoDTO.Apellidos,
                empleadoDTO.DiasDisponibles);

            _context.Set<Empleado>().Add(empleado);
            _context.SaveChanges();
        }
    }
}
