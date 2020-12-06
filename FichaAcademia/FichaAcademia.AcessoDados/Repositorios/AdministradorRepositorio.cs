using FichaAcademia.AcessoDados.Interfaces;
using FichaAcademia.AcessoDados.Repositorio;
using FichaAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FichaAcademia.AcessoDados.Repositorios
{
    public class AdministradorRepositorio : RepositorioGenerico<Administrador>, IAdministradorRepositorio
    {
        private readonly Contexto _contexto;

        public AdministradorRepositorio(Contexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public bool AdministradorExiste(string email, string senha)
        {
            return _contexto.Administradores.Any(a => a.Email == email && a.Senha == senha);
        }
    }
}
