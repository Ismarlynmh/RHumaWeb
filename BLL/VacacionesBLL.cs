using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
public class VacacionesBLL
{
    private Contexto _contexto;

    public VacacionesBLL(Contexto contexto)
    {
        this._contexto = contexto;
    }

    public bool Guardar(Vacaciones vacaciones)
    {
        if (!Existe(vacaciones.VacacionesId))
        {
            return Insertar(vacaciones);
        }
        else
        {
            return Modificar(vacaciones);
        }
    }

    public bool Existe(int vacacionesId)
    {
        return _contexto.Vacaciones.Any(e => e.VacacionesId == vacacionesId);
    }

    public bool Insertar(Vacaciones vacaciones)
    {
        _contexto.Vacaciones.Add(vacaciones);
        int cantidad = _contexto.SaveChanges();
        return cantidad > 0;
    }

    public bool Modificar(Vacaciones vacaciones)
    {
        _contexto.Entry(vacaciones).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }
    public bool Eliminar(Vacaciones vacaciones)
    {
        _contexto.Entry(vacaciones).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Vacaciones? Buscar(int vacacionesId)
    {
        return _contexto.Vacaciones
                .Where(e => e.VacacionesId == vacacionesId)
                .AsNoTracking()
                .SingleOrDefault();

    }

    public List<Vacaciones> GetList(Expression<Func<Vacaciones, bool>> Criterio)
    {
        return _contexto.Vacaciones
            .AsNoTracking()
            .Where(Criterio)
            .ToList();
    }
}