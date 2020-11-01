using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace appMySqlTurmaA.Models
{
    public class Produto
    {
        [Key]
        [Display(Name ="Código Produto")]
        public string idProduto { get; set; }

        [Display(Name = "Nome")]
        public string nome { get; set; }

        [Display(Name = "Preço Unitário")]
        public string precoUnitario { get; set; }

        [ForeignKey("ïdCategoria")]
        public virtual Categoria Categoria { get; set; }
    }
}