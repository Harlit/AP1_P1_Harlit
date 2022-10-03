using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

public class RegistrosBLL
{
    private Contexto _contexto;

    public RegistrosBLL(Contexto contexto)
    {
        _contexto = contexto;
    }

    public bool Existe(int registroId)
    {
        return _contexto.Registros
        .Any (o => o.RegistroId == registroId);
    }

    public bool Insertar(Registros registro)
    {
        _contexto.Registros.Add(registro);
        return _contexto.SaveChanges() > 0;
    }

    public bool Modificar(Registros registro)
    {
        _contexto.Entry(registro).State = EntityState.Modified;
        return _contexto.SaveChanges() > 0;
    }

    public bool Guardar(Registros registro)
    {
        if (!Existe(registro.RegistroId))
        return this.Insertar(registro);
        else
        {
            return this.Modificar(registro);
        }
    }

    public bool Eliminar(Registros registro)
    {
        _contexto.Entry(registro).State = EntityState.Deleted;
        return _contexto.SaveChanges() > 0;
    }

    public Registros? Buscar(int registroId)
    {
        return _contexto.Registros
        .Where (o => o.RegistroId == registroId)
        .AsNoTracking()
        .SingleOrDefault();
    }

    public List<Registros> GetList(Expression<Func<Registros,bool>> Criterio)
    {
        return _contexto.Registros
        .AsNoTracking()
        .Where(Criterio)
        .ToList();
    }
}