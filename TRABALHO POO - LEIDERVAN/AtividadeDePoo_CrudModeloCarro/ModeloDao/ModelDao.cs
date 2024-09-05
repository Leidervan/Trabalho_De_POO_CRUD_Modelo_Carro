using AtividadeDePoo_CrudModeloCarro.Models;
using Microsoft.VisualBasic;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZstdSharp.Unsafe;

namespace AtividadeDePoo_CrudModeloCarro.ModeloDao
{
    internal class ModelDao
    {
        public void Insert(CadModels modelDao) // Nome de pasta mais nome da classe dentro da pasta
        {
            try
            {
                string anoDoModelo = modelDao.anoModelo.ToString("yyyy-MM-dd");
                string sql = "INSERT INTO Modelo(nome_Modelo,tipo_Modelo,cor_Modelo,ano_Modelo)" +
                              "VALUES(@nomeModelo, @tipoModelo, @corModelo, @anoModelo)";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@nomeModelo", modelDao.nomeModelo);
                comando.Parameters.AddWithValue("@tipoModelo", modelDao.tipoModelo);
                comando.Parameters.AddWithValue("@corModelo", modelDao.corModelo);
                comando.Parameters.AddWithValue("@anoModelo", anoDoModelo);
                comando.ExecuteNonQuery();
                Console.WriteLine(" Cadastrado com sucesso! ");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {

                throw new Exception(" Erro ao cadastrar! Tente novamente " + ex.Message); // Execeção quando tiver erro
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        public void Delete(CadModels modelDao)
        {
            try
            {
                string sql = "DELETE FROM Modelo WHERE Id_Modelo = @IdModelo";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@IdModelo", modelDao.IdModelo);
                comando.ExecuteNonQuery();
                Console.WriteLine(" Modelo excluido com sucesso! ");
                Conexao.FecharConexao();
            }
            catch (Exception ex)
            {

                throw new Exception(" Erro ao cadastrar! Tente novamente " + ex.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }
        }

        public void Upadate(CadModels modelDao)
        {
            try
            {
                string anoDoModelo = modelDao.anoModelo.ToString();
                string sql = "UPDATE Modelo SET nome_Modelo = @nomeModelo, tipo_Modelo = @tipoModelo, cor_Modelo = @corModelo, " +
                             "ano_Modelo = @anoModelo WHERE Id_Modelo = @IdModelo";
                MySqlCommand comando = new MySqlCommand(sql, Conexao.Conectar());
                comando.Parameters.AddWithValue("@IdModelo", modelDao.IdModelo);
                comando.Parameters.AddWithValue("@nomeModelo", modelDao.nomeModelo);
                comando.Parameters.AddWithValue("@tipoModelo", modelDao.tipoModelo);
                comando.Parameters.AddWithValue("@corModelo", modelDao.corModelo);
                comando.Parameters.AddWithValue("@anoModelo", modelDao.anoModelo);
                comando.ExecuteNonQuery();
                Console.WriteLine("Cadastro atualizado com sucesso!");
                Conexao.FecharConexao();

            }
            catch (Exception ex)
            {

                throw new Exception(" Erro ao atualizar o cadastro " + ex.Message);
            }
            finally
            {
                Conexao.FecharConexao();
            }

        }

        public List<CadModels> List()
        {
            List<CadModels> cadModels = new List<CadModels>();
            try
            {
                var sql = "SELECT * FROM Modelo ORDER BY nome_Modelo";
                MySqlCommand command = new MySqlCommand(sql, Conexao.Conectar());
                using (MySqlDataReader dr = command.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        CadModels ModelCarro = new CadModels();
                        ModelCarro.IdModelo = dr.GetInt32("Id_Modelo");
                        ModelCarro.nomeModelo = dr.GetString("nome_Modelo");
                        ModelCarro.tipoModelo = dr.GetString("tipo_Modelo");
                        ModelCarro.corModelo = dr.GetString("cor_Modelo");
                        ModelCarro.anoModelo = dr.GetDateTime("ano_Modelo");
                        cadModels.Add(ModelCarro);

                    }
                }
                Conexao.FecharConexao();
            }
            

            catch (Exception ex)
            {

                throw new Exception(" Erro ao atualizar o cadastro " + ex.Message);
            }
            cadModels = cadModels.OrderBy(ModelCaro => ModelCaro.IdModelo).ToList();
            return cadModels;
        }
    }
}




