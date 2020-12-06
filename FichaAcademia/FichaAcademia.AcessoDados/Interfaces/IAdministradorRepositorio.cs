using FichaAcademia.AcessoDados.Interface;
using FichaAcademia.Dominio.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace FichaAcademia.AcessoDados.Interfaces
{
    public interface IAdministradorRepositorio : IRepositorioGenerico<Administrador>
    {
        bool AdministradorExiste(string email, string senha);
    }
}
