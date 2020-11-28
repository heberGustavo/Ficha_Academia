using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FichaAcademia.Dominio.Models
{
    public class Ficha
    {
        public int FichaId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(50, ErrorMessage = "Use menos caracteres!")]
        public string Nome { get; set; }

        public DateTime Cadastro { get; set; }
        public DateTime Validade { get; set; }

        public int AlunoId { get; set; }
        public Aluno Aluno { get; set; }

        public ICollection<ListaExercicio> ListaExercicos { get; set; }
    }
}