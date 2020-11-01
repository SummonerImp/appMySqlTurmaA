using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using MySql.Data.MySqlClient;

namespace appMySqlTurmaA.Models
{
    public class Cliente
    {
        private ConexaoDB db;

        [Display(Name ="Código")]
        [Key]
        public long idCliente { get; set; }

        [Display(Name = "Nome")]
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres!")]
        [Required(ErrorMessage ="O campo é obrigatório!")]
        public string nome { get; set; }

        [Display(Name = "Endereço")]
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres!")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string endereco { get; set; }

        [Display(Name = "Telefone")]
        [StringLength(30, ErrorMessage = "Máximo de 30 caracteres!")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        public string telefone { get; set; }

        [Display(Name = "CPF")]
        [StringLength(14, MinimumLength = 11, ErrorMessage = "Máximo de 11 caracteres!")]
        [Required(ErrorMessage = "O campo é obrigatório!")]
        [Remote("IsCpfExist", "Cliente", ErrorMessage = "Este CPF já existe")]
        public string cpf { get; set; }

        public void InsertCliente(Cliente cliente)
        {
            string strQuery = string.Format("insert into cliente(nome, endereco, telefone, cpf) values('{0}', '{1}', '{2}', '{3}')", 
                cliente.nome, cliente.endereco, cliente.telefone, cliente.cpf.Replace(".",string.Empty).Replace("-", string.Empty));

            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }            
        }

        public List<Cliente> SelectCliente()
        {
            string strQuery = "select * from Cliente";
            using(db = new ConexaoDB())
            {
                MySqlDataReader reg = db.ExecutaRegistro(strQuery);
                var cliente = new List<Cliente>();
                while (reg.Read())
                {
                    var cliTemp = new Cliente()
                    {
                        idCliente = int.Parse(reg["idCliente"].ToString()),
                        nome = reg["nome"].ToString(),
                        endereco = reg["endereco"].ToString(),
                        telefone = reg["telefone"].ToString(),
                        cpf = reg["cpf"].ToString()
                    };
                    cliente.Add(cliTemp);                    
                }
                return cliente;
            }
        }

        public void DeleteCliente(int id)
        {
            string strQuery = "delete from cliente where idCliente = " + id;
            using(db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public void UpdateCliente(Cliente cliente)
        {
            string strQuery = string.Format("update Cliente set nome = '{0}', endereco = '{1}', telefone = '{2}', cpf = '{3}' where idCliente = {4}", cliente.nome, cliente.endereco, cliente.telefone, cliente.cpf, cliente.idCliente);
            using (db = new ConexaoDB())
            {
                db.ExecutaComando(strQuery);
            }
        }

        public Cliente SelectIdCliente(Cliente cliente)
        {
            string strQuery = "select * from cliente where idCliente = " + cliente.idCliente;
            using (db = new ConexaoDB())
            {
                MySqlDataReader reader = db.ExecutaRegistro(strQuery);
                reader.Read();
                var objCliente = new Cliente()
                {
                    idCliente = int.Parse(reader["idCliente"].ToString()),
                    nome = reader["nome"].ToString(),
                    endereco = reader["endereco"].ToString(),
                    telefone = reader["telefone"].ToString(),
                    cpf = reader["cpf"].ToString()
                };
                reader.Close();
                return objCliente;
            }
        }

        public Cliente SelectCpfCliente(string cpf)
        {
            cpf = cpf.Replace(".", string.Empty).Replace("-", string.Empty);
            if (cpf.Length != 11 || cpf.Contains("_"))
            {
                return null;
            }
            else
            {
                string strQuery = "select * from cliente where cpf = '" + cpf + "'";
                using (db = new ConexaoDB())
                {
                    MySqlDataReader reader = db.ExecutaRegistro(strQuery);
                    if (reader.Read())
                    {
                        var objCliente = new Cliente()
                        {
                            idCliente = int.Parse(reader["idCliente"].ToString()),
                            nome = reader["nome"].ToString(),
                            endereco = reader["endereco"].ToString(),
                            telefone = reader["telefone"].ToString(),
                            cpf = reader["cpf"].ToString()
                        };
                        reader.Close();
                        return objCliente;
                    }
                    return null;
                }
            }
        }
    }
}