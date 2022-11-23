using Microsoft.EntityFrameworkCore;

public class Contexto : DbContext
{
    public DbSet<Empleados> Empleados { get; set; }
    public DbSet<Licencias> Licencias { get; set; }
    public DbSet<Ausencias> Ausencias { get; set; }
    public DbSet<Permisos> Permisos { get; set; }
    public DbSet<Nomina> Nomina { get; set; }
    public DbSet<Vacaciones> Vacaciones { get; set; }
    public Contexto(DbContextOptions<Contexto> options) : base(options)
    {
    }

}