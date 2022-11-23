using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

public class NominaBLL
{
    private Contexto _contexto;

    public NominaBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public async Task<bool> Existe(int id)
    {
        return await _contexto.Nomina.AnyAsync(o => o.NominaId == id);
    }

    public async Task<bool> Guardar(Nomina nomina)
    {
        var existe = await Existe(nomina.NominaId);

        if (!existe)
            return await this.Insertar(nomina);
        else
            return await this.Modificar(nomina);
    }

    private async Task<bool> Insertar(Nomina nomina)
    {
        await _contexto.Nomina.AddAsync(nomina);

        var cantidad = await _contexto.SaveChangesAsync();

        return cantidad > 0;
    }

    private async Task<bool> Modificar(Nomina nomina)
    {
        _contexto.Entry(nomina).State = EntityState.Modified;

        var cantidad = await _contexto.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<bool> Eliminar(Nomina nomina)
    {
        _contexto.Entry(nomina).State = EntityState.Deleted;
        var cantidad = await _contexto.SaveChangesAsync();

        return cantidad > 0;
    }

    public async Task<Nomina?> Buscar(int nominaId)
    {
        var nomina = await _contexto.Nomina
                .Where(o => o.NominaId == nominaId)
                .AsNoTracking()
                .SingleOrDefaultAsync();

        return nomina;
    }

    public async Task<List<Nomina>> GetList(Expression<Func<Nomina, bool>> Criterio)
    {
        return await _contexto.Nomina
            .Where(Criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}