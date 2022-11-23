using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class LicenciasBLL{
    private Contexto _contexto;

    public LicenciasBLL(Contexto contexto)
    {
        this._contexto = contexto;
    }

    public bool Guardar(Licencias licencia)
    {
        if (!Existe(licencia.LicenciaId))
        {
            return Insertar(licencia);
        }
        else
        {
            return Modificar(licencia);
        }
    }

    public bool Existe(int licenciaId)
    {
        return _contexto.Licencias.Any(l => l.LicenciaId == licenciaId);
    }

    public bool Insertar(Licencias licencia)
    {
        _contexto.Licencias.Add(licencia);
        int cantidad = _contexto.SaveChanges();
        return cantidad > 0;
    }

    public bool Modificar(Licencias licencia)
    {
         _contexto.Entry(licencia).State = EntityState.Modified;
            return _contexto.SaveChanges()> 0;
    }
       public bool Eliminar(Licencias licencia)
    {
         _contexto.Entry(licencia).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
    }

     public Licencias? Buscar(int licenciaId){
            return _contexto.Licencias
                    .Where(l=> l.LicenciaId== licenciaId)
                    .AsNoTracking()
                    .SingleOrDefault();
                    
        }

     public List<Licencias> GetList(Expression<Func<Licencias, bool>> Criterio){
            return _contexto.Licencias
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }

}