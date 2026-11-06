using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using SistemaVacaciones._03._AccesoDatos.Entidades;
using SistemaVacaciones._02._Negocio.DTOs.Empleados;
using System.Threading.Tasks;

namespace SistemaVacaciones._02._Negocio.Servicios.Empleados
{
    public class CrearEmpleado
    {
        private readonly VacacionesDbContext _context;

        public CrearEmpleado(VacacionesDbContext context)
        {
            _context = context;
        }

        public async Task RegistrarAsync(RegistroEmpleadoDTO empleadoDTO)
        {
            var empleado = new Empleado(
                empleadoDTO.Nombres,
                empleadoDTO.Apellidos,
                empleadoDTO.DiasDisponibles);

            await _context.Set<Empleado>().AddAsync(empleado);
            await _context.SaveChangesAsync();
        }
    }
}
