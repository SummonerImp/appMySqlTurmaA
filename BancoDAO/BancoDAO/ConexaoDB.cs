using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BancoDAO
{
    class ConexaoDB
    {
        private static ConexaoDB objConexaoDB = null;
        private readonly MySqlConnection conexao;
        private ConexaoDB()
        {
            conexao = new MySqlConnection("server=localhost;user id=root;password=1234567;persistsecurityinfo=True;database=dbturmaa");
        }

        public static ConexaoDB ConexaoStatus()
        {
            if (objConexaoDB == null)
            {
                objConexaoDB = new ConexaoDB();
            }
            return objConexaoDB;
        }

        public MySqlConnection ConexaoPegar()
        {
            return conexao;
        }
    }
}
