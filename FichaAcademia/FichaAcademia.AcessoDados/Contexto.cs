using FichaAcademia.Dominio.Models;
using Microsoft.EntityFrameworkCore;

namespace FichaAcademia.AcessoDados
{
    public class Contexto : DbContext
    {
        public DbSet<Administrador> Administradores { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<CategoriaExercicio> CategoriaExercicios { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Ficha> Fichas { get; set; }
        public DbSet<ListaExercicio> ListaExercicios { get; set; }
        public DbSet<Objetivo> Objetivos { get; set; }
        public DbSet<Professor> Professores { get; set; }

        public Contexto(DbContextOptions<Contexto> options) : base(options)
        {

        }
    }
}
