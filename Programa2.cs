class Program
{
    static Contatos contatos = new Contatos();

    static void Main()
    {
        int opcao;
        do
        {
            Console.WriteLine("Agenda Management System");
            Console.WriteLine("0. Sair");
            Console.WriteLine("1. Adicionar contato");
            Console.WriteLine("2. Adicionar telefone no contato");
            Console.WriteLine("3. Pesquisar contato");
            Console.WriteLine("4. Alterar contato");
            Console.WriteLine("5. Remover contato");
            Console.WriteLine("6. Listar contatos");

            Console.Write("Escolha uma opção: ");
            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                ExecuteOption(opcao);
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

        } while (opcao != 0);
    }

    static void ExecuteOption(int opcao)
    {
        switch (opcao)
        {
            case 1:
                AdicionarContato();
                break;
            case 2:
                AdicionarTelefoneNoContato();
                break;
            case 3:
                PesquisarContato();
                break;
            case 4:
                AlterarContato();
                break;
            case 5:
                RemoverContato();
                break;
            case 6:
                ListarContatos();
                break;
            case 0:
                Console.WriteLine("Saindo do programa.");
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
    }

    static void AdicionarContato()
    {
        Console.Write("Digite o email do contato: ");
        string email = Console.ReadLine();

        Console.Write("Digite o nome do contato: ");
        string nome = Console.ReadLine();

        Console.Write("Digite o dia de nascimento: ");
        int dia = int.Parse(Console.ReadLine());

        Console.Write("Digite o mês de nascimento: ");
        int mes = int.Parse(Console.ReadLine());

        Console.Write("Digite o ano de nascimento: ");
        int ano = int.Parse(Console.ReadLine());

        Data dtNasc = new Data();
        dtNasc.SetData(dia, mes, ano);

        Contato novoContato = new Contato(email, nome, dtNasc);

        if (contatos.Adicionar(novoContato))
        {
            Console.WriteLine("Contato adicionado com sucesso.");
        }
    }

    static void AdicionarTelefoneNoContato()
    {
        Console.Write("Digite o email do contato: ");
        string email = Console.ReadLine();

        Contato contato = new Contato(email, "", new Data());

        Contato encontrado = contatos.Pesquisar(contato);
        if (encontrado != null)
        {
            Console.Write("Digite o tipo do telefone: ");
            string tipo = Console.ReadLine();

            Console.Write("Digite o número do telefone: ");
            string numero = Console.ReadLine();

            Console.Write("É o telefone principal? (S/N): ");
            bool principal = Console.ReadLine().ToUpper() == "S";

            Telefone novoTelefone = new Telefone(tipo, numero, principal);

            encontrado.AdicionarTelefone(novoTelefone);
            Console.WriteLine("Telefone adicionado com sucesso ao contato.");
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }

    static void PesquisarContato()
    {
        Console.Write("Digite o email do contato: ");
        string email = Console.ReadLine();

        Contato contato = new Contato(email, "", new Data());

        Contato encontrado = contatos.Pesquisar(contato);
        if (encontrado != null)
        {
            Console.WriteLine(encontrado);
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }

    static void AlterarContato()
    {
        Console.Write("Digite o email do contato: ");
        string email = Console.ReadLine();

        Contato contato = new Contato(email, "", new Data());

        Contato encontrado = contatos.Pesquisar(contato);
        if (encontrado != null)
        {
            Console.Write("Digite o novo nome do contato: ");
            string novoNome = Console.ReadLine();

            encontrado.Nome = novoNome;

            Console.WriteLine("Contato alterado com sucesso.");
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }

    static void RemoverContato()
    {
        Console.Write("Digite o email do contato: ");
        string email = Console.ReadLine();

        Contato contato = new Contato(email, "", new Data());

        if (contatos.Remover(contato))
        {
            Console.WriteLine("Contato removido com sucesso.");
        }
        else
        {
            Console.WriteLine("Contato não encontrado.");
        }
    }

    static void ListarContatos()
    {
        contatos.ListarContatos();
    }
}