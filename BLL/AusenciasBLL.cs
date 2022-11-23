using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class AusenciasBLL{
    private Contexto _contexto;

    public AusenciasBLL(Contexto contexto)
    {
        this._contexto = contexto;
    }

    public bool Guardar(Ausencias ausencia)
    {
        if (!Existe(ausencia.AusenciaId))
        {
            return Insertar(ausencia);
        }
        else
        {
            return Modificar(ausencia);
        }
    }

    public bool Existe(int ausenciaId)
    {
        return _contexto.Ausencias.Any(a => a.AusenciaId == ausenciaId);
    }

    public bool Insertar(Ausencias ausencia)
    {
        _contexto.Ausencias.Add(ausencia);
        int cantidad = _contexto.SaveChanges();
        return cantidad > 0;
    }

    public bool Modificar(Ausencias ausencia)
    {
         _contexto.Entry(ausencia).State = EntityState.Modified;
            return _contexto.SaveChanges()> 0;
    }
       public bool Eliminar(Ausencias ausencia)
    {
         _contexto.Entry(ausencia).State = EntityState.Deleted;
            return _contexto.SaveChanges() > 0;
    }

     public Ausencias? Buscar(int ausenciaId){
            return _contexto.Ausencias
                    .Where(a=> a.AusenciaId== ausenciaId)
                    .AsNoTracking()
                    .SingleOrDefault();
                    
        }

     public List<Ausencias> GetList(Expression<Func<Ausencias, bool>> Criterio){
            return _contexto.Ausencias
                .AsNoTracking()
                .Where(Criterio)
                .ToList();
        }

}