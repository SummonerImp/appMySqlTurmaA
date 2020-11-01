using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace appMySqlTurmaA.Models
{
    public class Modopag
    {
        [Display(Name = "Numero da Página")]
        [Key]
        public int numPag { get; set; }

        [Display(Name = "Nome")]
        [StringLength(25, ErrorMessage = "Máximo de 25 caracteres!")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string nome { get; set; }

        [Display(Name = "Outros Detalhes")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres!")]        
        public string outrosDetalhes { get; set; }
    }
}