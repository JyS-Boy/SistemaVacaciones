using Microsoft.EntityFrameworkCore;
using SistemaVacaciones._01._Presentacion;
using SistemaVacaciones._03._AccesoDatos.ContextoBD;
using System.Configuration;

static class Program
{
    static void Main(string[] args)
    {
        var connectionString = ConfigurationManager.ConnectionStrings["SistemaVacaciones"].ConnectionString;
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("La cadena de conexión 'SistemaVacaciones' no se encuentra en el archivo de configuración.");
        }

        var optionsBuilder = new DbContextOptionsBuilder<VacacionesDbContext>();
        optionsBuilder.UseSqlServer(connectionString);
        using var context = new VacacionesDbContext(optionsBuilder.Options);
        MenuPrincipal.MostrarMenu(context);
    }
}
