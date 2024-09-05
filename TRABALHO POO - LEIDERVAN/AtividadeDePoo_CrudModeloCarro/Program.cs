using AtividadeDePoo_CrudModeloCarro.Models;
using AtividadeDePoo_CrudModeloCarro.ModeloDao;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;

namespace AtividadeDePoo_CrudModeloCarro 
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Conexao.Conectar();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro" + ex.Message);
            }
            ModelDao modelDao = new ModelDao();
            int mensagem = 0;
            do
            {
                Console.WriteLine(" OLÁ SEJÁ MUITO BEM VINDO(A) " + DateTime.Now);
                Console.WriteLine();

                int escolha = 0;

                Console.WriteLine(" QUAL DAS OPÇÕES ABAIXO VOCÊ DESEJA ESCOLHER ");
                Console.WriteLine(" 1 - PARA CADASTRAR UM NOVO MODELO ");
                Console.WriteLine(" 2 - PARA EXCLUIR UM MODELO CADASTRADO ");
                Console.WriteLine(" 3 - PARA ATUALIZAR UM MODELO CADASTRADO ");
                Console.WriteLine(" 4 - PARA LISTAR TODOS OS MODELOS CADASTRADOS ");
                escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        try
                        {
                            CadModels modelo1 = new CadModels();
                            Console.WriteLine(" Informe o modelo do seu carro ");
                            modelo1.nomeModelo = Console.ReadLine();

                            Console.WriteLine(" O tipo do seu carro é: ");
                            Console.WriteLine(" SEDAN ");
                            Console.WriteLine(" CUPÊ ");
                            Console.WriteLine(" HACH BACK ");
                            Console.WriteLine(" CAMINHONETE ");
                            Console.WriteLine(" PICAPE ");
                            Console.WriteLine(" SUV ");
                            Console.WriteLine(" ESPORTIVO ");
                            Console.WriteLine(" VAN ");
                            Console.WriteLine(" ESCREVA O MODELO ABAIXO ");
                            modelo1.tipoModelo = Console.ReadLine();

                            Console.WriteLine(" Informe a cor do veiculo ");
                            modelo1.corModelo = Console.ReadLine();

                            Console.WriteLine(" Informe o ano do modelo do veiculo ");
                            modelo1.anoModelo = Convert.ToDateTime(Console.ReadLine());

                            ModelDao modeloDao1 = new ModelDao();

                            modeloDao1.Insert(modelo1);
                        }

                        catch (Exception exc)
                        {

                            throw new Exception(" Ocorreu um erro tente novamente " + exc.Message);
                        }
                        break;
                    case 2:
                        try
                        {
                            Console.WriteLine(" Informe o ID do Modelo que deseja excluir ");
                            int idModelo = int.Parse(Console.ReadLine());

                            CadModels modeloDelete = new CadModels { IdModelo = idModelo };

                            if (idModelo != 0)
                            {
                                modelDao.Delete(modeloDelete);
                            }
                            else
                            {
                                Console.WriteLine(" ZERO NÃO É VALIDO PARA A OPERAÇÃO ");
                            }

                            
                        }
                        catch (Exception ex)
                        {

                            throw new Exception(" Erro ao deletar cadastro, tente novamente " + ex.Message);
                        }
                        break;

                    case 3:
                        try
                        {
                            CadModels modeloUpdate = new CadModels();

                            Console.WriteLine(" Digite o ID do modelo que deseja atualizar ");
                            modeloUpdate.IdModelo = int.Parse(Console.ReadLine());

                            Console.WriteLine(" Informe o modelo do seu carro ");
                            modeloUpdate.nomeModelo = Console.ReadLine();

                            Console.WriteLine(" O tipo do seu carro é: ");
                            Console.WriteLine(" SEDAN ");
                            Console.WriteLine(" CUPÊ ");
                            Console.WriteLine(" HACH BACK ");
                            Console.WriteLine(" CAMINHONETE ");
                            Console.WriteLine(" PICAPE ");
                            Console.WriteLine(" SUV ");
                            Console.WriteLine(" ESPORTIVO ");
                            Console.WriteLine(" VAN ");
                            Console.WriteLine(" ESCREVA O MODELO ABAIXO ");
                            modeloUpdate.tipoModelo = Console.ReadLine();

                            Console.WriteLine(" Informe a cor do veiculo ");
                            modeloUpdate.corModelo = Console.ReadLine();

                            Console.WriteLine(" Informe o ano do modelo do veiculo ");
                            modeloUpdate.anoModelo = Convert.ToDateTime(Console.ReadLine());

                            modelDao.Upadate(modeloUpdate);
                        }
                        catch (Exception ex)
                        {
                            throw new Exception(" Erro ao atualizar, tente novamente " + ex.Message);
                        }
                        break;

                    case 4:
                        List<CadModels> modelos = modelDao.List();
                        foreach (var model in modelos)
                        {
                            Console.WriteLine("ID: " + model.IdModelo);
                            Console.WriteLine("Nome: " + model.nomeModelo);
                            Console.WriteLine("Tipo: " + model.tipoModelo);
                            Console.WriteLine("Cor: " + model.corModelo);
                            Console.WriteLine("Ano: " + model.anoModelo);
                            Console.WriteLine("----------------------------------");
                        }

                        break;

                    default:
                        Console.WriteLine(" Erro ao efetuar a busca. Tente novamente ");
                        break;
                }
                
                Console.WriteLine(" CADASTRAR UM NOVO MODELO - 5 ");
                Console.WriteLine(" SAIR DO SISTEMA - 0 ");
                mensagem = int.Parse(Console.ReadLine());
                Console.Clear();

            } while (mensagem != 0);
            {
                Console.WriteLine(" ATÉ LOGO - SISTEMA ENCERRADO EM: " + DateTime.Now);
            }
        }

    }
}
