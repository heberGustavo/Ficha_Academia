using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FichaAcademia.Dominio.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(100, ErrorMessage = "Use menos caracteres!")]
        public string NomeCompleto { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(10, 100, ErrorMessage = "Idade inválida!")]
        public int Idade { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(10, 200, ErrorMessage = "Peso inválido!")]
        public double Peso { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [Range(1, 7, ErrorMessage = "Frequencia inválida!")]
        public int FrequenciaSemanal { get; set; }

        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }

        public ICollection<Ficha> Fichas { get; set; }
    }
}
