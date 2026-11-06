using SistemaVacaciones._02._Negocio.DTOs.Empleados;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using SistemaVacaciones._03._AccesoDatos.Entidades;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SistemaVacaciones._02._Negocio.Servicios.Empleados
{
    public class ActualizaEmpleado
    {
        private readonly VacacionesDbContext _context;

        public ActualizaEmpleado(VacacionesDbContext context)
        {
            _context = context;
        }

        public async Task<Empleado?> ObtenerIdAsync(int id)
        {
            return await _context.Set<Empleado>()
                .FirstOrDefaultAsync(e => e.IdEmpleado == id);
        }

        public async Task<bool> ActualizarAsync(ActualizarEmpleadoDTO empleadoDTO)
        {
            var empleado = await ObtenerIdAsync(empleadoDTO.IdEmpleado);

            if (empleado is null)
            {
                return false;
            }

            empleado.Actualizar(empleadoDTO.Nombre, empleadoDTO.Apellido, empleadoDTO.DiasDisponibles);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DesactivarAsync(int idEmpleado)
        {
            var empleado = await _context.Set<Empleado>()
                .FirstOrDefaultAsync(e => e.IdEmpleado == idEmpleado);

            if (empleado is null || !empleado.IsActive)
            {
                return false;
            }

            empleado.Desactivar();
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
