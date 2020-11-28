using Microsoft.EntityFrameworkCore;

namespace FichaAcademia.AcessoDados
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
    }
}
