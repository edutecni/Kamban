using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Kamban.Models
{
    public class Equipe
    {
        [Key]
        public int EquipeId { get; set; }

        [Required(ErrorMessage = "O Nome da Equipe é obrigatório.")]
        [StringLength(50, ErrorMessage = "O Nome da Equipe só pode conter 50 caracteres.")]
        public string EquipeNome { get; set; }

        [Required(ErrorMessage = "A Abreviação do Nome da Equipe é obrigatório.")]
        [StringLength(3, ErrorMessage = "O Nome da Equipe só pode conter 3 caracteres.")]
        public string Abreviacao { get; set; }
    }
}
