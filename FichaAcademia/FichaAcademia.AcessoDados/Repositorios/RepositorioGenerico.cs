using FichaAcademia.AcessoDados.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FichaAcademia.AcessoDados.Repositorio
{
    public class RepositorioGenerico<T> : IRepositorioGenerico<T> where T : class
    {
        private readonly Contexto _context;

        public RepositorioGenerico(Contexto context)
        {
            _context = context;
        }

        public async Task Atualizar(T entidade)
        {
            _context.Set<T>().Update(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task Excluir(int id)
        {
            var entity = await PegarPeloId(id);
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Inserir(T entidade)
        {
            await _context.Set<T>().AddAsync(entidade);
            await _context.SaveChangesAsync();
        }

        public async Task<T> PegarPeloId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public IQueryable<T> PegarTodos()
        {
            return _context.Set<T>();
        }
    }
}
