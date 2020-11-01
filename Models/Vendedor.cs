using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace appMySqlTurmaA.Models
{
    public class Vendedor
    {
        [Display(Name = "Código Vendedor")]
        [Key]
        public string idVendedor { get; set; }

        [Display(Name = "Nome")]
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres!")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string nome { get; set; }

        [Display(Name = "CPF")]
        [StringLength(11, ErrorMessage = "Máximo de 11 caracteres!")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string cpf { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(20, ErrorMessage = "Máximo de 20 caracteres!")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string telefone { get; set; }
    }
}