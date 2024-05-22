using System.Diagnostics;
using System.Text;
using CompreAqui;

internal class Program
{
    static Dictionary<string, Cliente> Clientes = new Dictionary<string, Cliente>();
    static List<Produto> Produtos = new List<Produto>();
    private static void Main(string[] args)
    {
        Menu();
    }

    static void Menu()
    {
        string menu;
        do
        {
            Console.Clear();

            Console.WriteLine("Bem vindo ao compreAqui! \n");
            Console.WriteLine("===================================");
            Console.WriteLine("1- Cadastrar cliente");
            Console.WriteLine("2- Cadastrar produto");
            Console.WriteLine("3- Buscar cliente");
            Console.WriteLine("4- Adicionar produto ao carrinho");
            Console.WriteLine("5- Excluir produto do carrinho");
            Console.WriteLine("0- Sair\n");
            Console.WriteLine("===================================");

            Console.Write("-- ");
            menu = Console.ReadLine();

            switch (menu)
            {
                case "1": CadastrarCliente(); break;
                case "2": CadastrarProduto(); break;
                case "3": BuscarCliente(); break;
                case "4": AdicionarAoCarrinho(); break;
                case "5": RemoverDoCarrinho(); break;
                case "0": break;


                default: Console.WriteLine("Opção inválida!"); Console.ReadKey(); break;
            }
            menu = (menu == "0") ? "0" : "1"; //Necessario para capturar qualquer erro de digitação no "default" do switch
        } while (menu != "0");
    }

    static void CadastrarCliente()
    {
        Console.Clear();

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        Console.Write("Cpf: ");
        string cpf = Console.ReadLine();

        Console.Write("Endereço: ");
        string endereco = Console.ReadLine();

        if (Clientes.ContainsKey(cpf))
        {
            Console.WriteLine("Cpf já cadastrado!");
        }
        else
        {

            Clientes.Add(cpf, new Cliente(nome, email, cpf, endereco));
            Console.WriteLine("Cliente cadastrado com sucesso!");
        }

        Console.ReadKey();
    }

    static void CadastrarProduto()
    {
        Console.Clear();

        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Preço: ");
        double preco = double.Parse(Console.ReadLine());

        Console.Write("Quantidade: ");
        int quantidade = int.Parse(Console.ReadLine());

        Produtos.Add(new Produto(nome, preco, quantidade));
        Console.WriteLine("Produto cadastrado com sucesso!");
        Console.ReadKey();

    }

    static void BuscarCliente(string cpf_ = "")
    {
        Console.Clear();
        string cpf = cpf_;

        if (cpf.Length == 0)
        {
            Console.Write("Cpf do cliente: ");
            cpf = Console.ReadLine();
        }

        if (ValidarCpf(cpf))
        {
            var cliente = Clientes[cpf];
            Console.WriteLine("\n" + cliente.ToString());
            Console.WriteLine("\n(1) Ver Carrinho || (2) Voltar");
            var opcao = Console.ReadLine();
            if (opcao == "1")
            {
                VerCarrinho(cpf);
                Console.ReadKey();
            }

        }
        else
        {
            Console.WriteLine("Cliente não encontrado!");
            Console.ReadKey();
        }

    }

    static void AdicionarAoCarrinho(string cpf_ = "")
    {
        Console.Clear();
        string cpf = cpf_;

        if (cpf.Length == 0)
        {
            Console.Write("Cpf do cliente: ");
            cpf = Console.ReadLine();
        }

        if (ValidarCpf(cpf))
        {
            var cliente = Clientes[cpf];

            if (Produtos.Count() == 0)
            {
                Console.WriteLine("Nenhum produto cadastrado!");
            }
            else
            {
                Produto? produto = null;
                Produtos.ForEach(Console.WriteLine);

                Console.Write("Escolha o produto: ");
                int idProduto = int.Parse(Console.ReadLine());

                foreach (var prod in Produtos)
                {
                    if (prod.Id == idProduto)
                    {
                        produto = prod;
                        break;
                    }
                }

                if (produto != null)
                {
                    Console.Write("Quantidade: ");
                    int quantidade = int.Parse(Console.ReadLine());
                    var produtoAdicionado = cliente.AdicionarProduto(produto, quantidade);

                    if (produtoAdicionado) Console.WriteLine("Produto adicionado com sucesso!");
                    else Console.WriteLine("Erro! Estoque insuficiente!");

                }
                else
                {
                    Console.WriteLine("Produto não encontrado!");
                }
            }
        }
        else
        {
            Console.WriteLine("Cliente não encontrado!");
        }
        Console.ReadKey();
    }

    static void RemoverDoCarrinho(string cpf_ = "")
    {
        Console.Clear();

        string cpf = cpf_;

        if (cpf.Length == 0)
        {
            Console.Write("Cpf do cliente: ");
            cpf = Console.ReadLine();
        }

        if (ValidarCpf(cpf))
        {
            var cliente = Clientes[cpf];
            Console.WriteLine(cliente.Carrinho.ToString());

            if (cliente.Carrinho.CarrinhoVazio())
            {
                Console.ReadKey();
            }
            else
            {

                Console.Write("Escolha o produto para remover: ");
                int idProduto = int.Parse(Console.ReadLine());

                var produtoExcluido = cliente.ExcluirProduto(idProduto);

                Console.Clear();
                if (produtoExcluido) Console.WriteLine("Produto removido com sucesso");
                else Console.WriteLine("Erro! Produto não encontrado");

                Console.WriteLine(cliente.Carrinho.ToString());

                Console.ReadKey();
            }
        }

    }

    static void VerCarrinho(string cpf)
    {
        Console.Clear();

        if (ValidarCpf(cpf))
        {
            var cliente = Clientes[cpf];

            Console.Clear();
            Console.WriteLine(cliente.Carrinho.ToString());
            Console.WriteLine("(1) Adicionar produto | (2) Remover produto | (3)Finalizar compra | (4) Voltar");
            var opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1": AdicionarAoCarrinho(cpf); break;
                case "2": RemoverDoCarrinho(cpf); break;
                //case "3": FinalizarCompra(); break;
                case "4": BuscarCliente(cpf); break;
                default: { Console.WriteLine("Opção inválida!"); Console.ReadKey(); }; break;
            }
        }

    }

    static bool ValidarCpf(string cpf)
    {
        if (Clientes.ContainsKey(cpf)) return true;
        else return false;
    }
}