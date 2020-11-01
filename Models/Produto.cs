using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;

namespace appMySqlTurmaA.Models
{
    public class Produto
    {
        private ConexaoDB db;

        [Display(Name = "Código Produto")]
        [Key]
        public long idProduto { get; set; }

        [Display(Name = "Nome")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres!")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string nome { get; set; }

        [Display(Name = "Preço Unitário")]
        [StringLength(50, ErrorMessage = "Máximo de 50 caracteres!")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string precoUnitario { get; set; }

        [Display(Name = "Código Categoria")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [ForeignKey("Categoria")]
        public string idCategoria { get; set; }

        public void InsertProduto(Produto produto) {
            string strQuery = string.Format("insert into produto(idProduto, nome, precoUnitario, idCategoria) values('{0}', '{1}', '{2}', '{3}')",
                produto.idProduto, produto.nome, produto.precoUnitario, produto.idCategoria);

            using (db = new ConexaoDB()) {
                db.ExecutaComando(strQuery);
            }
        }

        public List<Produto> SelectProduto() {
            string strQuery = "select * from produto";
            using (db = new ConexaoDB()) {
                MySqlDataReader reg = db.ExecutaRegistro(strQuery);
                var produto = new List<Produto>();
                while (reg.Read()) {
                    var prodTemp = new Produto() {
                        idProduto = int.Parse(reg["idProduto"].ToString()),
                        nome = reg["nome"].ToString(),
                        precoUnitario = reg["precoUnitario"].ToString(),
                        idCategoria = reg["idCategoria"].ToString()
                    };
                    produto.Add(prodTemp);
                }
                return produto;
            }
        }

        public void DeleteProduto(int idProduto) {
            string strQuery = "delete from produto where idProduto = " + idProduto;
            using (db = new ConexaoDB()) {
                db.ExecutaComando(strQuery);
            }
        }

        public void UpdateProduto(Produto produto) {
           string strQuery = string.Format("update produto set nome = '{1}', precoUnitario = '{2}', idCategoria = '{3}' where idProduto = {0}", produto.idProduto, produto.nome, produto.precoUnitario, produto.idCategoria);
            using (db = new ConexaoDB()) {
                db.ExecutaComando(strQuery);
            }
        }

        public Produto SelectIdProduto(Produto produto) {
            string strQuery = "select * from produto where idProduto = " + produto.idProduto;
            using (db = new ConexaoDB())
            {
                MySqlDataReader reader = db.ExecutaRegistro(strQuery);
                reader.Read();
                var objProduto = new Produto()
                {
                    idProduto = int.Parse(reader["idProduto"].ToString()),
                    nome = reader["nome"].ToString(),
                    precoUnitario = reader["precoUnitario"].ToString(),
                    idCategoria = reader["idCategoria"].ToString()
                };
                reader.Close();
                return objProduto;
            }
        }

        public List<Categoria> SelectCategoria()
        {
            string strQuery = "select * from categoria";
            using (db = new ConexaoDB())
            {
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

        /*public Categoria SelectIdCategoria(string id)
        {
            string strQuery = "select * from cliente where idCliente = " + id;
            MySqlDataReader reader = db.ExecutaRegistro(strQuery);
            reader.Read();
            var objCategoria = new Categoria()
            {
                idCategoria = int.Parse(reader["idCategoria"].ToString()),
                nome = reader["nome"].ToString(),
                descricao = reader["descricao"].ToString()
            };
            reader.Close();
            return objCategoria;
        }*/
    }
}