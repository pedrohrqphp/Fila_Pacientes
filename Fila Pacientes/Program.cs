using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;

namespace Fila_Pacientes
{
    class Program
    {
        static void Main(string[] args)
        {
            DAO dao = new DAO();
            dao.Iniciar();

            Paciente p = new Paciente();

            int menu = 1;
            while (menu != 0)
            {
                Console.WriteLine("Selecione o que deseja realizar:");
                Console.WriteLine("");
                Console.WriteLine("1 - CADASTRO DOS PACIENTES");
                Console.WriteLine("2 - MOSTRAR FILA");
                Console.WriteLine("3 - PACIENTE ATENDIDO");
                Console.WriteLine("4 - ALTERAR DADOS DO PACIENTE");
                Console.WriteLine("0 - FINALIZAR PROGRAMA");
                Console.WriteLine("");
                Console.Write("Opção escolhida: ");
                menu = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (menu)
                {
                    case 1:
                        dao.FecharAbrir();
                        p.CadastrarPaciente();
                        dao.CadastrarDAO(p);
                        break;
                    case 2:
                        dao.FecharAbrir();
                        dao.MostrarFila();
                        break;
                    case 3:
                        dao.FecharAbrir();
                        dao.Atender(p);
                        break;
                    case 4:
                        dao.FecharAbrir();
                        dao.MostrarPacientes(p);
                        dao.FecharAbrir();
                        dao.MostrarDados(p);
                        dao.FecharAbrir();
                        p.AlterarDados();
                        dao.AlterarDados(p);
                        break;
                    case 0:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida! Escolha novamente a opção desejada!");
                        Console.ReadKey();
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
