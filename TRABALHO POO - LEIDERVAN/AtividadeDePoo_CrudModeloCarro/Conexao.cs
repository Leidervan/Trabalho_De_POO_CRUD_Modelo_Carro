using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace AtividadeDePoo_CrudModeloCarro
{
    internal class Conexao
    {
        public static MySqlConnection conexao;
        public static MySqlConnection Conectar()
        {
            try
            {
                string DataBaseConexão = "server=localhost;port=3306;uid=root;pwd=84628462;database=Modelo";
                conexao = new MySqlConnection(DataBaseConexão);
                conexao.Open();
                Console.WriteLine(" CONECTADO COM SUCESSO! ");
            }
            catch (Exception ex)
            {

                throw new Exception(" Ocorreu um erro ao realizar a conexão com o Banco de Dados " + ex.Message); ;
            }
            return conexao;
        }

        public static void FecharConexao()
        {
            conexao.Clone();
        }
    }
}
