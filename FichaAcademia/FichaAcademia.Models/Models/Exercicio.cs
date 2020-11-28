using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace FichaAcademia.Dominio.Models
{
    public class Exercicio
    {
        public int ExercicioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [StringLength(50, ErrorMessage = "Use menos caracteres!")]
        public string Nome { get; set; }

        //FK
        public int CategoriaExercicioId { get; set; }
        public CategoriaExercicio CategoriaExercicio { get; set; }

        //Lista
        public ICollection<ListaExercicio> ListaExercicios { get; set; }

    }
}
