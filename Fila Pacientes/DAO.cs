using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Fila_Pacientes
{
    class DAO
    {
        private MySqlConnection conexao;

        public void Iniciar()
        {
            conexao = new MySqlConnection("server=localhost; port=3308; database=fila; uid=root; password=; SSL Mode=None");

            try
            {
                conexao.Open();
                Console.WriteLine("CONEXAO REALIZADA COM SUCESSO!");
                Console.WriteLine("");
                Console.WriteLine("Aperte qualquer tecla para ENTRAR no sistema!");
                Console.ReadKey();
                Console.Clear();
            }
            catch (Exception erro)
            {
                Console.WriteLine(erro.Message);
                Console.WriteLine("");
                Console.WriteLine("ERRO DE CONEXAO!");
                Console.WriteLine("Por favor entre em contato com o administrador do sistema!");
                Console.ReadKey();
                Environment.Exit(0);
            }
        }

        public void FecharAbrir()
        {
            conexao.Close();

            if (conexao.State == ConnectionState.Open)
            {

            }
            else
            {
                conexao.Open();
            }
        }

        public void CadastrarDAO(Paciente p)
        {
            String sql = "insert into paciente values (@codigo, @nome, @idade, @cpf, @convenio, @prioridade)";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@codigo", p.codigo);
            cmd.Parameters.AddWithValue("@nome", p.nome);
            cmd.Parameters.AddWithValue("@idade", p.idade);
            cmd.Parameters.AddWithValue("@cpf", p.cpf);
            cmd.Parameters.AddWithValue("@convenio", p.convenio);
            cmd.Parameters.AddWithValue("@prioridade", p.prioridade);

            if (cmd.ExecuteNonQuery() > 0)
            {
                Console.WriteLine("Paciente cadastrado com sucesso!");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void MostrarFila()
        {
            try
            {
                Console.WriteLine("SITUAÇÃO DA FILA DE ESPERA");
                Console.WriteLine("");

                String sql = "select * from paciente order by prioridade_paciente desc";
                MySqlCommand cmd = new MySqlCommand(sql, conexao);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine("{0} = {1}({2})", rdr["prioridade_paciente"], rdr["nome_paciente"], rdr["codigo_paciente"]);
                }
                Console.WriteLine("\nPressione qualquer tecla para continuar");
                Console.ReadKey();
                Console.Clear();
            }
            catch
            {
                Console.WriteLine("A fila está vazia!");
                Console.ReadKey();
                Console.Clear();
            }
        }

        public void Atender(Paciente p)
        {
            Console.WriteLine("Qual o número do paciente que foi atendido?");
            Console.Write("Paciente: ");
            p.codigo = int.Parse(Console.ReadLine());
            Console.Clear();

            String sql = "delete from paciente where codigo_paciente = @codigo";
            MySqlCommand cmd = new MySqlCommand(sql, conexao);
            cmd.Parameters.AddWithValue("@codigo", p.codigo);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Paciente atendido com sucesso!");
            Console.ReadKey();
            Console.Clear();
        }

        public void MostrarPacientes(Paciente p)
        {
            Console.WriteLine("ATUALIZAR DADOS");
            Console.WriteLine("");
            Console.WriteLine("Qual paciente deseja atualizar os dados?\n");

            String sqlP = "select * from paciente";
            MySqlCommand cmdP = new MySqlCommand(sqlP, conexao);
            MySqlDataReader rdrP = cmdP.ExecuteReader();

            while (rdrP.Read())
            {
                Console.WriteLine("{0} = {1}", rdrP["codigo_paciente"], rdrP["nome_paciente"]);
            }

            Console.Write("\nPaciente: ");
            p.codigo = int.Parse(Console.ReadLine());
            Console.Clear();
        }

        public void MostrarDados(Paciente p)
        {
            Console.WriteLine("DADOS DO PACIENTE\n");

            String sqlD = "select * from paciente where codigo_paciente = @codigo";
            MySqlCommand cmdD = new MySqlCommand(sqlD, conexao);
            cmdD.Parameters.AddWithValue("@codigo", p.codigo);
            MySqlDataReader rdr = cmdD.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine("Nome: {0}", rdr["nome_paciente"]);
                Console.WriteLine("Idade: {0}", rdr["idade_paciente"]);
                Console.WriteLine("CPF: {0}", rdr["cpf_paciente"]);
                Console.WriteLine("Convênio: {0}", rdr["convenio_paciente"]);
                Console.WriteLine("Prioridade: {0}", rdr["prioridade_paciente"]);
            }

            Console.WriteLine("\nAlterar dados do paciente?");
            Console.Write("Resposta: ");
            p.alterar = int.Parse(Console.ReadLine());
            Console.Clear();
        }

        public void AlterarDados(Paciente p)
        {
            if (p.alterar == 1)
            {             
                String sqlA = "update paciente set nome_paciente = @nome, idade_paciente = @idade, cpf_paciente = @cpf, convenio_paciente = @convenio, prioridade_paciente = @prioridade where codigo_paciente = @codigo";
                MySqlCommand cmdA = new MySqlCommand(sqlA, conexao);
                cmdA.Parameters.AddWithValue("@codigo", p.codigo);
                cmdA.Parameters.AddWithValue("@nome", p.nome);
                cmdA.Parameters.AddWithValue("@idade", p.idade);
                cmdA.Parameters.AddWithValue("@cpf", p.cpf);
                cmdA.Parameters.AddWithValue("@convenio", p.convenio);
                cmdA.Parameters.AddWithValue("@prioridade", p.prioridade);
                cmdA.ExecuteNonQuery();

                Console.WriteLine("Dados do paciente atualizados com sucesso!");
                Console.ReadKey();
                Console.Clear();
            }
            else
            {
                Console.WriteLine("AÇÃO CANCELADA!");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}