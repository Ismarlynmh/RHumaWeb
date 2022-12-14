using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
public class EmpleadosBLL
{
    private Contexto _contexto;

    public EmpleadosBLL(Contexto contexto)
    {
        this._contexto = contexto;
    }

    public bool Guardar(Empleados empleado)
    {
        if (!Existe(empleado.EmpleadoId))
        {
            return Insertar(empleado);
        }
        else
        {
            return Modificar(empleado);
        }
    }

    public bool Existe(int empleadoId)
    {
        return _contexto.Empleados.Any(e => e.EmpleadoId == empleadoId);
    }

    public bool Insertar(Empleados empleado)
    {
        _contexto.Empleados.Add(empleado);
        int cantidad = _contexto.SaveChanges();
        return cantidad > 0;
    }

    public bool Modificar(Empleados empleado)
    {
        _contexto.Entry(empleado).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }
    public bool Eliminar(int EmpleadoId)
    {
        //bool confirmar = false;
        //try
        //{

        //}
        //catch(Exception)
        //{
        //    throw;
        //}
        //finally { _contexto.Dispose(); }
        //return confirmar;
        //_contexto.Entry(empleado).State = EntityState.Deleted;
        //return _contexto.SaveChanges() > 0;
        var empleado = _contexto.Empleados.Find(EmpleadoId);
        return empleado.EstaEliminado = true;
        _contexto.SaveChanges();
    }

    public Empleados? Buscar(int empleadoId)
    {
        //return _contexto.Empleados
        //        .Where(e => e.EmpleadoId == empleadoId)
        //        .AsNoTracking()
        //        .SingleOrDefault();
        return _contexto.Empleados
                .Where(e => e.EmpleadoId == empleadoId && e.EstaEliminado == false)
                .SingleOrDefault();

    }

    public List<Empleados> GetList(Expression<Func<Empleados, bool>> Criterio)
    {
        //return _contexto.Empleados
        //    .AsNoTracking()
        //    .Where(Criterio)
        //    .ToList();
        return _contexto.Empleados
                .Where(e => e.EstaEliminado == false)
                .Where(Criterio)
                .ToList();
    }
}