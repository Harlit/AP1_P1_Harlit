using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class AportesBLL
{
    private Contexto _contexto;

    public AportesBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int aporteId)
    {
        return _contexto.Aportes
        .Any (o => o.AporteId == aporteId);
    }

    public bool Insertar(Aportes aporte)
    {
        _contexto.Aportes.Add(aporte);
        return _contexto.SaveChanges() > 0;
    }

    public bool Modificar(Aportes aporte)
    {
        _contexto.Entry(aporte).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Aportes aporte)
    {
        if (!Existe(aporte.AporteId))
        return this.Insertar(aporte);
        else
        {
            return this.Modificar(aporte);
        }
    }

    public bool Eliminar(Aportes aporte)
    {
        _contexto.Entry(aporte).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Aportes? Buscar(int AporteId)
    {
        return _contexto.Aportes
        .Where (o => o.AporteId == AporteId)
        .AsNoTracking()
        .SingleOrDefault();
    }

    public List<Aportes> GetList(Expression<Func<Aportes,bool>> Criterio)
    {
        return _contexto.Aportes
        .AsNoTracking()
        .Where(Criterio)
        .ToList();
    }
}