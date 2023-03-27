using Cadastro;
using CadastroCidade;
public class Menu
{
    public void tela()
    {
        int opção =1;  //variavel de controle

        while(opção!=0) // para passar a primeira vez eu indico opção = 1
        {
            Console.WriteLine("\n1- Cadastro de Pessoa");
            Console.WriteLine("2- Listagem de Pessoa");
            Console.WriteLine("3- Alteração de Pessoa");
            Console.WriteLine("4- Exclusão de Pessoa");
            Console.WriteLine("0- sair");
            opção = Convert.ToInt32(Console.ReadLine());
            switch (opção)
            {
                case 1:
                    cadastroPessoa();
                    break;
                case 2:
                    listarPessoa();
                    break;
                case 3:
                    alterarPessoa();
                    break;
                case 4:
                    excluirPessoa();
                    break;
                case 0:
                    Console.WriteLine("Finalizado");
                    break;
                default:
                    Console.WriteLine("opção invalida");
                    break;
            }
        }
        void cadastroPessoa()
        {
            Console.WriteLine("digite o codigo");
            int id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("digite o Nome");
            string nome = Console.ReadLine();
            
            Console.WriteLine("digite o telefone");
            string telefone = Console.ReadLine(); 

            Console.WriteLine("digite o codigo da cidade");
            int idCidade = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("digite o Nome");
            string nomeCidade = Console.ReadLine();

            Cidade cidade = new Cidade(idCidade, nomeCidade);
            CidadeControle.add(cidade);
            
            Pessoa pessoa = new Pessoa(id, nome, telefone, cidade);
            PessoaControle.add(pessoa);
            Console.WriteLine("Pessoa cadastrada com sucesso.");
        }
        void listarPessoa()
        {
            foreach(Pessoa pe in PessoaControle.GetListas())
            {
                Console.WriteLine("\n"+pe.Id+" - "+ pe.Nome+" - "+pe.Telefone+ " - "+pe.Cidade+"\n");
            };
        }
        void alterarPessoa()
        {
            Console.WriteLine("digite o codigo da pessoa");
            int id = Convert.ToInt32(Console.ReadLine());
            Pessoa pe = PessoaControle.GetById(id);
            if(pe != null)
            {
                Console.WriteLine("\nCódigo: "+pe.Id);
                Console.WriteLine("Nome: "+pe.Nome);
                Console.WriteLine("Telefone: "+pe.Telefone+"\n");
                Console.WriteLine("*********************\n");
                Console.WriteLine("digite o Nome");
                string nome = Console.ReadLine();
                if (nome != null) 
                {
                    pe.Nome = nome;
                } 
                else 
                {
                    pe.Nome = "Sem nome";
                }

                Console.WriteLine("digite o telefone");
                string telefone = Console.ReadLine();
                if (telefone != null) 
                {
                    pe.Telefone = telefone;
                } 
                else 
                {
                    pe.Telefone = "Sem telefone";
                }
                PessoaControle.alterar(pe);
                Console.WriteLine("Pessoa alterada com sucesso");
            }


            else
            {
                Console.WriteLine("Pessoa não encontrada");
            }

        }
        void excluirPessoa()
        {
            Console.WriteLine("digite o codigo da pessoa");
            int id = Convert.ToInt32(Console.ReadLine());
            Pessoa pe = PessoaControle.GetById(id);
            if (pe != null)
            {
                PessoaControle.excluir(pe);
                Console.WriteLine("Pessoa excluida com sucesso");           
            }
            else
            {
                Console.WriteLine("Pessoa não encontrada");
            }
        }
    }
}


