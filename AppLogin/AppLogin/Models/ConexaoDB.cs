using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySqlX.XDevAPI.Common;

namespace appMySqlTurmaA.Models
{
    public class ConexaoDB:IDisposable
    {
        private readonly MySqlConnection conexao;
        public ConexaoDB()
        {
            conexao = new MySqlConnection("server=localhost;user id=root;password=12345678;persistsecurityinfo=True;database=dbturmaa");
            conexao.Open();
        }

        public void ExecutaComando(string strQuery)
        {
            var Command = new MySqlCommand
            {
                CommandText = strQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            Command.ExecuteNonQuery();
        }

        public MySqlDataReader ExecutaRegistro(string strQuery)
        {
            var Command = new MySqlCommand
            {
                CommandText = strQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            return Command.ExecuteReader();
        }

        public string ExecutaDado(string strQuery)
        {
            var Command = new MySqlCommand
            {
                CommandText = strQuery,
                CommandType = System.Data.CommandType.Text,
                Connection = conexao
            };
            return Command.ExecuteScalar().ToString();
        }

        public void Dispose()
        {
            if(conexao.State == System.Data.ConnectionState.Open)            
                conexao.Close();            
        }
    }
}