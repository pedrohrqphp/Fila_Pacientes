using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fila_Pacientes
{
    class Paciente
    {
        public int codigo;
        public string nome;
        public string idade;
        public string cpf;
        public string convenio;
        public int prioridade;
        public int alterar;

        public void CadastrarPaciente()
        {
            Console.WriteLine("CADASTRO DO PACIENTE");
            Console.WriteLine("");
            Console.Write("Número de chamada do paciente: ");
            codigo = int.Parse(Console.ReadLine());
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            Console.Write("Idade: ");
            idade = Console.ReadLine();
            Console.Write("CPF: ");
            cpf = Console.ReadLine();
            Console.Write("Convênio: ");
            convenio = Console.ReadLine();
            Console.Write("Prioridade nível: ");
            prioridade = int.Parse(Console.ReadLine());
            Console.Clear();
        }

        public void AlterarDados()
        {
            Console.WriteLine("INFORME NOVAMENTE");
            Console.WriteLine("");
            Console.Write("Nome: ");
            nome = Console.ReadLine();
            Console.Write("Idade: ");
            idade = Console.ReadLine();
            Console.Write("CPF: ");
            cpf = Console.ReadLine();
            Console.Write("Convênio: ");
            convenio = Console.ReadLine();
            Console.Write("Prioridade nível: ");
            prioridade = int.Parse(Console.ReadLine());
            Console.Clear();
        }
    }
}
