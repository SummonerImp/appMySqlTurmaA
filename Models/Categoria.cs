using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace appMySqlTurmaA.Models
{
    public class Categoria
    {

        private ConexaoDB db;

        [Display(Name = "Código Categoria")]
        [Key]
        public long idCategoria { get; set; }

        [Display(Name = "Nome")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres!")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string nome { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres!")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string descricao { get; set; }

        public void InsertCategoria(Categoria categoria) {
            string strQuery = string.Format("insert into categoria(nome, descricao) values('{0}', '{1}')",
                categoria.nome, categoria.descricao);

            using (db = new ConexaoDB()) {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Categoria> SelectCategoria() {
            string strQuery = "select * from categoria";
            using (db = new ConexaoDB()) {
                MySqlDataReader reg = db.ExecutaRegistro(strQuery);
                var categoria = new List<Categoria>();
                while (reg.Read()) 
                {
                    var catTemp = new Categoria() 
                    {
                        idCategoria = int.Parse(reg["idCategoria"].ToString()),
                        nome = reg["nome"].ToString(),
                        descricao = reg["descricao"].ToString()
                    };
                    categoria.Add(catTemp);
                }
                return categoria;
            }
        }

        public void DeleteCategoria(int idCategoria) {
            string strQuery = "delete from categoria where idCategoria = " + idCategoria;
            using (db = new ConexaoDB()) {
                db.ExecutaComando(strQuery);
            }
        }

        public void UpdateCategoria(Categoria categoria) {
            string strQuery = string.Format("update categoria set nome = '{1}', descricao = '{2}' where idCategoria = {0}", categoria.idCategoria, categoria.nome, categoria.descricao);
            using (db = new ConexaoDB()) {
                db.ExecutaComando(strQuery);
            }
        }

        public Categoria SelectIdCategoria(Categoria categoria) {
            string strQuery = "select * from categoria where idcategoria = '" + categoria.idCategoria + "'";
            using (db = new ConexaoDB())
            {
                var reader = db.ExecutaRegistro(strQuery);
                reader.Read();
                var objCategoria = new Categoria()
                {
                    idCategoria = int.Parse(reader["idCategoria"].ToString()),
                    nome = reader["nome"].ToString(),
                    descricao = reader["descricao"].ToString()
                };
                reader.Close();
                return objCategoria;
            }
        }
    }
}