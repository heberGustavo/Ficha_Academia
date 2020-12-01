using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FichaAcademia.AcessoDados.Interface
{
    public interface IRepositorioGenerico<T> where T : class
    {
        IQueryable<T> PegarTodos();
        Task<T> PegarPeloId(int id);
        Task Inserir(T entidade);
        Task Atualizar(T entidade);
        Task Excluir(int id);
    }
}
